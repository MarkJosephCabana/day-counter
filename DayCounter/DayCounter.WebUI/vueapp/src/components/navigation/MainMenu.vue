<template>
  <v-navigation-drawer permanent expand-on-hover :mini-variant.sync="mini" app>
    <v-list dense>
      <v-list-item v-for="item in items" :key="item.title" link :to="item.path">
        <v-list-item-icon>
          <v-icon>{{ item.icon }}</v-icon>
        </v-list-item-icon>

        <v-list-item-content>
          <v-list-item-title>{{ item.title }}</v-list-item-title>
        </v-list-item-content>
      </v-list-item>
    </v-list>
  </v-navigation-drawer>
</template>

<script>
export default {
  data() {
    return {
      drawer: true,
      items: [
        { title: "Home", icon: "mdi-home-city", path: "/" },
        { title: "Task 1", icon: "mdi-calendar-today", path: "/task/1" },
        { title: "Task 2", icon: "mdi-calendar-today", path: "/task/2" },
        { title: "Task 3", icon: "mdi-calendar-today", path: "/task/3" },
      ],
      mini: true,
    };
  },
};
</script>