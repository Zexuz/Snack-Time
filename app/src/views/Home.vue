<template>
  <div>
    <!--<media-list Text="New" />-->
    <!--<media-list Text="Downloaded" />-->
    <!--<media-list Text="Watch again" />-->

    <h2 class="center">Browse</h2>

    <div class="media-container">
      <media-thumbnail
        v-for="series in seriesState.series"
        :series="series"
        class="media-item"
      />
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import MediaThumbnail from "../components/MediaThumbnail.vue";
import MediaList from "../components/MediaList.vue";
import { State } from "vuex-class";
import { SeriesState } from "@/store/modules/series/types";
import { Module } from "@/store/store";

@Component({
  components: {
    MediaThumbnail,
    MediaList
  }
})
export default class Home extends Vue {
  @State(Module.SERIES)
  private seriesState!: SeriesState;
}
</script>

<style scoped>
.media-container {
  display: flex;
  flex-flow: row wrap;
  justify-content: center;
}

.media-item {
  margin: 0.25rem;
}
</style>
