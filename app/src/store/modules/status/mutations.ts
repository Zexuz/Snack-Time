import { MutationTree } from "vuex";
import { StatusState } from "./types";
import { Series } from "@/logic/api/types";

export const enum MutationTypes {
  SET_ONLINE_STATUS = "setOnlineStatus"
}

export const mutations: MutationTree<StatusState> = {
  [MutationTypes.SET_ONLINE_STATUS](state, isOnline: boolean) {
    state.isOnline = isOnline;
  }
};
