export class UrlHelper {
  public static getUrl(url: string): string {
    if (process.env.VUE_APP_SERVER_BASE_URL) {
      return process.env.VUE_APP_SERVER_BASE_URL + url;
    }

    return url;
  }
}
