import { createRouter, createWebHistory } from "vue-router";
import Main from "../components/Main.vue";
import Statistic from "../components/Statistic.vue";
import Login from "../components/Login.vue";

const router = createRouter({
  history: createWebHistory(),
  routes: [
    {
      path: "/",
      component: Login,
    },
    {
      path: "/Calendar",
      component: Main,
    },
    {
      path: "/statistic",
      component: Statistic,
    },
    {
      // 404
      path: "/:pathMatch(.*)",
      component: Login,
    },
  ],
});

export default router;