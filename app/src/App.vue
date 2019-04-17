<template>
  <div id="app">
    <nav-bar />
    <router-view />
  </div>
</template>

<script lang="ts">
import { Component, Vue, Watch } from "vue-property-decorator";
import "materialize-css/dist/css/materialize.min.css";
import "tiny-slider/dist/tiny-slider.css";
import { Action, State } from "vuex-class";
import NavBar from "./components/NavBar.vue";
import M from "materialize-css";
import { Module } from "@/store/store";
import { ActionsTypes as SeriesActionTypes } from "@/store/modules/series/actions";
import { NotificationState } from "@/store/modules/notification/types";

@Component({
  components: { NavBar }
})
export default class App extends Vue {
  @Action(SeriesActionTypes.FETCH_SERIES, { namespace: Module.SERIES })
  private fetchSeries!: () => Promise<void>;

  @Action(SeriesActionTypes.FETCH_LATEST_DOWNLOADED, {
    namespace: Module.SERIES
  })
  private fetchLatestDownloadedSeries!: () => Promise<void>;

  @State(Module.NOTIFICATIONS)
  private notificationState!: NotificationState;

  async mounted() {
    await this.fetchLatestDownloadedSeries();
    await this.fetchSeries();
    M.AutoInit();
  }

  @Watch("notificationState.notifications.length", { deep: true })
  onNotificationLengthChanged(to: number, from: number) {
    console.log("changed");
    if (to <= from) {
      return;
    }

    let item = this.notificationState.notifications.pop();
    if (!item) {
      return;
    }

    M.toast({ html: item.text });
  }
}
</script>

<style lang="less"></style>
