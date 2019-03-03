<template>
  <div class="parent">
    <router-link :to="routerLink">
      <img :src="imageUrl" :alt="altImageTitle" />
    </router-link>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import { Series } from "@/logic/api/series/protogen/series";

@Component({
  components: {}
})
export default class MediaThumbnail extends Vue {
  @Prop() public series!: Series;

  get imageUrl(): string {
    return `http://192.168.10.240:8989${this.series.imagesUrl.poster}`; //todo change this to banner?
  }
  get altImageTitle(): string {
    return this.series.title;
  }

  get routerLink(): string {
    return "/series/" + this.series.id;
  }
}
</script>

<style scoped lang="less">
.parent {
  display: inline-block;
  border: black solid thin;
  transition: transform 0.2s;

  &:hover {
    transform: scale(1.5);
  }
}

img {
  height: auto;
  width: 200px;
  vertical-align: bottom;
}
</style>
