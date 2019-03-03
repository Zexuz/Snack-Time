import { Module } from "vuex";
import { getters } from "./getters";
import { actions } from "./actions";
import { mutations } from "./mutations";
import { EpisodeState } from "./types";
import { RootState } from "../../types";

export const state: EpisodeState = {
  episodes: {}
};

const namespaced: boolean = true;

export const episodes: Module<EpisodeState, RootState> = {
  namespaced,
  state,
  getters,
  actions,
  mutations
};
