USE RetailStoreDB;

CREATE TABLE Customers 
(
    CustomerID INT PRIMARY KEY,
    FirstName VARCHAR(30),
    LastName VARCHAR(30),
    Email VARCHAR(50),
    RegistrationDate DATE  
);

CREATE TABLE Products
(
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(30),
    Category VARCHAR(30),
    Price INT,
    StockQuantity INT
);

CREATE TABLE Orders
(
    OrderID INT PRIMARY KEY,
    CustomerID INT,  
    ProductID INT,  
    OrderDate DATE, 
    Quantity INT,  
    FOREIGN KEY (CustomerID) 
        REFERENCES Customers(CustomerID) 
        ON DELETE CASCADE,
    FOREIGN KEY (ProductID) 
        REFERENCES Products(ProductID) 
        ON DELETE CASCADE
);


INSERT INTO Customers (CustomerID, FirstName, LastName, Email, RegistrationDate) 
VALUES 
(1, 'Hagar', 'Muhammad', 'H.Mohamed2255@nu.edu.eg', '2022-10-12'),
(2, 'Haidy', 'Muhammad', 'H.Mohamed2225@nu.edu.eg', '2022-10-2'),
(3, 'Heba', 'Muhammad', 'H.Mohamed2245@nu.edu.eg', '2022-10-8'),
(4, 'Hadeer', 'Muhammad', 'H.Mohamed2254@nu.edu.eg', '2022-10-5'),
(5, 'Mallak', 'Hisahm', 'M.Hisham2246@nu.edu.eg', '2022-10-7');

INSERT INTO Products (ProductID, ProductName, Category, Price, StockQuantity) 
VALUES 
(229780, 'ayhaga', 'whatever', 20, 4),
(229781, 'ayhaga1', 'whatever1', 21, 5),
(229782, 'ayhaga2', 'whatever2', 22, 6),
(229783, 'ayhaga3', 'whatever3', 23, 7),
(229784, 'ayhaga4', 'whatever4', 24, 8);


INSERT INTO Orders (OrderID, CustomerID, ProductID, OrderDate, Quantity) 
VALUES 
(239802, 1, 229780, '2024-02-18', 6),
(239812, 2, 229781, '2024-02-13', 60),
(239822, 3, 229782, '2024-02-12', 61),
(239862, 4, 229783, '2024-02-14', 62),
(239832, 5, 229784, '2024-02-15', 63);

SELECT* 
FROM Customers;

SELECT* 
FROM Products; 

SELECT*
FROM Orders;

SELECT*
FROM Customers
WHERE RegistraionDate > '2022-10-12';

SELECT* 
FROM Products
order by Price DESC limit 3; 

SELECT 
Orders.OrderID,
Orders.OrderDate,
Orders.Quantity,
Customer.FirstName,
Customer.LastName,
Products.ProductID,
Products.Price,
Products.Category,
Product.ProductName
FROM Orders
JOIN Customer ON Customer.CustomerID = Orders.CustomerID 
JOIN Products ON Orders.ProductID = Products.ProductID;

SELECT 
Customer.CustomerID,
Customer.FirstName,
Cutsomer.LastName,
SUM (Orders.Quantity * Orders.Price) AS Total
FROM
Orders
JOIN Customers
ON Orders.CustomerID = Customers.CustomerID
JOIN Products
ON Orders.ProductID = Products.ProductID
group by Customers.CusomerID;

SELECT Customers.FirstName, Customers.LastName, 
       COUNT(Orders.OrderID) AS TotalOrders
FROM Orders
JOIN Customers ON Orders.CustomerID = Customers.CustomerID
GROUP BY Customers.CustomerID;

SELECT Products.ProductName, 
       SUM(Orders.Quantity) AS TotalSold,
       SUM(Orders.Quantity * Products.Price) AS TotalRevenue
FROM Orders
JOIN Products ON Orders.ProductID = Products.ProductID
GROUP BY Products.ProductID;


SHOW TABLES;

