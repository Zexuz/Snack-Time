export class Endpoints {
  private static readonly prefix: string = "/api/file/v1";

  public static DownloadFile(mediaId: number) {
    return `${this.prefix}/download/${mediaId}`;
  }
  public static GetDownloadedFiles() {
    return `${this.prefix}/local`;
  }
}
