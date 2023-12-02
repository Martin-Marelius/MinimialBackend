# Dynamic CRUD API

This repository provides a CRUD (Create, Read, Update, Delete) API for dynamic types. It allows for quick testing of frontend applications by providing a dynamically typed REST API that can store values and perform various methods.

## Table of Contents

- [Features](#features)
- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)
- [Examples](#examples)
- [Contributing](#contributing)
- [License](#license)

## Features

- Supports CRUD operations for dynamic types.
- Provides RESTful API endpoints for quick testing.
- Dynamically typed to allow flexibility in storing and retrieving data.

## Getting Started

To use this CRUD API, follow these steps:

1. Clone the repository:

   ```bash
   git clone https://github.com/Martin-Marelius/MinimialBackend.git
   ```

2. Build and run the API:

   ```bash
   dotnet build
   dotnet run
   ```

   The API will be accessible at `http://localhost:5000`.

## API Endpoints

The API provides the following endpoints:

- `GET /GetAll`: Retrieve all entries.
- `GET /GetById/{id}/{type}`: Retrieve an entry by ID and type.
- `GET /GetByType/{type}`: Retrieve all entries of a specific type.
- `POST /Add/{id}/{type}`: Add a new entry.
- `PUT /Update/{id}/{type}`: Update an existing entry.
- `DELETE /Delete/{id}/{type}`: Delete an entry by ID and type.

## Examples

### Retrieve all entries:

```bash
curl http://localhost:5000/GetAll
```

### Retrieve an entry by ID and type:

```bash
curl http://localhost:5000/GetById/1/person
```

### Retrieve all entries of a specific type:

```bash
curl http://localhost:5000/GetByType/person
```

### Add a new entry:

```bash
curl -X POST -H "Content-Type: application/json" -d '{"name": "John", "age": 25}' http://localhost:5000/Add/1/person
```

### Update an existing entry:

```bash
curl -X PUT -H "Content-Type: application/json" -d '{"name": "John Doe", "age": 26}' http://localhost:5000/Update/1/person
```

### Delete an entry by ID and type:

```bash
curl -X DELETE http://localhost:5000/Delete/1/person
```

## Contributing

Feel free to contribute to this project. Please follow the [Contribution Guidelines](CONTRIBUTING.md).

## License

This project is licensed under the [MIT License](LICENSE).
