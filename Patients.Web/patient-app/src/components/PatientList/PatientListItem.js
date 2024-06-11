import React from 'react';

const PatientListItem = ({ patient }) => {
    const closestAppointment = patient.appointments.length > 0
        ? patient.appointments.reduce((closest, current) => {
            const closestDate = new Date(closest.date);
            const currentDate = new Date(current.date);
            return currentDate < closestDate ? current : closest;
        })
        : null;

    return (
        <tr>
            <td>{patient.name}</td>
            <td>
                {closestAppointment ? new Date(closestAppointment.date).toLocaleString() : 'None'}
                {closestAppointment ? ` (${closestAppointment.meetingTypeDescription})` : ''}
            </td>
        </tr>
    );
};

export default PatientListItem;
