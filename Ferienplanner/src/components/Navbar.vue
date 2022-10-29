<template>
  <div>
    <section class="w-full mx-auto">
      <div class="flex flex-wrap w-full relative bg-[#427CAC] p-2">
        <div class="w-full lg:w-1/3 block">
          <img src="../assets/logo.svg" alt="Projekt Ferienplanner" class="h-full hidden lg:inline " />
        </div>
        <div v-if="isLoggedIn()" class="w-full lg:w-2/3 pl-20">
          <router-link to="/" class="btn-Header m-2 inline-block text-lg">Kalendar
          </router-link>
          <router-link to="/statistic" class="btn-Header m-2 inline-block text-lg">Statistik
          </router-link>
          <router-link to="/" class="btn-Header m-2 inline-block text-lg">Anfragen
          </router-link>
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
  mounted() { },
  methods: {
    isLoggedIn() {
      if (localStorage.getItem('loggedIn') == '1') return true;
      return false;
    }
  },
});
</script>

<style lang="css" scoped>

</style>