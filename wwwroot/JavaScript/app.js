let shoppingLists = [];
function createShoppingList() {
  
    const shoppingListName = document.getElementById('shoppingListName').value;

    if (shoppingListName.trim() === '') {
        alert('Please enter a valid shopping list name.');
        return;
    }
    const newShoppingList = {
        name: shoppingListName,
        items: [],
        budget: 0, 
        status: 'incomplete', 
    };

    shoppingLists.push(newShoppingList);

    const shoppingListItem = document.createElement('li');
    shoppingListItem.innerHTML = `<div>${shoppingListName}</div><button onclick="viewShoppingListDetails(${shoppingLists.length - 1})">View Details</button>`;

    document.getElementById('shoppingLists').appendChild(shoppingListItem);

    document.getElementById('shoppingListName').value = '';
}
function viewShoppingListDetails(index) {
    const selectedList = shoppingLists[index];

    document.getElementById('shoppingListDetails').innerHTML = `<h3>${selectedList.name}</h3>
                                     <p>Budget: ${selectedList.budget}</p>
                                     <p>Status: ${selectedList.status}</p>`;

    // TODO: Add rendering of item details and status

    // TODO: Add option to modify items, budget, and status
}
function deleteShoppingList(index) {
    // TODO: Implement logic to delete a shopping list
    // You may use shoppingLists.splice(index, 1) to remove the list at the specified index

    renderShoppingLists();
}

// TODO: Implement other capabilities as needed

function renderShoppingLists() {
    const shoppingListsContainer = document.getElementById('shoppingLists');
    shoppingListsContainer.innerHTML = ''; 

    shoppingLists.forEach((list, index) => {
        const listItem = document.createElement('li');
        listItem.innerHTML = `<div>${list.name}</div><button onclick="viewShoppingListDetails(${index})">View Details</button>`;
        shoppingListsContainer.appendChild(listItem);
    });
}

// TODO: Implement other capabilities as needed

renderShoppingLists();
