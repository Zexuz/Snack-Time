import { MutationTree } from "vuex";
import { Notification, NotificationState } from "./types";

export const enum MutationTypes {
  ADD = "add"
}

export const mutations: MutationTree<NotificationState> = {
  [MutationTypes.ADD](state, notification: Notification) {
    state.notifications.push(notification);
  }
};
