import { MutationTree } from "vuex";
import { SeriesState } from "./types";

export const enum MutationTypes {
  SET_SERIES = "setSeries"
}

export const mutations: MutationTree<SeriesState> = {
  [MutationTypes.SET_SERIES](state, series) {
    state.series = series;
  }
};
