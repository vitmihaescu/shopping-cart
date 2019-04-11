export default {
  get(key) {
    const data = window.localStorage.getItem(key);
    return data ? JSON.parse(data) : null;
  },

  save(key, value) {
    window.localStorage.setItem(key, JSON.stringify(value));
  },

  remove(key) {
    window.localStorage.removeItem(key);
  }
};
