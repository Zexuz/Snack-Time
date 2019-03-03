export class Endpoints {

  private static readonly prefix: string = "/api/episode/v1";

  public static GetEpisodesBySeriesId(id: number) {
    return `${this.prefix}/series/${id}`;
  }
  public static GetEpisodeById(id: number) {
    return `${this.prefix}/${id}`;
  }

}
