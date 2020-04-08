<template>
  <div class="col-3">
    <div class="text-right">
      <button @click="addKeepToVault" class="btn btn-success"></button>
      <button @click="deleteKeep" class="btn btn-danger"></button>
    </div>
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
    </div>
  </div>
</template>

<script>
export default {
  name: "keep",

  props: ["keepProp"],

  mounted() {},

  computed: {},

  methods: {
    deleteKeep() {
      this.$store.dispatch("deleteKeep", this.keepProp.id);
    },

    addKeepToVault() {
      this.$store.dispatch("addKeepToVault", this.keepProp);
    }
  }
};
</script>

<style>
</style>