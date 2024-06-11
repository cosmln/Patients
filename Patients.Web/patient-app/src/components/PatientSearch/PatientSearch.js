import React, { useState } from 'react';

const PatientSearch = ({ onSearch }) => {
    const [query, setQuery] = useState('');

    const handleSearch = (e) => {
        e.preventDefault();
        onSearch(query);
    };

    return (
        <form onSubmit={handleSearch}>
            <input
                type="text"
                value={query}
                onChange={(e) => setQuery(e.target.value)}
                placeholder="Search patients by name or ID"
            />
            <button type="submit">Search</button>
        </form>
    );
};

export default PatientSearch;
