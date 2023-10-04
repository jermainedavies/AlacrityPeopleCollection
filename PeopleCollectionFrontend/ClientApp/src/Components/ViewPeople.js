import { useEffect, useState } from 'react';

function ViewPeople() {

    const [personObjects, setPersonObjects] = useState(0);
    useEffect(() => {
        fetch('https://alacritypeoplecollectionapi.azure-api.net/PeopleCollection/api/Person', {
            method: 'get',
            headers: { 'Content-Type': 'text/plain' },
        })
            .then(response => response.json())
            .then(data => { setPersonObjects(data) })
    }, []);

    if (!personObjects) {
        return <p><em>Loading...</em></p>;
    }
    return (
        <div>
            <h1 id="tabelLabel" >People</h1>
            <p>A list people and their ages.</p>
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Age</th>
                    </tr>
                </thead>
                <tbody>
                    {personObjects.map(personObject =>
                        <tr key={personObject.personId}>
                            <td>{personObject.name}</td>
                            <td>{personObject.age}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>);
}

export { ViewPeople }; 