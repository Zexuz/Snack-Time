<template>
  <div>
    <video ref="video" @mouseenter="mouseEnter" @mouseleave="mouseLeave">
      <source :src="src" type="video/ogg" />
      <p>No Source</p>
    </video>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { HttpClient } from "@/logic/http/httpClient";

@Component({
  components: {}
})
export default class Playground extends Vue {
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
}
</script>

<style scoped></style>
