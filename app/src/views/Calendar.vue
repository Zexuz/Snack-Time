<template>
  <div class="row">
    <div class="col s12 l3 card blue-grey darken-1">
      <div class="card-content white-text">
        <div class="row">
          <span class="card-title grey-text col s12">
            Feb 18, 21:45
          </span>
          <span class="card-title col s12">
            The office - S05E04
          </span>
        </div>
        <p>
          Andy returns after three months to an angry office and an even angrier
          girlfriend, and Jim's Valentines Day with Pam does not go as planned.
        </p>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component({
  components: {}
})
export default class Calendar extends Vue {}
</script>

<style scoped lang="less">
.card-content {
  overflow: hidden;
  margin-left: 0;
}

img {
  margin-right: 2rem;
}
</style>
