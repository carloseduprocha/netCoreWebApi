import axios from 'axios';

const API_BASE_URL = 'http://localhost:5000/';

const configApi = axios.create({
  baseURL: API_BASE_URL
});

export default configApi;