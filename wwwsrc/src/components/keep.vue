<template>
  <div class="card mb-3 shadow p-3 mb-5 bg-black rounded">
    <div v-for="keep in publicKeeps" :key="keep.id">
      <h3 class="card-header">{{keep.name}}</h3>
      <img
        style="height: 10rem; width: 100%; display: block;"
        alt="Card image"
        src="https://picsum.photos/200"
      />
      <div class="card-body">
        <p class="card-text">{{keep.description}}</p>
      </div>
      <ul class="list-group list-group-flush">
        <li class="list-group-item">views, shares, keeps</li>
      </ul>
    </div>
  </div>
</template>

<script>
export default {
  name: "keep",

  mounted() {
    this.$store.dispatch("getPublicKeeps");
    console.log(this.$store.state.publicKeeps);
  },

  computed: {
    publicKeeps() {
      return this.$store.state.publicKeeps;
    }
  }
};
</script>

<style>
</style>