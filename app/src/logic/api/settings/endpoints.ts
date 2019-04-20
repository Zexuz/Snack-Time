export class Endpoints {
  private static readonly prefix: string = "/api/settings/v1";

  public static GetSettings() {
    return `${this.prefix}`;
  }

  public static SaveSettings() {
    return `${this.prefix}`;
  }
}
