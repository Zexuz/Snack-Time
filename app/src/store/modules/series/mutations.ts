import { MutationTree } from "vuex";
import { SeriesState } from "./types";
import { Series } from "@/logic/api/series/protogen/series";

export const enum MutationTypes {
  SET_SERIES = "setSeries",
  SET_LATEST_DOWNLOADED = "setLatestDownloadedSeries"
}

export const mutations: MutationTree<SeriesState> = {
  [MutationTypes.SET_SERIES](state, series: Series[]) {
    state.series = series;
  },
  [MutationTypes.SET_LATEST_DOWNLOADED](state, series: Series[]) {
    state.latestDownloaded = series;
  }
};
