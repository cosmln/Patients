import axios from 'axios';

const API_URL = 'http://localhost:5003/api/Patients';

const getPatients = (page, pageSize) => {
    return axios.get(`${API_URL}?page=${page}&pageSize=${pageSize}`);
};

const searchPatients = (query) => {
    return axios.get(`${API_URL}/search?query=${query}`);
};

export { getPatients, searchPatients };
