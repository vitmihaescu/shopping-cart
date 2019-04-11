import Vue from 'vue';
import VueMask from 'di-vue-mask';
import './plugins/vuetify';
import App from './App.vue';
import router from './router';
import store from './store/store';

Vue.config.productionTip = false;

Vue.use(VueMask);

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app');
