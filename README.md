# P.M.System_Store

 was created, including all bash commands, technical aspects of the project, the final directory structure, and instructions on how to generate a new prompt for similar projects.

 ![P.M.Manage_system.png](/assets/P.M.Manage_system.png)

### Bash Commands to Create the Project:

```bash
# Step 1: Create a new ASP.NET Core Web API project
dotnet new webapi -n P.M.System_Store
cd P.M.System_Store

# Step 2: Create directories for Controllers, Models, and Services
mkdir Controllers Models Services wwwroot

# Step 3: Create essential files for JavaScript frontend interaction
touch wwwroot/index.html wwwroot/app.js wwwroot/styles.css

# Step 4: Install necessary dependencies for the backend (optional, depending on services)
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools

# Step 5: Create Model files for Category and Product
touch Models/Category.cs Models/Product.cs

# Step 6: Create the CategoryController file for CRUD operations
touch Controllers/CategoryController.cs

# Step 7: Configure `Startup.cs` (optional in .NET 6+ where Program.cs includes configuration)
# Step 8: Run the project to verify it is working
dotnet run
```

### Technical Aspects of the Project

1. **Backend: ASP.NET Core Web API**
   - The backend is built using ASP.NET Core Web API, which allows RESTful endpoints for CRUD operations.
   - The backend contains controllers to handle the business logic for managing categories and products. The `CategoryController` is responsible for handling operations like adding, retrieving, and managing categories and products.
   - The models `Category` and `Product` represent the data structure used in this project.

   - **Models (Category and Product):**
     - `Category`: Contains properties like `Number`, `Name`, and a list of `Products`.
     - `Product`: Contains properties like `Number`, `Name`, and `Price`.

   - **CategoryController:**
     - Handles HTTP `GET` and `POST` methods to create and fetch categories and products.
     - Endpoints include:
       - `GET /category` for fetching all categories.
       - `POST /category` for adding a new category.
       - `GET /category/{categoryId}/products` for fetching products of a specific category.
       - `POST /category/{categoryId}/products` for adding a product to a category.

2. **Frontend: Static HTML, JavaScript, CSS**
   - The frontend was created using simple HTML, JavaScript, and CSS, stored in the `wwwroot` folder.
   - The **JavaScript (app.js)** handles AJAX requests to interact with the backend API and update the UI dynamically.
     - AJAX requests use `fetch` to send and receive JSON data from the backend.
     - The frontend contains forms for adding categories and products, and dynamically loads the available categories and their products.
   - **CSS** was used for minimal styling.

3. **Program.cs:**
   - The `Program.cs` file sets up the basic middleware for serving static files and enabling API endpoints.
   - `MapControllers` ensures that the controller routes are properly mapped.
   - `UseStaticFiles()` allows the serving of static files like `index.html`, `app.js`, and `styles.css` from the `wwwroot` folder.

4. **JSON Serialization/Deserialization:**
   - `Category` and `Product` data models are serialized and deserialized between the frontend and backend using JSON.

5. **No Database (In-Memory List):**
   - The project uses a simple in-memory `List` to store categories and products. This is ideal for simplicity but can be replaced with a database like SQL Server using Entity Framework Core for persistent data storage.

### Directory Structure

After running the commands and creating the files, the project directory structure looks like this:

```
P.M.System_Store/
│
├── Controllers/
│   └── CategoryController.cs      # Controller for category/product logic
│
├── Models/
│   ├── Product.cs                 # Model for Product (ID, Name, Price)
│   └── Category.cs                # Model for Category (ID, Name, Products List)
│
├── Services/                      # (Optional, for service classes if needed in the future)
│
├── wwwroot/                       # Static files folder for frontend
│   ├── index.html                 # Main HTML file for frontend
│   ├── app.js                     # JavaScript file for AJAX interaction
│   └── styles.css                 # Stylesheet for basic styling
│
├── Program.cs                     # Main entry point for the application, API setup
├── Startup.cs                     # (Optional, can be included in Program.cs for .NET 6+)
├── P.M.System_Store.csproj         # Project configuration file
├── Properties/
└── appsettings.json                # Configuration file (optional)
```

### Instructions to Generate a New Prompt for a Similar Project

If you want me to generate a similar project in the future, you can use the following prompt:

```
I want to create a simple full-stack project using ASP.NET Core Web API and a static HTML/JavaScript frontend. The project should allow CRUD operations for managing a list of categories and products. The backend should be built using ASP.NET Core, with a basic in-memory list to store categories and products. The frontend should use HTML, JavaScript, and CSS to interact with the backend through API calls, allowing the user to add categories, add products to categories, and view them dynamically. Provide all the necessary bash commands to set up the project, create folders, and files. Also, describe the project structure, the technical aspects, and how to run it.
```

### How to Run the Project

1. Navigate to the project directory:

   ```bash
   cd P.M.System_Store
   ```

2. Run the project using the following command:

   ```bash
   dotnet run
   ```

3. Open your browser and go to `http://localhost:5231` to see the frontend page. The page will allow you to add categories and products, and you can dynamically load and view the products for each category.

---

This setup provides a complete solution with a static frontend and a dynamic backend using ASP.NET Core Web API. 