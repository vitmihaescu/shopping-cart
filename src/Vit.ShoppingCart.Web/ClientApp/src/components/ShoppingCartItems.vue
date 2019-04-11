<template>
  <v-list class="pa-0">
    <template v-for="(item, index) in items">
      <v-list-tile :key="item.id">
        <v-list-tile-avatar tile>
          <v-img :src="item.image" position="top left" aspect-ratio="1" height="40" />
        </v-list-tile-avatar>
        <v-list-tile-content>
          <v-list-tile-title class="pr-2">{{ item.title }}</v-list-tile-title>
        </v-list-tile-content>
        <v-list-tile-action>
          <input type="number" min="1" max="99" v-model.number="item.count" @change="update(item)" v-mask="'09'" />
        </v-list-tile-action>
        <v-list-tile-action class="pr-1 pl-0">
          <v-btn icon small>
            <v-icon color="grey lighten-1" @click="remove(item)">mdi-close-circle</v-icon>
          </v-btn>
        </v-list-tile-action>
      </v-list-tile>
      <v-divider v-if="index + 1 < items.length" :key="index" />
    </template>
  </v-list>
</template>

<script>
import { mapState, mapMutations } from 'vuex';

export default {
  computed: mapState('cart', ['items']),
  methods: mapMutations('cart', ['update', 'remove'])
};
</script>

<style scoped>
input[type='number'] {
  line-height: normal;
  padding: 2px;
  width: 43px;
  text-align: center;
  border: 1px solid #c0d0db;
}
.v-list__tile__action {
  min-width: 36px;
}
</style>
