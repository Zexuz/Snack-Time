<template>
  <div id="app">
    <nav-bar />
    <router-view />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import "materialize-css/dist/css/materialize.min.css";
import "tiny-slider/dist/tiny-slider.css";
import NavBar from "./components/NavBar.vue";
import M from "materialize-css";

@Component({
  components: { NavBar }
})
export default class App extends Vue {
  mounted() {
    M.AutoInit();
  }
}
</script>

<style lang="less">
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}
</style>
