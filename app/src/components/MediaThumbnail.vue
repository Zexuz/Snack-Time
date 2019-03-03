<template>
  <div class="parent">
    <router-link to="/series/5">
      <img
        src="http://192.168.10.240:8989//MediaCover/45/poster.jpg?lastWrite=636827353357997910"
        alt="MOVUE NAME"
      />
    </router-link>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";

@Component({
  components: {}
})
export default class MediaThumbnail extends Vue {
  @Prop() public Titel!: string;
  @Prop() public Image!: string;
  @Prop() public Id!: string;
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
}
</style>
