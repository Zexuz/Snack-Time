export class ApiResult<T> {
  constructor(public success: boolean, public payload: T, public error: any) {}
}
