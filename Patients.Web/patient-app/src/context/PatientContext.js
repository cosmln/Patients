import React, { createContext, useReducer } from 'react';

const initialState = {
    patients: [],
    totalPages: 0,
    page: 1,
    pageSize: 10,
};

const PatientContext = createContext(initialState);

const patientReducer = (state, action) => {
    switch (action.type) {
        case 'SET_PATIENTS':
            return {
                ...state,
                patients: action.payload.patients,
                totalPages: action.payload.totalPages,
            };
        case 'SET_PAGE':
            return {
                ...state,
                page: action.payload,
            };
        default:
            return state;
    }
};

const PatientProvider = ({ children }) => {
    const [state, dispatch] = useReducer(patientReducer, initialState);

    return (
        <PatientContext.Provider value={{ state, dispatch }}>
            {children}
        </PatientContext.Provider>
    );
};

export { PatientContext, PatientProvider };
