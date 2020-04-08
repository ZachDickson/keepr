import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    publicKeeps: [],
    keeps: [],
    vaults: []
  },


  mutations: {

    setPublicKeeps(state, publicKeeps) {
      state.publicKeeps = publicKeeps.filter(pk => !pk.isPrivate)
    },

    setUserKeeps(state, keeps) {
      state.keeps = keeps
    },

    createKeep(state, keep) {
      state.publicKeeps.push(keep)
    },

    deleteKeep(state, keepId) {
      state.publicKeeps = state.publicKeeps.filter(pk => pk.id != keepId)
    },

    setVaults(state, vault) {
      state.vaults = vault
    }
  },



  actions: {
    setBearer({ }, bearer) {
      api.defaults.headers.authorization = bearer;
    },

    resetBearer() {
      api.defaults.headers.authorization = "";
    },

    async getPublicKeeps({ commit }) {
      try {
        let res = await api.get("keeps")
        commit("setPublicKeeps", res.data)
      } catch (error) {
        console.error(error);
      }
    },

    async createKeep({ commit }, keep) {
      try {
        let res = await api.post("keeps", keep)
        commit("createKeep", res.data)
      } catch (error) {
        console.error(error);
      }
    },

    async deleteKeep({ commit }, keepId) {
      try {
        let res = await api.delete(`keeps/${keepId}`)
        commit("deleteKeep", keepId)
      } catch (error) {
        console.error();
      }
    },


    async getVaults({ commit }) {
      try {
        let res = await api.get("vaults")
        commit("setVaults", res.data)
      } catch (error) {
        console.error(error);
      }
    }


  }
});
