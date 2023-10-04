# ASP.NET-MVC-with-RAZOR-PAGES
## E-commerce web application for store services (with backend technologies in ASP .NET Core 6.0). 

### Description

This application enables users to browse a store's sandstone products, add them to their cart, and place orders. The main view is divided into three sections: category names, a product list, and a preview of the current cart contents. The product summary list is generated dynamically, based on the selected category. TagHelpers attributes in the application's logic enhances navigation between different product pages. Adding items to the cart or clicking "Your Cart" button in the cart preview component redirects user to cart view. Added products and their quantities are globally accessible data, because of implemented session mechanism in the program. Users have an option to continue shopping or proceed to checkout. Clicking the checkout button redirects user to a shipping information form. The form requires proper validation before an order can be placed. Once an order is placed, users can return to the home page - customer data, along with the quantity and type of selected products, is saved in a local database. Data exchange in the application involves reading from or writing to a local database, facilitated by the use of context classes and customized dependency injection.

**In this application, I use product data for demonstration purposes. Please note that this data is sample and does not reflect real products or prices. It is solely provided as test data for presentation purposes.**


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
