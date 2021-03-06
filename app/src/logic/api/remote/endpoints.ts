export class Endpoints {
  private static readonly prefix: string = "/api/remote/v1";

  public static PlayFile(id: string) {
    return `${this.prefix}/play/${id}`;
  }

  public static PlayFileOnStartPosition(id: string, seconds: number) {
    return `${this.prefix}/play/${id}/${seconds}`;
  }
}
