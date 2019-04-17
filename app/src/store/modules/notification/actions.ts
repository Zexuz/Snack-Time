import { ActionTree } from "vuex";
import { Notification, NotificationState } from "./types";
import { RootState } from "../../types";
import { MutationTypes } from "./mutations";

export const enum ActionTypes {
  ADD = "add",
}

export const actions: ActionTree<NotificationState, RootState> = {
  [ActionTypes.ADD]({ commit }, notification: Notification): void {
    commit(MutationTypes.ADD, notification);
  },
};
