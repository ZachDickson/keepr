<template>
  <div class="dashboard text-center">
    <h1>This is your stuff!</h1>
    <button
      v-if="!vaultFormToggle"
      @click="vaultFormToggler"
      class="btn btn-primary mx-3 my-3"
      type="button"
    >Create a Vault</button>
    <button
      v-if="!keepFormToggle"
      @click="keepFormToggler"
      class="btn btn-primary mx-3 my-3"
      type="button"
    >Create a Keep</button>
    <div class="container-fluid">
      <h1 class="text-left">Vaults</h1>
      <div class="row justify-content-center">
        <div class="col-4">
          <vaultForm v-if="vaultFormToggle" @clicked="cancelVaultToggle" />
        </div>
      </div>
      <div class="row justify-content-center">
        <div class="col-4">
          <keepForm v-if="keepFormToggle" @clicked="cancelKeepToggle" />
        </div>
      </div>
    </div>

    <div class="container-fluid">
      <div class="row" id="keepRow">
        <vault v-for="(vault, index) in vaults" :key="index" :vaultProp="vault" />
      </div>
    </div>
    <div class="container-fluid">
      <h1 class="text-left">Keeps</h1>
      <div class="row" id="keepRow">
        <keep v-for="(keep, index) in keeps" :key="index" :keepProp="keep" />
      </div>
    </div>
  </div>
</template>

<script>
import keep from "../components/keep";
import vault from "../components/vault";
import keepForm from "../components/keepForm";
import vaultForm from "../components/vaultForm";

export default {
  name: "Dashboard",
  mounted() {
    this.$store.dispatch("getUserKeeps");
    this.$store.dispatch("getVaults");
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
    },

    vaults() {
      return this.$store.state.vaults;
    }
  },

  methods: {
    keepFormToggler() {
      this.keepFormToggle = true;
    },
    cancelKeepToggle() {
      this.keepFormToggle = false;
    },

    vaultFormToggler() {
      this.vaultFormToggle = true;
    },
    cancelVaultToggle() {
      this.vaultFormToggle = false;
    }
  },
  components: {
    keep,
    vault,
    keepForm,
    vaultForm
  },
  data() {
    return {
      keepFormToggle: false,
      vaultFormToggle: false
    };
  }
};
</script>

<style></style>
