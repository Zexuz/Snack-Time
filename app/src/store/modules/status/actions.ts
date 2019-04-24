import { ActionTree } from "vuex";
import { StatusState } from "./types";
import { RootState } from "@/store/types";

export const enum ActionsTypes {
  CHECK_ONLINE_STATUS = "checkOnlineStatus",
}

export const actions: ActionTree<StatusState, RootState> = {
  async [ActionsTypes.CHECK_ONLINE_STATUS]({ commit }) {
  },
};
