import { Module } from "vuex";
import { getters } from "./getters";
import { actions } from "./actions";
import { mutations } from "./mutations";
import { SeriesState } from "./types";
import { RootState } from "../../types";

export const state: SeriesState = {
  series: []
};

const namespaced: boolean = true;

export const series: Module<SeriesState, RootState> = {
  namespaced,
  state,
  getters,
  actions,
  mutations
};
