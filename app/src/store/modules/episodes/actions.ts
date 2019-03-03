import { ActionTree } from "vuex";
import { EpisodeState } from "./types";
import { RootState } from "@/store/types";
import { HttpClient } from "@/logic/http/httpClient";
import { Endpoints } from "@/logic/api/episodes/endpoints";
import { MutationTypes } from "@/store/modules/episodes/mutations";
import { Episode } from "@/logic/api/episodes/protogen/episodes";

export const enum ActionTypes {
  FETCH_EPISODES = "fetchEpisodes",
  FETCH_EPISODE = "fetchEpisode"
}

export const actions: ActionTree<EpisodeState, RootState> = {
  async [ActionTypes.FETCH_EPISODES]({ commit }, seriesId: number) {
    let res = await HttpClient.get<Episode[]>(Endpoints.GetEpisodesBySeriesId(seriesId));

    if (!res.success || res.error) {
      throw new Error(res.error);
    }

    commit(MutationTypes.SET_EPISODES, { episodes: res.payload, seriesId: seriesId });
  }
};
