export class Endpoints {
  private static readonly prefix: string = "/api/series/v1";

  public static GetSeries() {
    return `${this.prefix}`;
  }

  public static GetSeriesById(id: number) {
    return `${this.prefix}/${id}`;
  }

  public static GetLatest() {
    return `${this.prefix}/last-downloaded`;
  }
}
