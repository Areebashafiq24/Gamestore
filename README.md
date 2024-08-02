# GameStore API

## Project Overview

GameStore is a web API designed to manage a collection of games. It provides endpoints to create, retrieve, update, and delete game entries. The application uses SQLite for data storage and Entity Framework Core for database operations.

## Table of Contents

- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)
  - [Retrieve All Games](#retrieve-all-games)
  - [Retrieve Game by ID](#retrieve-game-by-id)
  - [Create a New Game](#create-a-new-game)
  - [Update a Game](#update-a-game)
  - [Delete a Game](#delete-a-game)
- [Database Setup](#database-setup)
- [Running the Application](#running-the-application)

## Getting Started

To get started with the GameStore API, follow these steps:

1. **Clone the Repository**

   Use the following command to clone the repository:

   ```sh
   git clone https://github.com/Areebashafiq24/GameStore.git
   cd GameStore/GameStore.Api

2. **Install Dependencies**
   Ensure you have .NET SDK installed. Install the necessary tools with:

   ```sh

   dotnet tool install --global dotnet-ef


3. **API ENDPOINTS**
   **Retrieve All Games**
   URL: /games
   
   Method: GET
   
   Description: Retrieve a list of all games.
   
   Response: A list of game objects.
   
   **Retrieve Game by ID**
   
   URL: /games/{id}
   
   Method: GET
   
   Description: Retrieve a game by its ID.
   
   Response: The game object with the specified ID or a 404 Not Found if the game does not exist.
   
   **Create a New Game**
   
   URL: /games

   Method: POST

   Description: Add a new game to the collection.

   ```sh
   "name": "Game Name",
   "genre": "Game Genre",
   "price": 19.99,
   "releaseDate": "YYYY-MM-DD"

  
Response: The created game object with a 201 Created status, including the location of the newly created game.
    
   **Update a game**
   URL: /games/{id}

   Method: PUT

   Description: Update an existing game's information.

   Request Body:
      
   ```sh
   "name": "Game Name",
   "genre": "Game Genre",
   "price": 19.99,
   "releaseDate": "YYYY-MM-DD"
   ```
  
Response: The created game object with a 201 Created status, including the location of the newly created game.

**Delete a Game**

URL: /games/{id}

Method: DELETE

Description: Delete a game by its ID.

Response: A 204 No Content status if the deletion was successful or a 404 Not Found if the game does not exist.


## Database Setup
The application uses SQLite for data storage. To initialize the database and apply migrations, follow these steps:

 1.**Add Migration**

Run the following command to create a new migration:
```sh
dotnet ef migrations add InitialCreate --output-dir Data\Migrations
```

 2.**Update Database**

 Apply the migration to the database with:
  ```sh
dotnet ef database update
```

**Running the Application**
To start the GameStore API:

Start the Application

Use the following command to run the application:
```sh
dotnet run
```

**Configuration**
The application configuration is located in appsettings.json. The default SQLite database connection string is set as follows:
```sh
{
  "ConnectionStrings": {
    "GameStore": "Data Source=GameStore.db"
  }
}
```
















              
  
