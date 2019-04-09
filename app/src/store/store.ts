import Vue from "vue";
import Vuex, { StoreOptions } from "vuex";
import { series } from "./modules/series";
import { episodes } from "./modules/episodes";
import { RootState } from "./types";
import { actions } from "./actions";
import { mutations } from "./mutations";

Vue.use(Vuex);

export const enum Module {
  SERIES = "series",
  EPISODES = "episodes"
}

const storage: StoreOptions<RootState> = {
  state: {
    errors: []
  },
  actions,
  mutations,
  modules: {
    [Module.SERIES]: series,
    [Module.EPISODES]: episodes
  }
};

export const store = new Vuex.Store<RootState>(storage);
