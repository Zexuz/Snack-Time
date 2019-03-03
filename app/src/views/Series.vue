<template>
  <div>
    <h2>Series {{ $route.params.id }}</h2>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { HttpClient } from "@/logic/http/httpClient";
import { Endpoints } from "@/logic/api/series/endpoints";

@Component({
  components: {}
})
export default class Series extends Vue {
  async mounted() {
    let res = await HttpClient.get<Series[]>(
      Endpoints.GetSeriesById(this.$route.params["id"] as number)
    );
    console.log(res);
  }
}
</script>

<style scoped></style>
