import { ActionTree } from "vuex";
import { SeriesState } from "./types";
import { RootState } from "@/store/types";
import { HttpClient } from "@/logic/http/httpClient";
import { Series } from "@/logic/api/types";
import { Endpoints } from "@/logic/api/series/endpoints";
import { MutationTypes } from "@/store/modules/series/mutations";

export const enum ActionsTypes {
  FETCH_SERIES = "fetchSeries",
  FETCH_LATEST_DOWNLOADED = "fetchLatest"
}

export const actions: ActionTree<SeriesState, RootState> = {
  async [ActionsTypes.FETCH_SERIES]({ commit }) {
    let res = await HttpClient.get<Series[]>(Endpoints.GetSeries());

    if (!res.success || res.error) {
      throw new Error(res.error);
    }

    commit(MutationTypes.SET_SERIES, res.payload);
  },
  async [ActionsTypes.FETCH_LATEST_DOWNLOADED]({ commit }) {
    let res = await HttpClient.get<Series[]>(Endpoints.GetLatest());

    if (!res.success || res.error) {
      throw new Error(res.error);
    }

    commit(MutationTypes.SET_LATEST_DOWNLOADED, res.payload);
  }
};
