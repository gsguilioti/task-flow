<template>
  <div id="app">
    <Menu v-if="showMenu"></Menu>
    <RouterView />
  </div>
</template>

<script>
import { RouterView } from 'vue-router';
import { computed } from 'vue';
import { useRoute } from 'vue-router';
import Menu from "./components/Menu.vue";

export default {
  name: 'App',
  components: {
    RouterView,
    Menu
  },

  setup() {
    const route = useRoute();
    const showMenu = computed(() => {
      return route.name !== 'Login';
    });

    return {
      showMenu
    };
  }
}
</script>

<style scoped>
#app {
  min-height: 100vh;
  display: flex;
  flex-direction: column;
}
</style>
