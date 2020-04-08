<template>
  <form id="keepForm" @submit.prevent="createVault">
    <fieldset>
      <div class="form-group">
        <label for="exampleInputEmail1"></label>
        <input
          class="form-control"
          id="KeepName"
          v-model="newVault.name"
          type="text"
          placeholder="Vault Name"
        />
      </div>
      <div class="form-group">
        <label></label>
        <textarea
          class="form-control"
          v-model="newVault.description"
          id="keepDescription"
          placeholder="Vault Description"
          rows="3"
        ></textarea>
      </div>
    </fieldset>

    <button class="btn btn-primary mx-2" @click="createVault" type="button">Create!</button>
    <button class="btn btn-danger mx-2" @click="cancelToggle" type="button">Cancel</button>
  </form>
</template>

<script>
export default {
  name: "keepForm",

  methods: {
    cancelToggle() {
      this.$emit("clicked");
    },

    createVault() {
      this.$store.dispatch("createVault", this.newVault);
      this.$emit("clicked");
    }
  },
  data() {
    return {
      newVault: {}
    };
  }
};
</script>

<style>
</style>