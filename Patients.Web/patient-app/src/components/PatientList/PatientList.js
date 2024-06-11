import React from 'react';
import PatientListItem from './PatientListItem';

const PatientList = ({ patients }) => (
    <table>
        <thead>
            <tr>
                <th>Name</th>
                <th>Next Appointment</th>
            </tr>
        </thead>
        <tbody>
            {patients.map(patient => (
                <PatientListItem key={patient.id} patient={patient} />
            ))}
        </tbody>
    </table>
);

export default PatientList;
