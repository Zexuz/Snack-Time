<template>
  <div class="parent">
    <button>
      <img
        src="http://192.168.10.240:8989//MediaCover/45/poster.jpg?lastWrite=636827353357997910"
        alt="MOVUE NAME"
      />
    </button>
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

<style scoped lang="less">
.parent {
  display: inline-block;
  border: black solid thin;
  margin: 2px;
  transition: transform 0.2s;

  &:hover {
    transform: scale(1.5);
  }
}

button {
  background: none;
  color: inherit;
  border: none;
  padding: 0;
  font: inherit;
  cursor: pointer;
  outline: inherit;
  display: flex;
}

img {
  height: auto;
  width: 200px;
}
</style>
