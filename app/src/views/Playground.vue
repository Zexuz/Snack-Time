<template>
  <div>
    <video ref="video" @mouseenter="mouseEnter" @mouseleave="mouseLeave">
      <source :src="src" type="video/ogg" />
      <p>No Source</p>
    </video>
    <button @click="add()">add notification with Level.Info</button>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { Action } from "vuex-class";
import { Module } from "@/store/store";
import { ActionTypes } from "@/store/modules/notification/actions";
import { Level, Notification } from "@/store/modules/notification/types";

@Component({
  components: {}
})
export default class Playground extends Vue {
  @Action(ActionTypes.ADD, { namespace: Module.NOTIFICATIONS })
  private addNotification!: (notification: Notification) => void;

  public $refs!: {
    video: HTMLVideoElement;
  };

  public src: string = "";

  private mouseLeave() {
    this.$refs.video.pause();
    this.$refs.video.currentTime = 0;
  }

  private async mouseEnter() {
    this.$refs.video.setAttribute(
      "src",
      "http://localhost:5000/api/series/v1/url"
    );
    let startTime = Date.now();
    await this.$refs.video.play();
    console.log(Date.now() - startTime);
  }

  add() {
    this.addNotification({
      duration: 4000,
      level: Level.Info,
      text: "Hello, World!"
    });
  }
}
</script>

<style scoped></style>
