import React from 'react';
import PatientContainer from './containers/PatientContainer';
import { PatientProvider } from './context/PatientContext';
import './App.css';

const App = () => {
    return (
        <PatientProvider>
            <div className="App">
                <PatientContainer />
            </div>
        </PatientProvider>
    );
};

export default App;
