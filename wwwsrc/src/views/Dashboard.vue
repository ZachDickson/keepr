<template>
  <div class="dashboard text-center">
    <h1>This is your stuff!</h1>
    <button
      v-if="!keepFormToggle"
      @click="keepFormToggler"
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
        <keep v-for="(keep, index) in publicKeeps" :key="index" :keepProp="keep" />
      </div>
    </div>
  </div>
</template>

<script>
import keep from "../components/keep";
import vault from "../components/vault";
import keepForm from "../components/keepForm";

export default {
  name: "Dashboard",
  mounted() {
    this.$store.dispatch("getPublicKeeps");
    this.$store.dispatch("getVaults");
  },
  computed: {
    publicKeeps() {
      return this.$store.state.publicKeeps;
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
    }
  },
  components: {
    keep,
    vault,
    keepForm
  },
  data() {
    return {
      keepFormToggle: false
    };
  }
};
</script>

<style></style>
