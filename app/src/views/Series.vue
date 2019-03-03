<template>
  <div class="container">
    <div class="row">
      <div class="col s12">
        <div class="card blue-grey darken-1">
          <div class="card-content white-text">
            <span class="card-title">{{ currentSeries.title }}</span>
            <img class="left" height="200px" :src="imageUrl" />
            <p>
              {{ currentSeries.overview }}
            </p>

            <h5>Next episode placeholder!</h5>
            <p>
              NEXT EPISODE OVERVIEW PLACEHOLDER
            </p>
          </div>
          <div class="card-action">
            <button class="btn">Play</button>
            <a
              class="right"
              target="_blank"
              href="http://192.168.10.240:8989/series/doom-patrol"
              >Go to Sonarr</a
            >
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { State } from "vuex-class";
import { Module } from "@/store/store";
import { SeriesState } from "@/store/modules/series/types";
import { Series } from "@/logic/api/series/protogen/series";

@Component({
  components: {}
})
export default class SeriesInfo extends Vue {
  @State(Module.SERIES)
  private seriesState!: SeriesState;

  get imageUrl(): string {
    return `http://192.168.10.240:8989${this.currentSeries.imagesUrl.poster}`; //todo change this to banner?
  }

  get currentSeries(): Series {
    let id = Number(this.$route.params["id"]);
    return this.seriesState.series.filter(value => value.id === id)[0];
  }
}
</script>

<style scoped>
img.left {
  margin-right: 25px;
}

.card-content {
  overflow: hidden;
}

.card {
  opacity: 0.9;
}
</style>
