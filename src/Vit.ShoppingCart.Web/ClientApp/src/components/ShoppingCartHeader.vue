<template>
  <v-card-title class="headline grey lighten-2 py-2 primary--text">
    <v-icon color="primary text--lighten-2" size="32" class="mr-2">mdi-cart</v-icon>
    £{{ subtotal }}
    <v-spacer />
    <v-tooltip bottom>
      <template v-slot:activator="{ on }">
        <v-btn icon flat color="secondary" @click.stop="clear" v-on="on" :disabled="!count">
          <v-icon>mdi-cart-off</v-icon>
        </v-btn>
      </template>
      <span>Clear cart</span>
    </v-tooltip>
    <v-tooltip bottom>
      <template v-slot:activator="{ on }">
        <v-btn icon flat class="mr-0" @click.stop="showCart(false)" v-on="on">
          <v-icon>mdi-exit-to-app</v-icon>
        </v-btn>
      </template>
      <span>Close</span>
    </v-tooltip>
  </v-card-title>
</template>

<script>
import { mapGetters, mapMutations } from 'vuex';

export default {
  computed: mapGetters('cart', ['count', 'subtotal']),
  methods: {
    ...mapMutations('cart', ['clear']),
    ...mapMutations('ui', ['showCart'])
  }
};
</script>
