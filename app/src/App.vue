<template>
  <div id="app">
    <nav-bar />
    <router-view />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import "materialize-css/dist/css/materialize.min.css";
import "tiny-slider/dist/tiny-slider.css";
import { Action, State } from "vuex-class";
import NavBar from "./components/NavBar.vue";
import M from "materialize-css";
import { Module } from "@/store/store";
import { ActionTypes } from "@/store/modules/series/actions";

@Component({
  components: { NavBar }
})
export default class App extends Vue {
  @Action(ActionTypes.FETCH_SERIES, { namespace: Module.SERIES })
  private fetchSeries!: () => Promise<void>;

  async mounted() {
    await this.fetchSeries();
    M.AutoInit();
  }
}
</script>

<style lang="less"></style>
