export interface NotificationState {
  notifications: Notification[];
}

export interface Notification {
  text: string;
  duration: number;
  level: Level;
}

export const enum Level {
  Trace = 0,
  Info = 1,
  Error = 2
}
