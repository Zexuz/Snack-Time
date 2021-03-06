import Vue from "vue";
import Router from "vue-router";
import Home from "./views/Home.vue";

Vue.use(Router);

export const Routes = [
  {
    displayName: "Home",
    path: "/",
    name: "home",
    component: Home
  },
  {
    displayName: "Remote",
    path: "/remote",
    name: "remote",
    component: () => import("./views/Remote.vue")
  },
  {
    displayName: "Calendar",
    path: "/calendar",
    name: "calender",
    component: () => import("./views/Calendar.vue")
  },
  {
    hide: true,
    displayName: "Series",
    path: "/series/:id",
    name: "series",
    component: () => import("./views/Series.vue")
  },
  {
    displayName: "Settings",
    path: "/settings",
    name: "settings",
    component: () => import("./views/Settings.vue")
  },
  {
    displayName: "playground",
    path: "/playground",
    name: "playground",
    component: () => import("./views/Playground.vue")
  }
];

export default new Router({
  // mode: "history",
  base: process.env.BASE_URL,
  routes: Routes
});
