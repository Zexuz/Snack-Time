<template>
  <div>
    <h2 class="center">
      {{ Text }}
    </h2>
    <div class="parent-media">
      <div :class="customClassName">
        <media-thumbnail />
        <media-thumbnail />
        <media-thumbnail />
        <media-thumbnail />
        <media-thumbnail />
        <media-thumbnail />
        <media-thumbnail />
        <media-thumbnail />
        <media-thumbnail />
      </div>
      <div :id="customClassName" class="media-container">
        <span data-controls="prev" class="media-left">
          <i class="fas fa-angle-left icon-big"></i>
        </span>
        <span data-controls="next" class="media-right">
          <i class="fas fa-angle-right icon-big"></i>
        </span>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import MediaThumbnail from "../components/MediaThumbnail";
import { tns } from "tiny-slider/src/tiny-slider";

@Component({
  components: {
    MediaThumbnail
  }
})
export default class MediaList extends Vue {
  @Prop()
  Text!: string;

  mounted() {
    tns({
      slideBy: "page",
      controls: true,
      fixedWidth: 202,
      container: "." + this.customClassName,
      controlsContainer: "#" + this.customClassName,
      swipeAngle: false,
      speed: 600,
      mouseDrag: true
    });
  }

  get customClassName() {
    return "my-slider-" + this.Text.replace(" ", "-");
  }
}
</script>

<style></style>

<style scoped lang="less">
.parent-media {
  position: relative;

  .media-left {
    position: absolute;
    top: 50%;
    transform: translateY(-25%);
    left: 0;
    cursor: pointer;
  }

  .media-right {
    position: absolute;
    top: 50%;
    transform: translateY(-25%);
    right: 0;
    cursor: pointer;
  }

  &:hover {
    .media-left {
      background-color: rgba(249, 247, 255, 0.61);
    }

    .media-right {
      background-color: rgba(249, 247, 255, 0.61);
    }
  }
}

.icon-big {
  font-size: 8rem;
}
</style>
