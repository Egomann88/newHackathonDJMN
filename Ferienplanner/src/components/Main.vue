<template>
  <div class=" bg-[#cbcbcb] py-4">
    <div class="flex flex-wrap overflow-hidden w-3/4 m-auto pt-2">
      <div class="w-1/3 px-4">
        <div class="flex flex-wrap w-full overflow-hidden py-4 bg-gray-100 p-4">
          <div class="w-full overflow-hidden py-4">
            <div class="w-full py-2 px-4 ">
              <div class="border-black border-2 rounded-sm">
                <p class="text-center bg-[#519ad6] rounded-t-sm">Am/Ab*</p>
                <input class="p-2 rounded-b-sm w-full" id="fromDate" name="from" type="date" required>
              </div>
            </div>
            <div v-if="showUntilInput" class="w-full py-2 px-4 ">
              <div class="border-black border-2 rounded-sm">
                <p class="text-center bg-[#519ad6] rounded-t-sm">Bis (optional)</p>
                <input class="p-2 rounded-b-sm w-full" id="toDate" name="to" type="date">
              </div>
            </div>
          </div>
          <div class="w-full px-4 py-2">
            <input class=" inline-block m-2" id="halfDAy" name="halfDay" type="checkbox"
              @click="showUntilInput = !showUntilInput" />
            <p class="inline-block">Halber Tag abwesend</p>
          </div>
          <div class="w-full px-4 py-2">
            <div class="border-black border-2 rounded-sm">
              <p class="text-center bg-[#519ad6] rounded-t-sm w-full">Grund*</p>
              <select class="w-full minimal" id="VacationTitle">
                <option>--Auswählen--</option>
                <option>Schule</option>
                <option>Urlaub</option>
                <option>Militär</option>
                <option>Kurs</option>
                <option>Weiterbildung</option>
                <option>Operation</option>
                <option>Familie</option>
                <option>Andere</option>
              </select>
            </div>
          </div>
          <div class="flex w-full px-4 ">
            <div class="border-black border-2 rounded-sm w-full">
              <p class=" bg-[#519ad6] rounded-t-sm text-center">Beschreibung</p>
              <textarea class="p-2 rounded-b-sm w-full max-h-[10rem]" name="" id="Description" rows="3"></textarea>
            </div>
          </div>
          <div class="w-full px-4">
            <button class="button w-full my-4 bg-green-300 hover:bg-green-400" @click="onSaveClick()" type="submit"
              value="submit">Beantragen</button>
          </div>
        </div>
        <aside class="mt-4 bg-gray-100">
          <div class="p-4">
            <h2>Statistiken</h2>
            <div class="mt-2">
              <div class="w-full">
                <b>Übrige Ferientage:</b> <span>{{ VacationAmount }}</span>
              </div>
              <div class="w-full">
                <b>Angefrage Ferientage: </b> <span>{{ PendingVacations }}</span>
              </div>
            </div>
          </div>
        </aside>
      </div>
      <div class="w-2/3 h-full px-4">
        <div class="bg-gray-100 p-4">
          <FullCalendar ref="fullCalendar" :options="calendarOptions" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import '@fullcalendar/core/vdom' // solves problem with Vite
import FullCalendar from '@fullcalendar/vue3'
import dayGridPlugin from '@fullcalendar/daygrid'
import interactionPlugin from '@fullcalendar/interaction'
import deLocale from '@fullcalendar/core/locales/de';


export default {
  components: {
    FullCalendar // make the <FullCalendar> tag available
  },
  data() {
    let showUntilInput = true;
    let VacationAmount = 0;
    let PendingVacations = 0

    return {
      VacationAmount,
      PendingVacations,
      showUntilInput,
      calendarOptions: {
        plugins: [dayGridPlugin, interactionPlugin],
        // view on start of page
        initialView: 'dayGridMonth',
        // entries in calendar
        // Tools for switching day, week or month
        headerToolbar: {
          center: 'dayGridMonth,dayGridWeek,dayGridDay' // buttons for switching between views
        },
        businessHours: {
          // days of week. an array of zero-based day of week integers (0=Sunday)
          daysOfWeek: [1, 2, 3, 4, 5], // Monday - Thursday
          startTime: '8:00', // a start time (10am in this example)
          endTime: '18:00', // an end time (6pm in this example)
        },
        events: [
          {
            // id: '1',
            // title: 'Testevent',
            // start: '2022-10-28'
          },],
          
        // The custom views with settings
        views: {
          dayGridMonth: {
            type: 'dayGridMonth',
          },
          dayGridWeek: {
            type: 'dayGridWeek',
          },
          dayGridDay: {
            type: 'dayGridDay',
          }
        },
        navLinks: true,
        selectable: true,
        locales: [deLocale],
        locale: 'de',
        dateClick: this.changeToDay, // On Date Click, calls function declared in methods
      },
    }
  },
  methods: {
    // Changes View to clicked day
    changeToDay: function (info) {
      console.log("Clicked", info);
      // Gets connection to database
      let calendarApi = this.$refs.fullCalendar.getApi()
      calendarApi.changeView('dayGridDay', info.date)
    },
    MarkUserVacationDates: function (userID) {
      fetch('http://localhost:34474/API/Vacation')
        .then(res => {
          return res.json();
        })
        .then(data => {
          data.forEach(vacation => {
            
              let backgroundColor = 'rgb(252 165 165)' //red
            if(vacation.IsApproved == true)
              { backgroundColor = 'rgb(134 239 172)'} //green
            this.calendarOptions.events = [
              ...this.calendarOptions.events,
              { title: vacation.Comment, start: vacation.VacStartDate, end: vacation.VacEndDate, color: backgroundColor}
              ]
          });
        })
    },

    onSaveClick: function (userID) {
      // strings
      let fromDateValueStr = document.getElementById("fromDate").value;
      let toDateValueStr = document.getElementById("toDate").value;
      let VacationTitle = document.getElementById("VacationTitle").value;
      let Description = document.getElementById("Description").value;
      // date
      let fromDateValueDate = fromDateValueStr;
      let toDateValueDate = toDateValueStr;

      let titletxt = VacationTitle + ' | ' + Description;

      let xhr = new XMLHttpRequest();
      xhr.open("POST", "http://localhost:34474/api/vacation");
      xhr.setRequestHeader("Accept", "application/json");
      xhr.setRequestHeader("Content-Type", "application/json");

      xhr.onreadystatechange = function () {
        if (xhr.readyState === 4) {
          console.log(xhr.status);
          console.log(xhr.responseText);
        }
      };

      let data = {
        "ID": 1,
        "UserID": userID,
        "VacStartDate": toDateValueDate,
        "IsFullDay": true,
        "IsApproved": false,
        "VacationReasonID": 2,
        "VacEndDate": fromDateValueDate,
        "Comment": titletxt
      };
      xhr.send(JSON.stringify(data));
      this.calendarOptions.events = [
        ...this.calendarOptions.events,
        { title: titletxt, start: fromDateValueDate, end: toDateValueDate, color: 'rgb(252 165 165)' }
      ]
    },

    GetVacationAmount: function (userID) {
      fetch('http://localhost:34474/API/user')
        .then(res => {
          return res.json()
        })
        .then(data => {
          data.forEach(user => {
            console.log(user.ID)
            if (user.ID == userID) {
              this.VacationAmount = user.VacationCredit;
    
            }
          })
        })
    },
    GetPendingVacationAmt: function (userID) {
      fetch('http://localhost:34474/API/Vacation')
        .then(res => {
          return res.json()
        })
        .then(data => {
          data.forEach(vacation => {
            console.log(vacation)   
              if (!vacation.IsApproved) {
                this.PendingVacations++         
            }
          })
        })
    }
  },
  mounted() {
    this.MarkUserVacationDates(localStorage.getItem("UserID"));
    this.GetVacationAmount(localStorage.getItem("UserID"));
    this.GetPendingVacationAmt(localStorage.getItem("UserID"));
    // this.PostVacation();
  }

}
</script>