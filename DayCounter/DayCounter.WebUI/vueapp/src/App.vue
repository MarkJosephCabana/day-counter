<template>
  <v-app>
    <MainMenu />
    <v-main>
      <v-container>
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
    MainMenu,
  },

  data: () => ({
    //
  }),
};
</script>
