<template>
  <div>
    <div class="text-center">
      <h1>{{this.vault.name}}</h1>
    </div>
  </div>
</template>

<script>
export default {
  name: "currentVault",

  mounted() {
    console.log(this.$store.state.currentVault);
  },

  computed: {
    vault() {
      return this.$store.state.currentVault;
    },
    keepData() {
      return this.$store.state.currentVault.keeps;
    }
  }
};
</script>

<style>
</style>