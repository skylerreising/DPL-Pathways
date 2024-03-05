const uri = 'api/homes';
let homes = [];

function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}

function addItem() {
    const addNameTextbox = document.getElementById('add-name');
    const addBedrooms = document.getElementById('add-bedrooms');
    const addBathrooms = document.getElementById('add-bathrooms');
    const addSquareFootage = document.getElementById('add-squareFootage');

    const item = {
        isComplete: false,
        address: addNameTextbox.value.trim(),
        bedrooms: addBedrooms.value.trim(),
        bathrooms: addBathrooms.value.trim(),
        squareFootage: addSquareFootage.value.trim()
    }

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then(() => {
            getItems();
            addNameTextbox.value = '';
            addBedrooms.value = 0;
            addBathrooms.value = 0;
            addSquareFootage.value = 0;
        })
        .catch(error => console.error('Unable to add item.', error));
}

function deleteItem(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to delete item.', error));
}

function displayEditForm(id) {
    const item = homes.find(item => item.id === id);

    document.getElementById('edit-name').value = item.address;
    document.getElementById('edit-id').value = item.id;
    document.getElementById('edit-isComplete').checked = item.isComplete;
    document.getElementById('edit-bedrooms').value = item.bedrooms;
    document.getElementById('edit-bathrooms').value = item.bathrooms;
    document.getElementById('edit-squareFootage').value = item.squareFootage;
    document.getElementById('editForm').style.display = 'block';
}

function updateItem() {
    const itemId = document.getElementById('edit-id').value;
    const item = {
        id: parseInt(itemId, 10),
        isComplete: document.getElementById('edit-isComplete').checked,
        address: document.getElementById('edit-name').value.trim(),
        bedrooms: document.getElementById('edit-bedrooms').value,
        bathrooms: document.getElementById('edit-bathrooms').value,
        squareFootage: document.getElementById('edit-squareFootage').value
    };

    fetch(`${uri}/${itemId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to update item.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function _displayCount(itemCount) {
    const name = (itemCount === 1) ? 'Potential Home' : 'Potential Homes';

    document.getElementById('counter').innerText = `${itemCount} ${name}`;
}

function _displayItems(data) {
    const tBody = document.getElementById('homes');
    tBody.innerHTML = '';

    _displayCount(data.length);

    const button = document.createElement('button');

    data.forEach(item => {
        let isCompleteCheckbox = document.createElement('input');
        isCompleteCheckbox.type = 'checkbox';
        isCompleteCheckbox.disabled = true;
        isCompleteCheckbox.checked = item.isComplete;

        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${item.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        td1.appendChild(isCompleteCheckbox);

        let td2 = tr.insertCell(1);
        let textNode = document.createTextNode(item.address);
        td2.appendChild(textNode);

        let td3 = tr.insertCell(2);
        let bedrooms = document.createTextNode(item.bedrooms);
        td3.appendChild(bedrooms);

        let td4 = tr.insertCell(3);
        let bathrooms = document.createTextNode(item.bathrooms);
        td4.appendChild(bathrooms);

        let td5 = tr.insertCell(4);
        let squareFootage = document.createTextNode(item.squareFootage +" sq ft");
        td5.appendChild(squareFootage);

        let td11 = tr.insertCell(5);
        td11.appendChild(editButton);

        let td12 = tr.insertCell(6);
        td12.appendChild(deleteButton);
    });

    homes = data;
}