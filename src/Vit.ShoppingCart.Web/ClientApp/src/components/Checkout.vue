<template>
  <v-dialog v-model="visible" persistent scrollable origin="top center 0" max-width="480" min-height="680">
    <v-card>
      <v-card-title class="headline grey lighten-2 py-2 primary--text">
        <v-icon color="primary text--lighten-2" size="32" class="mr-2">mdi-credit-card</v-icon>Payment Simulation
        <v-spacer />
        <v-tooltip bottom>
          <template v-slot:activator="{ on }">
            <v-btn icon flat class="mr-0" @click.stop="close" v-on="on">
              <v-icon>mdi-exit-to-app</v-icon>
            </v-btn>
          </template>
          <span>Cancel</span>
        </v-tooltip>
      </v-card-title>

      <v-card-text class="pa-4 pt-1 pr-1">
        <div>Order Code: {{ orderCode }}</div>
        <div>Order Amount: {{ subtotal }}</div>
      </v-card-text>

      <v-card-actions class="justify-center py-3 elevation-5">
        <v-btn color="primary" @click.stop="authorize">Authorize</v-btn>
        <v-btn color="primary" @click.stop="decline">Decline</v-btn>
        <v-btn @click.stop="close">Cancel</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
import { mapState, mapGetters, mapMutations } from 'vuex';
import shop from '@/services/shop.service';

export default {
  computed: {
    ...mapState('ui', ['checkoutVisible']),
    ...mapState('cart', ['orderCode']),
    ...mapGetters('cart', ['subtotal']),
    visible: {
      get: function() {
        return this.checkoutVisible;
      },
      set: function(newValue) {
        this.showCheckout(newValue);
      }
    }
  },

  methods: {
    ...mapMutations('ui', ['showCheckout', 'showCart']),
    ...mapMutations('cart', ['clear']),
    async authorize() {
      await shop.authorizePayment(this.orderCode);
      this.clear();
      this.showCheckout(false);
    },
    async decline() {
      await shop.declinePayment(this.orderCode);
      this.showCheckout(false);
    },
    close() {
      this.showCheckout(false);
      this.showCart(true);
    }
  }
};
</script>
