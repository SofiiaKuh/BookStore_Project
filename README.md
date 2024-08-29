# BookStore_Project
Application Description
The BookStore Project is a RESTful web application designed to manage a bookstore's inventory. It allows users to perform CRUD operations on books and genres within the store. The application is built using ASP.NET Core, Entity Framework Core, and SQL Server.

Key Features:

Books Management: Create, read, update, and delete book entries.
Genres Management: Create, read, update, and delete genres.
Unit Testing: Comprehensive unit tests for both services and controllers.
Code Quality Checks: Integrated coverage, complexity, and style checks.
Prerequisites
.NET 7 SDK
SQL Server (for SQL Server-based setup) or MySQL (for MySQL-based setup)
Postman (for API testing)
Visual Studio (for development)
Setting Up the Application
Clone the Repository:

bash
git clone https://github.com/yourusername/BookStore_Project.git
cd BookStore_Project
Restore NuGet Packages:

bash
dotnet restore
Configure Database Connection:

Update the appsettings.json file with your database connection string:

For SQL Server:

json
"ConnectionStrings": {
  "DefaultConnection": "Server=your_server_name;Database=BookStoreDb;User Id=your_username;Password=your_password;"
}
For MySQL:

json
"ConnectionStrings": {
  "DefaultConnection": "Server=your_server_name;Database=BookStoreDb;User=your_username;Password=your_password;"
}
Apply Migrations:

bash
dotnet ef database update
Seed Initial Data (Optional):

If you have any initial data to seed, ensure it's included in the DbInitializer class or similar setup script.

Running the Application
Start the Application:

bash
dotnet run --project BookStore_Project
Access the API:

Open Postman or your web browser and navigate to http://localhost:5000 (or the port specified in your launchSettings.json).

Available Endpoints:

Books

GET /api/books - Retrieve all books
GET /api/books/{id} - Retrieve a book by ID
POST /api/books - Create a new book
PUT /api/books/{id} - Update a book by ID
DELETE /api/books/{id} - Delete a book by ID
Genres

GET /api/genres - Retrieve all genres
GET /api/genres/{id} - Retrieve a genre by ID
POST /api/genres - Create a new genre
PUT /api/genres/{id} - Update a genre by ID
DELETE /api/genres/{id} - Delete a genre by ID
Running Unit Tests
Run Tests:

bash
dotnet test
View Coverage Report:

bash
dotnet test --collect:"XPlat Code Coverage"
dotnet tool install --global dotnet-reportgenerator-globaltool
reportgenerator -reports:"**/coverage.cobertura.xml" -targetdir:"coverage-report" -reporttypes:Html
Open coverage-report/index.html to view the coverage results.

Code Quality Checks
Code Coverage: Ensure that tests cover more than 80% of your codebase. Coverage reports can be found in the coverage-report directory.

Code Complexity: Use tools like NDepend or SonarQube for analyzing code complexity and maintainability.

Code Style: Ensure that your code adheres to the defined coding standards by running StyleCop or similar tools.
