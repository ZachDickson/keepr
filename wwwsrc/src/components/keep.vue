<template>
  <div class="col-3">
    <button @click="deleteKeep" class="btn btn-danger"></button>
    <div class="text-right"></div>
    <div id="keepCard" class="card mb-3 shadow p-3 mb-5 bg-black rounded">
      <h3 class="card-header">{{keepProp.name}}</h3>
      <img
        style="height: 10rem; width: 100%; display: block;"
        alt="Card image"
        v-bind:src="keepProp.img"
      />
      <div class="card-body">
        <p class="card-text">{{keepProp.description}}</p>
      </div>
      <ul class="list-group list-group-flush">
        <li
          class="list-group-item"
        >views {{keepProp.views}}, shares {{keepProp.shares}}, keeps {{keepProp.keeps}}</li>
      </ul>

      <div class="dropdown">
        <button
          class="btn btn-success dropdown-toggle"
          type="button"
          id="dropdownMenuButton"
          data-toggle="dropdown"
        >Add to vault</button>
        <div class="dropdown-menu">
          <a
            @click="addKeepToVault(vault.id)"
            v-show="vault.name"
            v-for="vault in vaults"
            :key="vault.id"
            class="dropdown-item"
          >Add to {{vault.name}}</a>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "keep",

  props: ["keepProp", "keepObj"],

  mounted() {},

  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  },

  methods: {
    deleteKeep() {
      this.$store.dispatch("deleteKeep", this.keepProp.id);
    },

    addKeepToVault(vaultId) {
      this.keepProp.keeps++;
      let data = {
        vaultId: vaultId,
        keepId: this.keepProp.id,
        keep: this.keepProp
      };
      this.$store.dispatch("addKeepToVault", data);
      this.$store.dispatch("editKeep", data.keep);
    }
  }
};
</script>

<style>
</style>