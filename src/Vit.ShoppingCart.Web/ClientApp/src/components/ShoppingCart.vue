<template>
  <v-dialog v-model="visible" scrollable origin="top center 0" max-width="480" min-height="680">
    <template v-slot:activator="{ on }">
      <v-btn v-show="false" v-on="on"></v-btn>
    </template>
    <v-card>
      <ShoppingCartHeader @close="show = false" />
      <v-card-text v-if="count" class="pa-1 pt-1 pr-1">
        <ShoppingCartItems />
      </v-card-text>
      <v-card-text v-else>
        <v-flex xs-12 py-4 text-xs-center subheading red--text text--lighten-2>Your Shopping Cart is empty.</v-flex>
      </v-card-text>
      <v-card-actions class="justify-center py-3 elevation-5">
        <v-btn color="primary" class="px-5" :disabled="!count" @click="checkout">Proceed to Checkout</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
import { mapGetters, mapMutations, mapState } from 'vuex';
import ShoppingCartHeader from './ShoppingCartHeader.vue';
import ShoppingCartItems from './ShoppingCartItems.vue';
import shop from '@/services/shop.service';

export default {
  components: {
    ShoppingCartHeader,
    ShoppingCartItems
  },

  computed: {
    ...mapState('ui', ['cartVisible']),
    ...mapState('cart', ['items']),
    ...mapGetters('cart', ['count']),
    visible: {
      get: function() {
        return this.cartVisible;
      },
      set: function(newValue) {
        this.showCart(newValue);
      }
    }
  },

  methods: {
    ...mapMutations('ui', ['showCheckout', 'showCart']),
    ...mapMutations('cart', ['setOrderCode']),

    async checkout() {
      const orderItems = this.items.map(item => ({
        productId: item.id,
        count: item.count
      }));
      try {
        const order = await shop.createOrder(orderItems);
        this.setOrderCode(order.orderCode);
        this.showCart(false);
        this.showCheckout(true);
      } catch (error) {
        // todo: set error state
      }
    }
  }
};
</script>
