import { Series } from "@/logic/api/series/protogen/series";

export interface SeriesState {
  series: Series[];
  latestDownloaded: Series[];
}
