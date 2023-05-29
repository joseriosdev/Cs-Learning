const baseURL = 'https://localhost:44334/api/Event/';

async function getAllEvents()
{
    const url = baseURL + 'allEvents/';
    const output = document.getElementById('events-table-body');
    output.innerHTML = '';
    const result = await fetch(url);
    const data = await result.json();
    data.forEach(event => {
        const row = document.createElement('tr');
        row.innerHTML = `
                    <td>${event.id}</td>
                    <td>${event.name}</td>
                    <td>${event.organizedByName}</td>
                    <td>${event.createdDate}</td>
                `;
        output.appendChild(row);
    })
}

document.getElementById('create-form').addEventListener('submit', e => {
    e.preventDefault();
    const name = document.getElementById('new-event-name').value;
    if (name === '' || name === null) {
        window.alert('Please, enter a value');
    }
    else {
        insertEvent(name);
        document.getElementById('new-event-name').value = null;
        setTimeout(getAvailableIds,250);

    }
});

async function insertEvent(evtName)
{
    const url = baseURL + 'insert/' + evtName;
    const options = { method: 'POST' };
    const result = await fetch(url, options);
    const data = await result;
}

async function getAvailableIds()
{
    const availableIdsOutput = Array.from(document.getElementsByClassName('available-ids'));
    const url = baseURL + 'allEvents/';
    let avaliableIdsList = '';
    const result = await fetch(url);
    const data = await result.json();
    data.forEach(e => avaliableIdsList = avaliableIdsList + e.id + ", ");
    availableIdsOutput.forEach(elmt => elmt.innerHTML = avaliableIdsList);
}
getAvailableIds();

async function deleteEvent(id)
{
    const url = baseURL + 'delete/' + id;
    const options = { method: 'DELETE' };
    const result = await fetch(url, options);
}

document.getElementById('delete-form').addEventListener('submit', e => {
    e.preventDefault();
    const id = document.getElementById('delete-by-id').value;
    if (id === 0 || id === null) {
        window.alert('Please, enter a value');
    }
    else {
        deleteEvent(id);
        document.getElementById('delete-by-id').value = null;
        setTimeout(getAvailableIds,250);
    }
});


let _id = 0;
document.getElementById('select-one-form').addEventListener('submit', e => {
    e.preventDefault();
    const id = document.getElementById('select-one').value;
    if (id === 0 || id === null) {
        window.alert('Please, enter a value');
    }
    else {
        getSingle(id).then(res => {
            console.log('inside promese')
            console.log(res)
            document.getElementById('select-one').value = null;
            _id = id;
            document.getElementById('select-one-form').classList.add('d-none');
            document.getElementById('update-form').classList.remove('d-none');
            document.getElementById('new-name').value = res.name;
        });
    }
});


document.getElementById('update-form').addEventListener('submit', e => {
    e.preventDefault();
    const name = document.getElementById('new-name').value;
    if (name === '' || name === null) {
        window.alert('Please, enter a value');
    }
    else {
        updateEvent(name);
        document.getElementById('new-name').value = null;
        document.getElementById('select-one-form').classList.remove('d-none');
        document.getElementById('update-form').classList.add('d-none');
    }
});

async function getSingle(id)
{
    const url = baseURL + id;
    const result = await fetch(url);
    const data = await result.json();
    return data;
}

async function updateEvent(name)
{
    const url = `${baseURL}update/${_id}/${name}`;
    const options = { method: 'PUT' };
    const result = await fetch(url, options);
}