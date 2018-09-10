Readme for MyBookStore Solution

Features implemented for MyBookstore 
1. Display all books
2. Search by Tile, Author or Both
3. Add a Book to Cart
4. View Cart to see all books Added, with Cart Total
5. Place an Order from Cart
6. Order Summary, that displays Available and Out Of Stock Books, with the Total value of Available books in the Cart

Solution Dependencies
1. Newton soft.Json, to work with Json Data (Downloaded from NuGet)

DataStore
1. For WebSite MyBookStore\Files\books.txt (for reading book information and saving to Cart)
2. Data structure is but modified to 
	a. Each book is assigned a ISBN, id to uniquely identify the book
	b. Cart, a field to store the cart quantity
3. For Unit testing the project has its own books.txt for data reading and writing

Running the Solution
1. Get latest of Solution and Build it
2. The Startup project is MyBookStore (MVC web project)
3. Run it in debug or release mode (whichever is the preference)
4. Ensure the following files have written attributes 
	MyBookStore. Tests\Files\books.txt and 
	MyBookStore\MyBookStore\Files\books.txt

Navigating/Testing the Solution
1. By Default on Startup, a List of Books will be displayed
2. If Not there is a menu option "Books" available to view the list of Books
3. Search Fields are available for Title and Author (Search runs a contains search)
4. Title, Author or both can be searched together
5. For each Book, an Add to Cart link, will add 1 quantity to the cart
6. Same Book can be added to the cart multiple times, the cart quantity for each book is updated
7. Add to Cart feature does not validate the available stock quantity of the book
8. To View Cart Items, Click on the cart Menu Option
9. The Cart page displays the order total of all items in the cart (sum of book price multiplied by cart quantity)
10. Place an Order link is provided at the bottom to view available and unavailable books
11. On to of Order page Order Value is displayed (sum of book price multiplied by available quantity)
12. If the cart quantity for a book is more than stock quantity, the book is displayed in Available as well as unavailable with their respective quantities
13. Clicking on Place an Order, resets the cart quantity to zero, but keeps the cart quantity intact (for retesting the solution)
14. After placing and order, Navigate to Books to start again

Projects in the MyBookStore solution
1. MyBookStore.csproj
	Website Solution to display books and cart
	The website invokes the business logic through an Interface
	Search and Add to Cart are implemented through Ajax Calls
2. MyBookStore. BusinessLogic.csproj
	Implemented the business logic, for Search and Validation
	The project contains Interface and Concrete Class
	Business Logic invokes data access through the Storage service interface
3. MyBookStore. DataAccess.csproj
	The project contains interface and concrete classes for working with the file based data store
	The project provides methods for reading and writing JSON object to books.txt file
4. MyBookStore. Entities.csproj
	This project is a data model shared by all projects
	It contains Books and Cart Entities
5. MyBookStore. Tests.csproj
	The project unit test the controllers and all their actions for different scenarios
	All or Individual Tests can be run from the test explorer.

Error Handling
1. Exception is handled primarily for user actions, such as PageLoad and Ajax Calls 
2. On an Error on any page or user action, appropriate error (alert in red) or information(in green) is displayed
