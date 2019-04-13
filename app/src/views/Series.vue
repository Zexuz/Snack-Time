<template>
  <div class="container">
    <img class="bg" :src="backgroundImage" alt="backgorund image" />
    <div class="row">
      <div class="col s12">
        <div class="card blue-grey darken-1 opacity">
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
    <div>
      <ul class="collapsible popout opacity">
        <li v-for="season in seasons" :key="season.number">
          <div class="collapsible-header">
            <span>Season {{ season.number }}</span>
          </div>
          <div class="collapsible-body">
            <table class="series-table">
              <thead>
                <tr>
                  <th>#</th>
                  <th></th>
                  <th>Name</th>
                  <th>Airdate</th>
                  <th>Download date</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="episode in season.episodes">
                  <td>{{ episode.episideNumber }}</td>
                  <td>
                    <button
                      :disabled="episode.episodeFileId === 0"
                      @click="play(episode.episodeFileId)"
                      class="btn"
                    >
                      play
                    </button>
                  </td>
                  <td>
                    {{ episode.title }}
                  </td>
                  <td>TODO</td>
                  <td>TODO</td>
                </tr>
              </tbody>
            </table>
          </div>
        </li>
      </ul>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { Action, Getter, State } from "vuex-class";
import { Module } from "@/store/store";
import { SeriesState } from "@/store/modules/series/types";
import { ImageUrl, Series } from "@/logic/api/types";
import { ActionTypes } from "@/store/modules/episodes/actions";
import { Methods, Season } from "@/store/modules/episodes/getters";
import M from "materialize-css";
import { HttpClient } from "@/logic/http/httpClient";
import { Endpoints } from "@/logic/api/remote/endpoints";

@Component({
  components: {}
})
export default class SeriesInfo extends Vue {
  @State(Module.SERIES)
  private seriesState!: SeriesState;

  @Action(ActionTypes.FETCH_EPISODES, { namespace: Module.EPISODES })
  private fetchEpisodes!: (seriesId: number) => Promise<void>;

  @Getter(Methods.GET_SEASONS, { namespace: Module.EPISODES })
  private getSeasons!: (seriesId: number) => Season[];

  async mounted() {
    await this.fetchEpisodes(this.currentId());
    M.AutoInit();
  }

  private async play(fileId: number) {
    let res = await HttpClient.get<object>(Endpoints.PlayFile(fileId));
  }

  get imageUrl(): string {
    return `http://192.168.10.240:8989${this.currentSeries.imagesUrl.poster}`; //todo change this to banner?
  }

  get backgroundImage(): string {
    return `http://192.168.10.240:8989${this.currentSeries.imagesUrl.fanart}`; //todo change this to banner?
  }

  get currentSeries(): Series {
    let id = this.currentId();
    let matches = this.seriesState.series.filter(value => value.id === id);
    if (matches.length == 0) {
      return new Series({ imagesUrl: new ImageUrl() });
    }
    return matches[0];
  }

  get seasons(): Season[] {
    return this.getSeasons(this.currentId());
  }

  private currentId(): number {
    return Number(this.$route.params["id"]);
  }
}
</script>

<style scoped>
img.bg {
  min-height: 100%;
  min-width: 1080px;
  width: 100%;
  height: auto;
  position: fixed;
  top: 0;
  left: 0;
  z-index: -100000;
}

td {
  padding-top: 2px;
  padding-bottom: 2px;
}

img.left {
  margin-right: 25px;
}

.collapsible-body {
  background-color: white;
}

.card-content {
  overflow: hidden;
}

.opacity {
  opacity: 0.9;
}
</style>
