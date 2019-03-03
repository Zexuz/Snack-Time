<template>
  <div>
    <!--<media-list Text="New" />-->
    <!--<media-list Text="Downloaded" />-->
    <!--<media-list Text="Watch again" />-->

    <h2 class="center">Browse</h2>

    <div class="media-container">
      <media-thumbnail
        v-for="series in response"
        :series="series"
        class="media-item"
      />
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import MediaThumbnail from "../components/MediaThumbnail";
import MediaList from "../components/MediaList";
import { HttpClient } from "@/logic/http/httpClient";
import { Endpoints } from "@/logic/api/series/endpoints";
import { Series } from "@/logic/api/series/protogen/series";

@Component({
  components: {
    MediaThumbnail,
    MediaList
  }
})
export default class Home extends Vue {
  private response: Series[] = [];

  async mounted() {
    let res = await HttpClient.get<Series[]>(Endpoints.GetSeries());
    this.response = res.payload;
  }
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
