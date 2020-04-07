<template>
  <div class="home text-center">
    <h1>Welcome to Keepr!</h1>
    <div class="container-fluid">
      <div class="row"></div>
    </div>
  </div>
</template>

<script>
export default {
  name: "home",
  computed: {},
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  }
};
</script>
