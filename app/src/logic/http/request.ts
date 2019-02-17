import { Verb } from "./httpClient";

export class Request {
  public method: string;
  public mode: string;
  public cache: string;
  public credentials: string;
  public headers: { [header: string]: string };
  public redirect: string;
  public referrer: string;
  public body?: string;

  constructor(verb: Verb) {
    this.method = verb.toString();
    this.mode = "cors";
    this.cache = "no-cache";
    this.credentials = "same-origin";
    this.headers = {
      "Content-Type": "application/json; charset=utf-8"
    };
    this.redirect = "follow";
    this.referrer = "no-referrer";
  }
}
