<template>
  <div class="dashboard text-center">
    <h1>This is your stuff!</h1>
    <div class="container-fluid">
      <div class="row" id="keepRow">
        <keep v-for="(keep, index) in publicKeeps" :key="index" :keepProp="keep" />
      </div>
    </div>
  </div>
</template>

<script>
import keep from "../components/keep";

export default {
  name: "Dashboard",
  mounted() {
    this.$store.dispatch("getPublicKeeps");
  },
  computed: {
    publicKeeps() {
      return this.$store.state.publicKeeps;
    }
  },
  components: {
    keep
  }
};
</script>

<style></style>
