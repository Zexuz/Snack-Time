<template>
  <div>
    <h2 class="center">
      <button class="btn col s2">
        <i class="material-icons">keyboard_arrow_left</i>
      </button>
      {{ Text }}
      <button class="btn col s2">
        <i class="material-icons">keyboard_arrow_right</i>
      </button>
    </h2>
    <div class="media-container">
      <media-thumbnail />
      <media-thumbnail />
      <media-thumbnail />
      <media-thumbnail />
      <media-thumbnail />
      <media-thumbnail />
      <media-thumbnail />
      <media-thumbnail />
      <media-thumbnail />
      <media-thumbnail />
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import MediaThumbnail from "../components/MediaThumbnail";

@Component({
  components: {
    MediaThumbnail
  }
})
export default class MediaList extends Vue {
  @Prop()
  Text!: string;
}
</script>

<style scoped>
.media-container {
  display: flex;
  flex-flow: nowrap row;
  justify-content: center;
  overflow-y: hidden;
}
</style>
