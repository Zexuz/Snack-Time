<template>
  <div class="parent">
    <img
      src="http://192.168.10.240:8989//MediaCover/45/poster.jpg?lastWrite=636827353357997910"
      alt="MOVUE NAME"
      width="200px"
    />
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

  private shouldShowText: boolean = false;

  public showText() {
    this.shouldShowText = true;
  }

  public hideText() {
    this.shouldShowText = false;
  }
}
</script>

<style>
.parent {
  border: black solid thin;
  margin: 2px;
}
</style>
