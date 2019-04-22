<template>
  <div class="row">
    <div class="col s12">
      <div class="card">
        <div class="card-content">
          <slot></slot>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component({})
export default class SettingCard extends Vue {}
</script>

<style scoped></style>
