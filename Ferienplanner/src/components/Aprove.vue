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
            <div class="flex flex-wrap border-b-2 border-gray-300">
              <div class="overflow-hidden w-[35%] p-2">
                <p class="text-xl">{{ fromDate.toDateString().substring(4) }} - {{ toDate.toDateString().substring(4) }}
                </p>
                <p class="my-2">{{ numOfDays }} Urlaubstage</p>
              </div>
              <div class="overflow-hidden w-[25%] p-2">
                <div
                  class="px-4 py-2 text-center shadow-md rounded-sm transition focus:outline-none focus:ring-2 focus:ring-opacity-75 w-full bg-green-300"
                  type="submit">{{ isApproved ? "Antrag genehmigt" : "Ausstehend" }}</div>
              </div>
              <div class="overflow-hidden w-[40%] p-2">{{ comment }}</div>
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
      let fromDate = new Date("2000-01-01");
      let toDate = new Date("2000-01-01");
      let numOfDays = 0;
      let isApproved = false;
      let comment = "";
  
  
      return {
        fromDate,
        toDate,
        numOfDays,
        isApproved,
        comment
      }
    },
    mounted() { },
    methods: {},
  });
  </script>
  
  <style scoped>
  
  </style>