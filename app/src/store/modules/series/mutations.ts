import { MutationTree } from "vuex";
import { SeriesState } from "./types";
import { snacktime } from "@/logic/api/types";

export const enum MutationTypes {
  SET_SERIES = "setSeries",
  SET_LATEST_DOWNLOADED = "setLatestDownloadedSeries"
}

export const mutations: MutationTree<SeriesState> = {
  [MutationTypes.SET_SERIES](state, series: snacktime.media.Series[]) {
    state.series = series;
  },
  [MutationTypes.SET_LATEST_DOWNLOADED](state, series: snacktime.media.Series[]) {
    state.latestDownloaded = series;
  }
};
