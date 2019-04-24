export class Endpoints {
  private static readonly prefix: string = "/api/status/v1";

  public static IsOnline() {
    return `${this.prefix}/isOnline`;
  }
}
