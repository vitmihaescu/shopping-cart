<template>
  <v-toolbar app dark fixed clipped-right class="pt-2" color="primary">
    <v-toolbar-title class="font-weight-regular text-uppercase">
      <router-link to="/" tag="span">
        <v-icon>mdi-cart-outline</v-icon>Shopping
        <span class="font-weight-thin">Cart</span>
      </router-link>
    </v-toolbar-title>
    <v-spacer></v-spacer>
    <v-badge overlap color="red darken-4" :value="count" v-show="$route.name == 'home'">
      <template v-slot:badge>
        <span>{{ count }}</span>
      </template>
      <v-toolbar-side-icon @click="showCart(true)">
        <v-icon size="32">mdi-cart</v-icon>
      </v-toolbar-side-icon>
    </v-badge>
  </v-toolbar>
</template>
<script>
import { mapGetters, mapMutations } from 'vuex';

export default {
  computed: mapGetters('cart', ['count']),
  methods: mapMutations('ui', ['showCart'])
};
</script>

<style scoped lang="stylus">
.router-link-active {
  cursor: pointer;
}

.v-toolbar__title, .v-icon {
  color: var(--v-accent-lighten3);
}
</style>
