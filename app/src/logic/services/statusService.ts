import { HttpClient } from "@/logic/http/httpClient";
import { Endpoints } from "@/logic/api/status/endpoints";

export class StatusService {

  public async isOnline(): Promise<boolean> {
    let res = await HttpClient.get<boolean>(Endpoints.IsOnline());

    if (!res.success || res.error) {
      throw new Error(res.error);
    }

    return res.success;
  }

}