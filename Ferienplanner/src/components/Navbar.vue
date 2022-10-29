<template>
  <div>
    <section class="w-full mx-auto">
      <div class="flex flex-wrap w-full relative bg-[#427CAC] p-2">
        <div class="w-full lg:w-1/3 block">
          <img src="../assets/logo.svg" alt="Projekt Ferienplanner" class="h-full hidden lg:inline " />
        </div>
        <div v-if="isLoggedIn()" class="w-full lg:w-2/3 pl-20">
          <router-link to="/calendar" class="btn-Header m-2 inline-block text-lg">Kalendar
          </router-link>
          <router-link to="/statistic" class="btn-Header m-2 inline-block text-lg">Statistik
          </router-link>
          <router-link to="/anfragen" class="btn-Header m-2 inline-block text-lg">Anträge
          </router-link>
          <div class="inline-block items-center float-right m-2 mr-10">
            <div>
              <button @click="showFullName = !showFullName" type="button"
                class="items-center bg-transparent border-none flex justify-center min-h-[44px]">
                <span
                  class="items-center bg-gray-100 rounded-full text-black flex h-[2.4rem] w-[2.4rem] justify-center transform-gpu duration-300 hover:bg-gray-300 hover:scale-125">
                  {{ firstNameLetter + lastNameLetter }}</span>
              </button>
              <div v-if="showFullName" class="bg-gray-100 p-2 absolute right-3 mt-4">{{ firstName + ' ' + lastName }}
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>

<script>
import { defineComponent } from "vue";
export default defineComponent({
  components: {},
  setup() { },
  data() {
    let showFullName = false;
    let firstName = "Max";
    let lastName = "Mustermann";
    let firstNameLetter = firstName.slice(0, 1);
    let lastNameLetter = lastName.slice(0, 1);

    return {
      showFullName,
      firstName,
      lastName,
      firstNameLetter,
      lastNameLetter
    }
  },
  mounted() { },
  methods: {
    
    isLoggedIn() {
      if (localStorage.getItem('loggedIn') == '1') return true;
      return false;
    },
    
  },
});
</script>

<style lang="css" scoped>

</style>