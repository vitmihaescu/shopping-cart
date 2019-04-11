import Vue from 'vue';
import Vuex from 'vuex';
import cart from './cart';
import ui from './ui';

Vue.use(Vuex);

export default new Vuex.Store({
  modules: { cart, ui }
});
