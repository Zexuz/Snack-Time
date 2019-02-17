import { Request } from "./request";

import { ApiResult } from "./apiResponse";

import { UrlHelper } from "./urlHelper";

export enum Verb {
  GET = "GET",
  PUT = "PUT",
  POST = "POST",
  DELETE = "DELETE"
}

export class HttpClient {
  public static async get<T>(url: string): Promise<ApiResult<T>> {
    return this.api<T>(Verb.GET, url);
  }

  public static async post<T>(url: string, data?: object): Promise<ApiResult<T>> {
    return this.api<T>(Verb.POST, url, data);
  }

  public static async put<T>(url: string, data?: object): Promise<ApiResult<T>> {
    return this.api<T>(Verb.PUT, url, data);
  }

  public static async delete<T>(url: string, data?: object): Promise<ApiResult<T>> {
    return this.api<T>(Verb.DELETE, url, data);
  }

  public static async api<T>(verb: Verb, url: string, data?: object): Promise<ApiResult<T>> {
    url = UrlHelper.getUrl(url);

    const request = this.createRequest(verb, data);
    const response = await fetch(url, request);

    if (!response.ok) {
      throw new Error(response.statusText);
    }

    const json = await response.json();
    let parsedResult: ApiResult<T>;
    try {
      parsedResult = (json as unknown) as ApiResult<T>;
    } catch (e) {
      throw new Error(`Can't convert type for request ${verb}: ${url}, json: ${JSON.stringify(json)}`);
    }
    if (!parsedResult.success) {
      throw new Error(JSON.stringify(parsedResult.error));
    }
    return parsedResult;
  }

  private static createRequest(verb: Verb, data?: object): any {
    const request = new Request(verb);

    if (verb !== Verb.GET && !!data) {
      request.body = JSON.stringify(data);
    }

    return request;
  }
}
