<template>
  <v-container grid-list-lg mb-3>
    <BookList />
    <ShoppingCart />
    <Checkout />
  </v-container>
</template>

<script>
import BookList from '@/components/BookList.vue';

export default {
  components: {
    BookList,
    Checkout: () => import('@/components/Checkout.vue'),
    ShoppingCart: () => import('@/components/ShoppingCart.vue')
  }
};
</script>
