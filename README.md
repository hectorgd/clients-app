# Clients-app

## Description

This application is a client management system built with C# and .NET. It allows users to create, update, and delete client records.

## Features

- Create a new client
- Update an existing client
- Delete a client

## Setup and Installation

1. Clone the repository
2. Open the solution in a IDE
3. Build the solution
4. Run the application

## Usage

### Create a new client

To create a new client, send a POST request to the `/clients` endpoint with the client's details in the request body.

### Update a client

To update a client, send a PUT request to the `/clients/{id}` endpoint with the updated details in the request body.

### Delete a client

To delete a client, send a DELETE request to the `/clients/{id}` endpoint.

## Testing

This application includes unit tests for the `ClientCommandHandler` class. To run the tests, use the test runner in JetBrains Rider.

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.
