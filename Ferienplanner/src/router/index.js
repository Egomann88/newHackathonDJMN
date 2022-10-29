import { createRouter, createWebHistory } from "vue-router";
import Main from "../components/Main.vue";
import Statistic from "../components/Statistic.vue";
import Login from "../components/Login.vue";
import Anfragen from "../components/Anfragen.vue";

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
      path: "/anfragen",
      component: Anfragen
    },
    {
      // 404
      path: "/:pathMatch(.*)",
      component: Login,
    },
  ],
});

export default router;