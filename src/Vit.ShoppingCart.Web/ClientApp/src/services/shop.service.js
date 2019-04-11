import Api from '@/services/api.service';

export default {
  PaymentStatus: {
    Authorized: 1,
    Declined: 401
  },

  getBookList() {
    return Api.get('books');
  },
  createOrder(items) {
    return Api.post('orders', items);
  },
  authorizePayment(orderId) {
    return Api.put('payments', { orderId: orderId, status: this.PaymentStatus.Authorized });
  },
  declinePayment(orderId) {
    return Api.put('payments', { orderId: orderId, status: this.PaymentStatus.Declined });
  }
};
