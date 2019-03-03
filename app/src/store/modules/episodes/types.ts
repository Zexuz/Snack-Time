import { Episode } from "@/logic/api/episodes/protogen/episodes";

export interface EpisodeState {
  episodes: { [seriesId: number]: Episode[] };
}
