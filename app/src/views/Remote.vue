<template>
  <div class="container">
    <h1>Remote</h1>
    <div class="row">
      <p class="col s12">
        Blue Planet II - S01E02 - The Deep WEBDL - 1080p.mlv
      </p>
    </div>

    <div class="row">
      <span class="col s12">RUNNING</span>
      <span class="col s12">00:15:45 / 00:59:45</span>
      <p class="range-field col s12">
        <input
          v-model="slider"
          type="range"
          id="progress"
          min="0"
          max="3600"
          @mouseup="droppedMouse()"
        />
      </p>
    </div>

    <div class="row">
      <button class="btn col s12" @click="toggleState()">Start/Pause</button>
    </div>

    <div class="row">
      <button class="btn col s5">-5</button>
      <span class="col s2"></span>
      <button class="btn col s5">+5</button>
    </div>
    <div class="row">
      <button class="btn col s5">-15</button>
      <span class="col s2"></span>
      <button class="btn col s5">+15</button>
    </div>
    <div class="row">
      <button class="btn col s5">-60</button>
      <span class="col s2"></span>
      <button class="btn col s5">+60</button>
    </div>
  </div>
</template>

<script lang="ts">
import { HttpClient } from "@/logic/http/httpClient";
import { Component, Vue } from "vue-property-decorator";

@Component({
  components: {}
})
export default class Remote extends Vue {
  private slider: number = 0;

  async toggleState() {
    await HttpClient.post(RemoteEndpointsV1.Toggle);
  }

  droppedMouse() {}
}

class RemoteEndpointsV1 {
  public static Toggle = "/api/remote/v1/toggle";
}
</script>

<style scoped>
p {
  margin: 0;
}
</style>
