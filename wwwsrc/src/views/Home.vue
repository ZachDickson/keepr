<template>
  <div class="home text-center">
    <h1>Welcome to Keepr!</h1>
    <button
      v-if="!keepFormToggle"
      @click="keepFormToggle = true"
      class="btn btn-primary"
      type="button"
    >Create a Keep</button>
    <div class="container-fluid">
      <div class="row justify-content-center">
        <div class="col-4">
          <keepForm v-if="keepFormToggle" v-on:cancelToggle="keepFormToggler" />
        </div>
      </div>
    </div>
    <div class="container-fluid">
      <div class="row" id="keepRow">
        <keep v-for="keep in publicKeeps" :key="keep.id" :keepProp="keep" />
      </div>
    </div>
  </div>
</template>

<script>
import keep from "../components/keep";
import keepForm from "../components/keepForm";

export default {
  name: "home",

  mounted() {
    this.$store.dispatch("getPublicKeeps");
  },

  computed: {
    publicKeeps() {
      return this.$store.state.publicKeeps;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    keepFormToggler() {
      this.keepFormToggle = false;
    },
    cancelToggle() {
      this.keepFormToggle = false;
    }
  },
  components: {
    keep,
    keepForm
  },
  data() {
    return {
      keepFormToggle: false
    };
  }
};
</script>

<style>
</style>
