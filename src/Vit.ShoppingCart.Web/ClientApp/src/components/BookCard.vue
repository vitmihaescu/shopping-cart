<template>
  <v-card hover class="fill-height pa-1 ma-2" width="270" height="400" :img="require('@/assets/img/card-bg.jpg')">
    <v-card-text class="pa-0">
      <v-img position="top left" aspect-ratio="1.35" :src="book.image"></v-img>
      <v-layout>
        <v-flex pt-0>
          <v-rating
            readonly
            dense
            half-increments
            background-color="primary"
            class="py-0 pt-2 ml-2"
            :value="book.rating"
          ></v-rating>
        </v-flex>
        <v-spacer />
        <v-flex text-xs-right pt-2 mt-1 pr-4 title>
          <h4>£{{ book.price.toFixed(2) }}</h4>
        </v-flex>
      </v-layout>
    </v-card-text>
    <v-card-text class="py-0 px-3">
      <div v-if="book.isBestseller" class="ribbon ribbon-top-left">
        <span>Bestseller</span>
      </div>
    </v-card-text>
    <v-card-title class="py-0 pt-1 pb-0">
      <h2>{{ book.name }}</h2>
    </v-card-title>
    <v-card-text class="pt-0 pb-1 grow">
      <div class="subheading">{{ book.author }}</div>
      <div class="caption">{{ book.publisher }}</div>
    </v-card-text>
    <v-card-actions class="px-3 py-0 pb-3">
      <v-btn block dark color="primary" @click="add(book)">Add to cart</v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
import { mapMutations } from 'vuex';

export default {
  props: {
    book: {
      type: Object,
      required: true
    }
  },

  methods: mapMutations('cart', ['add'])
};
</script>

<style lang="stylus" scoped>
h2 {
  line-height: 1.8rem;
  text-shadow: 1px 0 2px #a0aec9;
}

h4 {
  line-height: 1.5rem;
  text-shadow: 1px 0 1px #a0aec9;
  color: var(--v-primary-base);
}

.v-image {
  border-radius: 0.85rem 0.25rem 0 0;
}

.v-card {
  display: flex;
  flex-direction: column;
  border-radius: 0.85rem 0.25rem 0 0;
}

@require '../assets/css/ribbon.css';
</style>
