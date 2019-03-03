<template>
  <nav>
    <div class="nav-wrapper container">
      <ul id="nav-mobile" class="right hide-on-med-and-down">
        <li v-for="route in Routes" :key="route.path">
          <router-link v-if="!route.hide" :to="route.path">{{
            route.displayName
          }}</router-link>
        </li>
      </ul>
    </div>
  </nav>
</template>

<script lang="ts">
import { Routes } from "@/router";
import { Component, Vue } from "vue-property-decorator";

@Component({})
export default class NavBar extends Vue {
  get Routes() {
    return Routes;
  }
}
</script>

<style scoped></style>
