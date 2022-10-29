import { createRouter, createWebHistory } from "vue-router";
import Main from "../components/Main.vue";
import Statistic from "../components/Statistic.vue";

const router = createRouter({
  history: createWebHistory(),
  routes: [
    {
      path: "/",
      component: Main,
    },
    {
      path: "/statistic",
      component: Statistic,
    },
    {
      // 404
      path: "/:pathMatch(.*)",
      component: Main,
    },
  ],
});

export default router;