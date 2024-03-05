/**
 * @jest-environment jsdom
 */
const { addItem } = require('../wwwroot/js/site.js');
require('jest-fetch-mock').enableMocks();

describe('addItem test suite', () => {
    beforeEach(() => {
        fetch.resetMocks();
        document.body.innerHTML = `
        <!-- Mock container expected by _displayItems -->
        <table>
            <tbody id="homes"></tbody>
        </table>
        <div id="counter"></div> <!-- Mock element for _displayCount -->
        <input id="add-name" value="8211 S. 63rd St" />
        <input id="add-bedrooms" value="2" />
        <input id="add-bathrooms" value="2.5" />
        <input id="add-squareFootage" value="1800" />
        <!-- Add any other elements required by addItem or other functions -->
    `;
    });

    it('successfully adds an item', async () => {
        // Mock the fetch response for addItem
        fetch.mockResponses(
            [JSON.stringify({ id: 1, address: "8211 S. 63rd St", isComplete: false, bedrooms:2, bathrooms:2.5, squareFootage:1800 }), { status: 201 }],
            [JSON.stringify([{ id: 1, address: "8211 S. 63rd St", isComplete: false, bedrooms:2, bathrooms:2.5, squareFootage:1800 }]), { status: 200 }] // Assuming this is the expected response for getItems()
        );

        // Call addItem
        addItem(); // Adjust this if addItem is asynchronous

        // Wait for any asynchronous operations to complete
        // This is important if addItem involves async operations
        await new Promise(process.nextTick);

        // Assertions to verify the fetch was called correctly
        expect(fetch).toHaveBeenCalledTimes(2);
        expect(fetch).toHaveBeenCalledWith("api/homes", expect.objectContaining({
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                isComplete:false,
                address:'8211 S. 63rd St',
                bedrooms:2,
                bathrooms:2.5,
                squareFootage:1800
            })
        }));

        // Add any other assertions here, such as checking the DOM
        // or verifying the state after the fetch operation
    });
});
