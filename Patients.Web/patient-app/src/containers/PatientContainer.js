import React from 'react';
import PatientList from '../components/PatientList/PatientList';
import PatientSearch from '../components/PatientSearch/PatientSearch';
import Pagination from '../components/Pagination/Pagination';
import usePatients from '../hooks/usePatients';

const PatientContainer = () => {
    const { state, fetchPatients, handleSearch, setPage } = usePatients();
    const { patients, page, totalPages } = state;

    return (
        <div>
            <h1>Patient List</h1>
            <PatientSearch onSearch={handleSearch} />
            <PatientList patients={patients} />
            <Pagination page={page} setPage={setPage} totalPages={totalPages} />
        </div>
    );
};

export default PatientContainer;
