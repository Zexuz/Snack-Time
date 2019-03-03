import { MutationTree } from "vuex";
import { EpisodeState } from "./types";
import Vue from "vue";

export const enum MutationTypes {
  SET_EPISODES = "setEpisodes"
}

export const mutations: MutationTree<EpisodeState> = {
  [MutationTypes.SET_EPISODES](state, data) {
    Vue.set(state.episodes, data.seriesId, data.episodes);
  }
};
