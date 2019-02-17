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
  }
];

export default new Router({
  // mode: "history",
  base: process.env.BASE_URL,
  routes: Routes
});
