import { Series } from "@/logic/api/types";

export interface SeriesState {
  series: Series[];
  latestDownloaded: Series[];
}
