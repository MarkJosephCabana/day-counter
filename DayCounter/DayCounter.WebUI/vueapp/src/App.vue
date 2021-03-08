<template>
  <v-app>
    <MainMenu />
    <v-main class="grey lighten-3">
      <v-container class="py-0 fill-height">
        <router-view />
      </v-container>
    </v-main>
  </v-app>
</template>

<script>
import MainMenu from "./components/navigation/MainMenu.vue";

export default {
  name: "App",

  components: {
    MainMenu
  },

  data: () => ({
    //
  })
};
</script>
