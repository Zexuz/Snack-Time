import Vue from "vue";
import Vuex, { StoreOptions } from "vuex";
import { series } from "./modules/series";
import { episodes } from "./modules/episodes";
import { notifications } from "./modules/notification";
import { RootState } from "./types";
import { actions } from "./actions";
import { mutations } from "./mutations";

Vue.use(Vuex);

export const enum Module {
  SERIES = "series",
  EPISODES = "episodes",
  NOTIFICATIONS = "notifications"
}

const storage: StoreOptions<RootState> = {
  state: {
    errors: []
  },
  actions,
  mutations,
  modules: {
    [Module.SERIES]: series,
    [Module.EPISODES]: episodes,
    [Module.NOTIFICATIONS]: notifications
  }
};

export const store = new Vuex.Store<RootState>(storage);
