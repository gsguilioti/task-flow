<template>
  <Menu></Menu>
  <RouterView/>
</template>

<script>
import { RouterView } from 'vue-router';
import Menu from "./components/Menu.vue";

export default {
  name: 'App',
  components: {
    RouterView,
    Menu
  }
}
</script>

<style>
</style>
