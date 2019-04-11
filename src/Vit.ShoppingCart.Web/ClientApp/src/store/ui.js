export default {
  namespaced: true,

  state: {
    checkoutVisible: false,
    cartVisible: false
  },

  mutations: {
    showCart(state, show) {
      state.cartVisible = show;
    },
    showCheckout(state, show) {
      state.checkoutVisible = show;
    }
  }
};
