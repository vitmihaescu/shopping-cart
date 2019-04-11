import axios from 'axios';

const baseUrl = process.env.BASE_URL;

export default {
  async get(resource) {
    return (await axios.get(`${baseUrl}api/v1/${resource}`)).data;
  },

  async post(resource, data) {
    return (await axios.post(`${baseUrl}api/v1/${resource}`, data)).data;
  },

  async put(resource, data) {
    (await axios.put(`${baseUrl}api/v1/${resource}`, data)).data;
  }
};
