<template>
  <div class="App">
    <MainMenu />
    <v-main>
      <router-view />
    </v-main>
  </div>
</template>

<script>
import MainMenu from "../components/navigation/MainMenu.vue";

export default {
  name: "Layout",
  components: {
    MainMenu,
  },
};
</script>