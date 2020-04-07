<template>
  <div class="home text-center">
    <h1>Welcome to Keepr!</h1>
    <button class="btn btn-success" type="button">Create A Keep</button>

    <div class="container-fluid">
      <div class="row">
        <div class="col-2">
          <keep />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import keep from "../components/keep";

export default {
  name: "home",
  computed: {},
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: {
    keep
  }
};
</script>
