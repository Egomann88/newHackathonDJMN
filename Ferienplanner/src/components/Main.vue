<template>
  <div class="bg-[#cbcbcb] py-4">
    <div class="flex flex-wrap overflow-hidden w-3/4 m-auto pt-2">
      <div class="w-1/3 px-4">
        <form class="flex flex-wrap w-full overflow-hidden py-4 bg-gray-100 p-4">
          <div class="w-full overflow-hidden py-4">
            <div class="w-full py-2 px-4 ">
              <div class="border-black border-2 rounded-sm">
                <p class="text-center bg-[#519ad6] rounded-t-sm">Am/Ab*</p>
                <input class="p-2 rounded-b-sm w-full" type="date" required>
              </div>
            </div>
            <div v-if="showUntilInput" class="w-full py-2 px-4 ">
              <div class="border-black border-2 rounded-sm">
                <p class="text-center bg-[#519ad6] rounded-t-sm">Bis (optional)</p>
                <input class="p-2 rounded-b-sm w-full" type="date" required>
              </div>
            </div>
          </div>
          <div class="w-full px-4 py-2">
            <input class=" inline-block m-2" type="checkbox" @click="showUntilInput = !showUntilInput" />
            <p class="inline-block">Halber Tag abwesend</p>
          </div>
          <div class="w-full px-4 py-2">
            <div class="border-black border-2 rounded-sm">
              <p class="text-center bg-[#519ad6] rounded-t-sm w-full">Grund*</p>
              <select class="w-full minimal">
                <option>--Auswählen--</option>
              </select>
            </div>
          </div>
          <div class="flex w-full px-4 ">
            <div class="border-black border-2 rounded-sm w-full">
              <p class=" bg-[#519ad6] rounded-t-sm text-center">Beschreibung</p>
              <textarea class="p-2 rounded-b-sm w-full max-h-[10rem]" name="" id="" rows="3"></textarea>
            </div>
          </div>
          <div class="w-full px-4">
            <button class="button w-full my-4 bg-green-300 hover:bg-green-400" type="submit"
              value="submit">Bestätigen</button>
          </div>
        </form>
        <aside class="mt-4 bg-gray-100">
          <div class="p-4">
            <h2>Statistiken</h2>
            <div class="mt-2">
              <div class="w-full">
                <b>Übrige Ferientage:</b> <span>{{ 25.5 }} von {{ 28 }}</span>
              </div>
              <div class="w-full">
                <b>Angefrage Ferientage: </b> <span>{{ 3 }}</span>
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

    return {
      showUntilInput,
      calendarOptions: {
        plugins: [dayGridPlugin, interactionPlugin],
        // view on start of page
        initialView: 'dayGridMonth',
        // entries in calendar
        events: [
          {
            id: '1',
            title: 'Testevent',
            start: '2022-10-28'
          }],
        // Tools for switching day, week or month
        headerToolbar: {
          center: 'dayGridMonth,dayGridWeek,dayGridDay' // buttons for switching between views
        },
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
    changeToDay: function (info) {
      console.log("Clicked", info);
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
            if (vacation.UserID === userID) {
              console.log(vacation.VacDayDate);
            }
          });
        })
    },
  },
  mounted() {
    this.MarkUserVacationDates(6);
  }

}
</script>