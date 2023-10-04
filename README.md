# ASP.NET-MVC-with-RAZOR-PAGES
## E-commerce web application for store services (with backend technologies in ASP .NET Core 6.0). 

### Architecture and Technologies

- **MVC Pattern**  
The application utilizes the MVC (Model-View-Controller) pattern to organize the code. MVC helps in separating business logic from the presentation layer, making the application more scalable and comprehensible.

- **Razor Pages**  
Razor Pages are used in the application to create the user interface and navigate between controllers and Razor Pages. These functionalities complement each other, enabling efficient application development.

- **Partial Views**  
Partial Views are employed to create shared parts of the user interface, reducing code duplication and simplifying application maintenance.

- **Entity Framework with DBContext**  
The application makes use of Entity Framework in conjunction with DBContext for database management. This allows for easy mapping of objects to database tables and performing CRUD operations.

- **Tag Helpers**  
Tag Helpers are used to create dynamic HTML elements in views, making the code in Razor Pages more readable and efficient.

- **LINQ**  
LINQ (Language Integrated Query) is employed for querying the database, providing more readable and understandable queries.

- **Dependency Injection**  
The application follows the Dependency Injection pattern, allowing for dependency injection, such as repository for database access. This makes the code more testable and flexible.

- **ISession Interface**  
The ISession Interface is used for session configuration in the application. Sessions enable data storage between different HTTP requests.

- **Routing in Program.cs**  
Routing is configured in the Program.cs file and is used to define custom URL addresses and handle HTTP requests. This provides control over routing in the application.

- **Frontend Implementation**  
The frontend layer of the application includes simple CSS and Bootstrap styles. While it is a basic implementation, it provides a user-friendly interface.
