<template>
  <div class="min-h-full">
    <Header />
    <router-view></router-view>
  </div>
</template>

<script  lang="ts">
import { defineComponent } from "vue";
import Header from "./components/Navbar.vue";

export default defineComponent({
  components: {
    Header,
  },
  setup() { },
  mounted() {
    this.checkLogin();
  },
  methods: {
    checkLogin() {
      if (localStorage.getItem("loggedIn") == "0" || !localStorage.getItem("loggedIn")) this.$router.push("/login");
    }
  },
});
</script>

<style scoped>

</style>
