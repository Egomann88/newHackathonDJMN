<template>
  <div>
    <section class="w-full mx-auto">
      <div class="flex flex-wrap w-full relative bg-[#427CAC] p-2">
        <div class="w-full lg:w-1/3">
          <img src="../assets/logo.svg" alt="Projekt Ferienplanner" class="h-full hidden lg:inline " />
        </div>
        <div class="w-full lg:w-2/3 pl-20">
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

<script lang="ts">
import { defineComponent } from "vue";
export default defineComponent({
  components: {},
  setup() { },
  mounted() { },
  methods: {},
});
</script>

<style lang="css" scoped>

</style>