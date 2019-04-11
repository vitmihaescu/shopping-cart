import Vue from 'vue';
import Storage from '@/services/storage.service';

export default {
  namespaced: true,

  state: {
    items: Storage.get('cart/items') || [],
    orderCode: ''
  },

  getters: {
    count: state => state.items.map(i => i.count).reduce((a, c) => a + c, 0),
    subtotal: state =>
      state.items
        .map(i => i.count * i.price)
        .reduce((a, c) => a + c, 0)
        .toFixed(2)
  },

  mutations: {
    /* eslint-disable no-param-reassign */
    add(state, item) {
      const index = state.items.findIndex(i => i.id === item.id);
      if (index > -1) {
        Vue.set(state.items[index], 'count', state.items[index].count + 1);
        state.items.splice(index, 1, item);
      } else {
        state.items.push(item);
        Vue.set(item, 'count', 1);
      }
      Storage.save('cart/items', state.items);
    },

    update(state, item) {
      const index = state.items.findIndex(i => i.id === item.id);
      if (index > -1) {
        state.items.splice(index, 1, item);
        Storage.save('cart/items', state.items);
      }
    },

    remove(state, item) {
      const index = state.items.findIndex(i => i.id === item.id);
      if (index > -1) {
        state.items.splice(index, 1);
      }
      Storage.save('cart/items', state.items);
    },

    clear(state) {
      state.items = [];
      Storage.remove('cart/items');
    },

    setOrderCode(state, code) {
      state.orderCode = code;
    }
  }
};
