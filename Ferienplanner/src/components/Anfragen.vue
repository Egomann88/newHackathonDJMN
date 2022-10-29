<template>
  <div class="min-h-screen bg-[#cbcbcb] py-4">
    <div class="flex flex-wrap overflow-hidden w-3/4 m-auto">
      <div class="w-full bg-gray-100 pt-4">
        <div class="flex flex-wrap overflow-hidden px-4 text-lg">
          <div class="w-full overflow-hidden md:w-[35%] p-2 rounded-l-sm bg-[#cbcbcb]">Zeitraum</div>
          <div class="w-full overflow-hidden md:w-[25%] p-2 bg-[#cbcbcb]">Status</div>
          <div class="w-full overflow-hidden md:w-[40%] p-2 rounded-r-sm bg-[#cbcbcb]">Zusätzlicher Text</div>
        </div>
        <div class="w-full bg-gray-100 px-4 py-4">
          <!-- entries -->
          <div class="flex flex-wrap border-b-2 border-gray-300"  v-for="entry in Entries">
              <!-- {{console.log(entry)}} -->
              <div class="overflow-hidden w-[35%] p-2">
                <p class="text-xl">{{ entry.VacStartDate }} - {{ entry.VacEndDate }}
                </p>
                <p class="my-2">{{ numOfDays }} Urlaubstage</p>
              </div>
              <div class="overflow-hidden w-[25%] p-2">
                <div
                  class="px-4 py-2 text-center shadow-md rounded-sm transition focus:outline-none focus:ring-2 focus:ring-opacity-75 w-full bg-green-300"
                  type="submit">{{ entry.isApproved ? "Antrag genehmigt" : "Ausstehend" }}</div>
              </div>
              <div class="overflow-hidden w-[40%] p-2">{{ entry.Comment }}</div>
            </div>
          </div>
        </div>
      </div>
    </div>
</template>

<script>
import { defineComponent } from "vue";
export default defineComponent({
  components: {},
  setup() { },
  data() {



    return {
      Entries:[
        {
          ID: null,
          isApproved: null,
          isFullday: false,
          VacEndDate: null,
          VacStartDate: null,
          Comment: null
        }
      ]
    }
  },
  mounted() { this.GetUserVacation(1)},
  methods: {
    GetUserVacation: function (userID) {
      fetch('http://localhost:34474/API/Vacation')
        .then(res => {
          return res.json();
        })
        .then(data => {
          data.forEach(vacation => {
            if (vacation.UserID === userID) {
              this.Entries = [
               {
                  ID: vacation.ID, isApproved: vacation.isApproved, isFullday: vacation.isFullday, VacEndDate: vacation.VacEndDate, VacStartDate: vacation.VacStartDate, Comment: vacation.Comment
                },
                ...this.Entries
            
              ]
               console.log(this.Entries)
              // // console.log(vacation)
              // console.log(this.Entries)
              // this.fromDate = vacation.VacStartDate
              // this.toDate = vacation.VacEndDate
              // this.numOfDays = 1
              // this.comment = vacation.VacatonReasonID
            }            

          });
        })
    },
  },
});
</script>

<style scoped>

</style>