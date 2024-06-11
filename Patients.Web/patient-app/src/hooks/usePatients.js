import { useContext, useEffect } from 'react';
import { PatientContext } from '../context/PatientContext';
import { getPatients, searchPatients } from '../services/patientService';

const usePatients = () => {
    const { state, dispatch } = useContext(PatientContext);
    const { page, pageSize } = state;

    useEffect(() => {
        fetchPatients(page);
    }, [page]);

    const fetchPatients = async (page) => {
        try {
            const response = await getPatients(page, pageSize);
            const totalCount = response.headers['x-total-count'];
            console.log('Total Count:', totalCount); // Debugging log
            dispatch({
                type: 'SET_PATIENTS',
                payload: {
                    patients: response.data,
                    totalPages: Math.ceil(totalCount / pageSize),
                },
            });
        } catch (error) {
            console.error('Error fetching patients:', error);
        }
    };

    const handleSearch = async (query) => {
        try {
            const response = await searchPatients(query);
            dispatch({
                type: 'SET_PATIENTS',
                payload: {
                    patients: response.data,
                    totalPages: 1, // Assuming search results fit in one page
                },
            });
        } catch (error) {
            console.error('Error searching patients:', error);
        }
    };

    const setPage = (newPage) => {
        console.log('Setting Page:', newPage); // Debugging log
        dispatch({ type: 'SET_PAGE', payload: newPage });
    };

    return {
        state,
        fetchPatients,
        handleSearch,
        setPage,
    };
};

export default usePatients;
