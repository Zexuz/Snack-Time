import { Module } from "vuex";
import { getters } from "./getters";
import { actions } from "./actions";
import { mutations } from "./mutations";
import { StatusState } from "./types";
import { RootState } from "../../types";

export const state: StatusState = {
  isOnline: false
};

const namespaced: boolean = true;

export const status: Module<StatusState, RootState> = {
  namespaced,
  state,
  getters,
  actions,
  mutations
};
