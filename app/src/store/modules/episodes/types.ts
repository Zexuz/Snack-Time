import { Episode } from "@/logic/api/types";

export interface EpisodeState {
  episodes: { [seriesId: number]: Episode[] };
}
