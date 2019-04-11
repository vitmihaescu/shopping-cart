<template>
  <v-footer app fixed class="elevation-3" height="auto">
    <v-bottom-nav :active.sync="activeBtn" :value="showNav" absolute dcolor="transparent">
      <v-btn flat color="primary" to="/">
        <span>Home</span>
        <v-icon>mdi-home</v-icon>
      </v-btn>

      <v-btn flat color="primary" to="about">
        <span>About</span>
        <v-icon>mdi-information-outline</v-icon>
      </v-btn>

      <v-btn href="https://github.com/vitmihaescu/shopping-cart">
        <span>Source</span>
        <v-icon>mdi-github-circle</v-icon>
      </v-btn>
    </v-bottom-nav>
  </v-footer>
</template>
<script>
export default {
  data() {
    return {
      activeBtn: 0,
      showNav: true
    };
  }
};
</script>
