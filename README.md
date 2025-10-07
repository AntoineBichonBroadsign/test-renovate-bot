# Test Renovate Bot API

A simple .NET Core Web API with Swagger documentation for testing the Renovate bot.

## Overview

This project demonstrates a basic ASP.NET Core Web API with:
- ✅ Swagger/OpenAPI documentation 
- ✅ Sample Todo CRUD endpoints
- ✅ Weather forecast endpoint (from template)
- ✅ XML documentation comments
- ✅ RESTful API design patterns

## Features

### API Endpoints

#### Todo Management
- `GET /api/todo` - Get all todo items
- `GET /api/todo/{id}` - Get a specific todo item
- `POST /api/todo` - Create a new todo item
- `PUT /api/todo/{id}` - Update an existing todo item
- `DELETE /api/todo/{id}` - Delete a todo item

#### Weather Forecast (Sample)
- `GET /weatherforecast` - Get sample weather forecast data

### Swagger Documentation
- Interactive API documentation available at `/swagger` when running in development mode
- OpenAPI 3.0 specification with comprehensive endpoint descriptions
- XML comments for enhanced documentation

## Getting Started

### Prerequisites
- .NET 8.0 SDK or later

### Running the Application

1. Clone the repository:
```bash
git clone https://github.com/AntoineBichonBroadsign/test-renovate-bot.git
cd test-renovate-bot
```

2. Restore dependencies and build:
```bash
dotnet restore
dotnet build
```

3. Run the application:
```bash
dotnet run
```

4. Open your browser and navigate to:
   - **API**: `http://localhost:5182`
   - **Swagger UI**: `http://localhost:5182/swagger`

### Testing the API

#### Using curl
```bash
# Get all todos
curl http://localhost:5182/api/todo

# Get a specific todo
curl http://localhost:5182/api/todo/1

# Create a new todo
curl -X POST http://localhost:5182/api/todo \
  -H "Content-Type: application/json" \
  -d '{"title":"New Task","description":"Description here","isCompleted":false}'

# Update a todo
curl -X PUT http://localhost:5182/api/todo/1 \
  -H "Content-Type: application/json" \
  -d '{"title":"Updated Task","description":"Updated description","isCompleted":true}'

# Delete a todo
curl -X DELETE http://localhost:5182/api/todo/1

# Get weather forecast
curl http://localhost:5182/weatherforecast
```

#### Using Swagger UI
1. Navigate to `http://localhost:5182/swagger`
2. Explore and test all endpoints interactively
3. View request/response schemas and examples

## Project Structure

```
├── Controllers/
│   └── TodoController.cs      # Todo CRUD operations
├── Models/
│   └── Todo.cs               # Todo data model
├── Properties/
│   └── launchSettings.json   # Development settings
├── Program.cs                # Application entry point
├── TestRenovateBotAPI.csproj # Project file
├── appsettings.json          # Configuration
└── README.md                 # This file
```

## Technology Stack

- **Framework**: ASP.NET Core 8.0
- **Documentation**: Swagger/Swashbuckle
- **API Style**: RESTful
- **Data**: In-memory (for demo purposes)

## Development

### Building
```bash
dotnet build
```

### Running in Development Mode
```bash
dotnet run --environment Development
```

This enables:
- Swagger UI at `/swagger`
- Development exception pages
- Hot reload capabilities

## Contributing

This is a test repository for the Renovate bot. Feel free to create issues and pull requests to test automation features.

## API Documentation Screenshot

![Swagger UI Overview](https://github.com/user-attachments/assets/18b2e90d-b044-4808-9eda-21c9729c140f)

The Swagger UI provides a complete interactive interface for exploring and testing all API endpoints.
