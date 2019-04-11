<template>
  <v-layout row wrap justify-center>
    <template v-for="book in books">
      <BookCard :book="book" :key="book.id" />
    </template>
  </v-layout>
</template>

<script>
import BookCard from '@/components/BookCard.vue';
import shop from '@/services/shop.service';

export default {
  components: {
    BookCard
  },

  data() {
    return {
      books: []
    };
  },

  async created() {
    try {
      this.books = (await shop.getBookList()).map(b => ({ ...b, image: `img/products/${b.id}.jpg` }));
    } catch (error) {
      // todo: show error
    }
  }
};
</script>
