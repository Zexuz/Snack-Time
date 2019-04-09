import { GetterTree } from "vuex";
import { EpisodeState } from "./types";
import { RootState } from "@/store/types";
import { Episode } from "@/logic/api/episodes/protogen/episodes";

export const enum Methods {
  GET_SEASONS = "getSeason"
}

export const getters: GetterTree<EpisodeState, RootState> = {
  [Methods.GET_SEASONS](state: EpisodeState): (seriesId: number) => Season[] {
    return seriesId => {
      let seasons: Season[] = [];

      let episodes = state.episodes[seriesId];

      if (!episodes || episodes.length == 0) {
        return seasons;
      }

      let seasonsMap: { [seasonNr: number]: Episode[] } = {};
      for (let i = 0; i < episodes.length; i++) {
        let episode = episodes[i];

        if (!(episode.seasonNumber in seasonsMap)) {
          seasonsMap[episode.seasonNumber] = [];
        }

        seasonsMap[episode.seasonNumber].push(episode);
      }

      for (let seasonNr in seasonsMap) {
        seasons.push(new Season(Number(seasonNr), seasonsMap[seasonNr].reverse()));
      }

      return seasons.reverse();
    };
  }
};

export class Season {
  constructor(public number: number, public episodes: Episode[]) {}

  public addEpisode(episode: Episode) {
    this.episodes.push(episode);
  }
}
