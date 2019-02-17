<template>
  <div>
    <media-list Text="New" />
    <media-list Text="Downloaded" />
    <media-list Text="Watch again" />

    <h2 class="center">Browse</h2>

    <div class="media-container">
      <media-thumbnail class="media-item" />
      <media-thumbnail class="media-item" />
      <media-thumbnail class="media-item" />
      <media-thumbnail class="media-item" />
      <media-thumbnail class="media-item" />
      <media-thumbnail class="media-item" />
      <media-thumbnail class="media-item" />
      <media-thumbnail class="media-item" />
      <media-thumbnail class="media-item" />
      <media-thumbnail class="media-item" />
      <media-thumbnail class="media-item" />
      <media-thumbnail class="media-item" />
      <media-thumbnail class="media-item" />
      <media-thumbnail class="media-item" />
      <media-thumbnail class="media-item" />
      <media-thumbnail class="media-item" />
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import MediaThumbnail from "../components/MediaThumbnail";
import MediaList from "../components/MediaList";

@Component({
  components: {
    MediaThumbnail,
    MediaList
  }
})
export default class Home extends Vue {}
</script>

<style scoped>
.media-container {
  display: flex;
  flex-flow: row wrap;
  justify-content: center;
}
</style>
