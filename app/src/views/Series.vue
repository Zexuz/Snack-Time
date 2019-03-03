<template>
  <div>
    <h2>Series {{ $route.params.id }}</h2>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component({
  components: {}
})
export default class Series extends Vue {}
</script>

<style scoped></style>
