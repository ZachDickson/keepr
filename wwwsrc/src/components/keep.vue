<template>
  <div class="col-2 card mb-3 shadow p-3 mb-5 bg-black rounded mx-3 my-3">
    <i class="fas fa-plus-circle"></i>
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
</template>

<script>
export default {
  name: "keep",

  props: ["keepProp"],

  mounted() {
    console.log(this.$store.state.publicKeeps);
  },

  computed: {}
};
</script>

<style>
</style>