-- Create LookUp table
CREATE TABLE LookUps (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Status INT,
    Value NVARCHAR(255)
);

-- Create Employee table
CREATE TABLE Employees (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    Contact NVARCHAR(255),
    Email NVARCHAR(255),
    Address NVARCHAR(MAX),
    AccountNo NVARCHAR(255),
    Salary DECIMAL(18, 2),
    JoiningDate DATE,
    UserId INT
);

-- Create LoginCredentials table
CREATE TABLE LoginCredentials (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT,
    Username NVARCHAR(255) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Role NVARCHAR(255),
    FOREIGN KEY (UserId) REFERENCES Employees(Id)
);

-- Create Supplier table
CREATE TABLE Suppliers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    Contact NVARCHAR(255),
    Email NVARCHAR(255),
    Address NVARCHAR(MAX)
);

-- Create Category table
CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX)
);

-- Create SubCategory table
CREATE TABLE SubCategories (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CategoryId INT,
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);

-- Create Product table
CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    SubCategoryId INT,
    Price DECIMAL(18, 2),
    Stock INT,
    SupplierId INT,
    FOREIGN KEY (SubCategoryId) REFERENCES SubCategories(Id),
    FOREIGN KEY (SupplierId) REFERENCES Suppliers(Id)
);

-- Create Discount table
CREATE TABLE Discounts (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CouponCode NVARCHAR(255) NOT NULL,
    Percentage DECIMAL(5, 2) NOT NULL,
    Description NVARCHAR(MAX)
);

-- Create DiscountedOrders table
CREATE TABLE DiscountedOrders (
    Id INT PRIMARY KEY IDENTITY(1,1),
    OrderId INT,
    DiscountId INT,
    FOREIGN KEY (OrderId) REFERENCES Orders(Id),
    FOREIGN KEY (DiscountId) REFERENCES Discounts(Id)
);

-- Create Customer table
CREATE TABLE Customers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    RegisteredBy INT,
    Name NVARCHAR(255) NOT NULL,
    FName NVARCHAR(255),
    CNIC NVARCHAR(255),
    Contact NVARCHAR(255),
    Email NVARCHAR(255),
    Profession NVARCHAR(255),
    Address NVARCHAR(MAX),
    --FOREIGN KEY (RegisteredBy) REFERENCES LoginCredentials(UserId)
);

-- Create Orders table
CREATE TABLE Orders (
    Id INT PRIMARY KEY IDENTITY(1,1),
    EmployeeId INT,
    CustomerId INT,
    ProductId INT,
    Quantity INT,
    TotalPrice DECIMAL(18, 2),
    Date DATE,
    isPurchased BIT,
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
    FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
    FOREIGN KEY (ProductId) REFERENCES Products(Id)
);

-- Create Purchases table
CREATE TABLE Purchases (
    Id INT PRIMARY KEY IDENTITY(1,1),
    SupplierId INT,
    ProductId INT,
    Quantity INT,
    TotalPrice DECIMAL(18, 2),
    FOREIGN KEY (SupplierId) REFERENCES Suppliers(Id),
    FOREIGN KEY (ProductId) REFERENCES Products(Id)
);

-- Create Attendance table
CREATE TABLE Attendances (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Date DATE,
    Shift NVARCHAR(255)
);

-- Create EmployeeAttendance table
CREATE TABLE EmployeeAttendances (
    Id INT PRIMARY KEY IDENTITY(1,1),
    AttendanceId INT,
    EmployeeId INT,
    Status INT,
    FOREIGN KEY (AttendanceId) REFERENCES Attendances(Id),
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
);

-- Create EmployeeLoginTime table
CREATE TABLE EmployeeLoginTimes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    EmployeeId INT,
    StartTime DATETIME,
    EndTime DATETIME,
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
);


ALTER TABLE Orders
ADD CONSTRAINT FK_Lookups_Orders
FOREIGN KEY (isPurchased)
REFERENCES Lookups(Status);

ALTER TABLE EmployeeAttendances
ADD CONSTRAINT FK_Status_LookUps FOREIGN KEY (Status) REFERENCES LookUps(Id);

ALTER TABLE EmployeeAttendances
ADD CONSTRAINT FK_Status_Orders FOREIGN KEY (Status) REFERENCES Orders(isPurchased);


select * from Customers
select * from Employees
select * from Products
select * from Suppliers
select * from Categories
select * from SubCategories
select * from Discounts

ALTER TABLE Employees ADD 
Description VARCHAR(50)
ALTER TABLE Employees ADD 
FName VARCHAR(50);
ALTER TABLE Employees ADD 
Status INT NOT NULL
ALTER TABLE Discounts ADD 
Name VARCHAR(50)

EXEC sp_rename 'Suppliers.UserId', 'RegisteredBy', 'COLUMN';

alter table Employees drop column Status

ALTER TABLE Products
DROP CONSTRAINT FK__Products__Suppli__4F7CD00D;




alter table Products 
drop column stock

select * from Orders

EXEC sp_rename 'Purchases', 'Shipments';

ALTER TABLE Orders
ADD CreatedBy INT NOT NULL;
ALTER TABLE Orders
ADD CreatedOn DATE NOT NULL;
ALTER TABLE Orders
ADD UpdatedBy INT;
ALTER TABLE Orders
ADD UpdatedOn DATE;
ALTER TABLE Orders
ADD isDeleted INT NOT NULL;

ALTER TABLE Employees
ALTER COLUMN AccountNo VARCHAR(24)

CREATE TABLE Reviews
(
    Id int PRIMARY KEY IDENTITY(1, 1),
    ProductId int NOT NULL,
    EmployeeId int NOT NULL,
	CustomerId int NOT NULL,
    Rating int,
    Description varchar(255),
	FOREIGN KEY (ProductId) REFERENCES Products(Id),
	FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
	FOREIGN KEY (CustomerId) REFERENCES Customers(Id)
);
drop table Reviews

SELECT * FROM Reviews

Alter Table LoginCredentials
ALTER COLUMN Username VARCHAR(30) NOT NULL

ALTER TABLE Attendances
ALter column Shift VARCHAR(10) NOT NULL

ALTER TABLE EmployeeAttendances
ALter COLUMN Status int NOT NULL

ALTER TABLE Attendances
ALter COLUMN Date date NOT NULL

ALTER TABLE OrderItems
ADD CONSTRAINT FK_ordersitems_productid
FOREIGN KEY (ProductId) REFERENCES Products(Id);




SELECT * FROM Orders

CREATE TABLE OrderItems 
(
	Id int PRIMARY KEY IDENTITY(1, 1),
	OrderId int NOT NULL,
	ProductId int NOT NULL,
	Quantity int NOT NULL,
	FOREIGN KEY (OrderId) REFERENCES Orders(Id)
);
CREATE TABLE ShipmentItems 
(
	Id int PRIMARY KEY IDENTITY(1, 1),
	ShipmentId int NOT NULL,
	ProductId int NOT NULL,
	Quantity int NOT NULL,
	FOREIGN KEY (ShipmentId) REFERENCES Shipments(Id)
);

ALTER TABLE Products
ALTER COLUMN 
	
select * from Orders


-- Inserting data into the [DiscountedOrders] table
INSERT INTO [plag].[dbo].[DiscountedOrders] ([OrderId], [DiscountId])
VALUES (1, 1),
       (2, 2);

-- Inserting data into the [EmployeeAttendances] table
INSERT INTO [plag].[dbo].[EmployeeAttendances] ([AttendanceId], [EmployeeId], [Status])
VALUES (1, 1, 1),
       (2, 2, 1);

-- Inserting data into the [EmployeeLoginTimes] table
INSERT INTO [plag].[dbo].[EmployeeLoginTimes] ([EmployeeId], [StartTime], [EndTime])
VALUES (1, '2024-04-15 08:00:00', '2024-04-15 17:00:00'),
       (2, '2024-04-15 09:00:00', '2024-04-15 18:00:00');

-- Inserting data into the [Employees] table
INSERT INTO [plag].[dbo].[Employees] ([Name], [Contact], [Email], [Address], [AccountNo], [Salary], [JoiningDate], [UserId], [FName])
VALUES ('Employee 3', '12345678910', 'employee3@example.com', '123 Elm St', '345678901234567890123412', 900.00, '2024-04-15', NULL, 'Name 3'),
       ('Employee 2', '23456789012', 'employee2@example.com', '456 Elm St', '234567890123456789012345', 1500.00, '2024-04-15', 2, 'Name 2');

-- Inserting data into the [LoginCredentials] table
INSERT INTO [plag].[dbo].[LoginCredentials] ([UserId], [Username], [Password], [Role])
VALUES (1, 'username1', 'password1', 'Role 1'),
       (2, 'username2', 'password2', 'Role 2');

-- Inserting data into the [LookUps] table
INSERT INTO [plag].[dbo].[LookUps] ([Status], [Value])
VALUES (1, 'ACTIVE'),
       (2, 'INACTIVE'),
	   (3, 'PRESENT'),
	   (4, 'ABSENT'),
	   (5, 'LATE'),
	   (6, 'LEAVE'),
	   (7, 'YES'),
	   (8, 'NO')
	   ;

alter table EmployeeAttendances
add constraint FK_EmployeeAttendances_Status FOREIGN KEY (Status) REFERENCES LookUps(Status)

	   delete from LookUps

delete from LookUps
-- Inserting data into the [OrderItems] table
INSERT INTO [plag].[dbo].[OrderItems] ([OrderId], [ProductId], [Quantity])
VALUES (1, 1, 5),
       (2, 2, 10);

-- Inserting data into the [Orders] table
INSERT INTO [plag].[dbo].[Orders] ([EmployeeId], [CustomerId], [TotalPrice], [isPurchased], [DateUpdated], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [isDeleted], [OrderItemsId])
VALUES (1, 1, 100.00, 1, '2024-04-15', 1, '2024-04-15', 1, '2024-04-15', 0, 1),
       (2, 2, 200.00, 1, '2024-04-15', 2, '2024-04-15', 2, '2024-04-15', 0, 2);

-- Inserting data into the [Products] table
INSERT INTO [plag].[dbo].[Products] ([Name], [SubCategoryId], [Price], [ExpiryDate])
VALUES ('Product 1', 1, 50.00, '2024-04-30'),
       ('Product 2', 2, 75.00, '2024-05-15');

-- Inserting data into the [Reviews] table
INSERT INTO [plag].[dbo].[Reviews] ([ProductId], [EmployeeId], [CustomerId], [Rating], [Description])
VALUES (1, 1, 1, 5, 'Great product!'),
       (2, 2, 2, 4, 'Good product.');

-- Inserting data into the [ShipmentItems] table
INSERT INTO [plag].[dbo].[ShipmentItems] ([ShipmentId], [ProductId], [Quantity])
VALUES (1, 1, 20),
       (2, 2, 30);

-- Inserting data into the [Shipments] table
INSERT INTO [plag].[dbo].[Shipments] ([SupplierId], [TotalPrice], [ShipmentItemsId], [EmployeeId])
VALUES (1, 500.00, 1, 1),
       (2, 700.00, 2, 2);


delete from SubCategories

select p.Id, p.Name [Product Name], Price, ExpiryDate, s.Name [SubCategory Name], c.Name [Category Name] from Products p join SubCategories s on p.SubCategoryId = s.Id join Categories c on c.Id = s.CategoryId

delete from Categories where Id = 2

UPDATE Products
SET SubCategoryId = 32 WHERE Id = 21;

insert into SubCategories values (1, 'Laptops', '...')
insert into Categories values ('Household', 'Products for Household')
-- Inserting products with specified values
INSERT INTO Products VALUES ('Coca-Cola', 3, 120, '2024-05-15');
INSERT INTO Products VALUES ('Brown Bread', 6, 80, '2024-04-20');
INSERT INTO Products VALUES ('Apple Juice', 4, 150, '2024-06-01');
INSERT INTO Products VALUES ('Samsung Galaxy S20', 2, 80000, '2024-05-30');
INSERT INTO Products VALUES ('Cheddar Cheese', 11, 300, '2024-05-10');
INSERT INTO Products VALUES ('Fresh Spinach', 14, 50, '2024-04-25');
INSERT INTO Products VALUES ('Lays Chips', 17, 80, '2024-07-01');
INSERT INTO Products VALUES ('Sunflower Oil', 23, 250, '2024-09-15');
INSERT INTO Products VALUES ('Mango Juice', 4, 120, '2024-06-15');
INSERT INTO Products VALUES ('Apple iPhone 13', 2, 120000, '2024-08-30');
INSERT INTO Products VALUES ('Cherry Cake', 9, 500, '2024-05-20');
INSERT INTO Products VALUES ('Almond Nuts', 19, 200, '2024-10-01');
INSERT INTO Products VALUES ('Canola Oil', 23, 300, '2024-09-30');
INSERT INTO Products VALUES ('Carrot', 14, 30, '2024-04-28');
INSERT INTO Products VALUES ('Pepsi', 3, 100, '2024-06-10');
INSERT INTO Products VALUES ('Samsung Smart TV', 2, 120000, '2024-09-15');
INSERT INTO Products VALUES ('Mint Chocolate', 18, 50, '2024-05-05');
INSERT INTO Products VALUES ('Baby Shampoo', 27, 150, '2024-07-20');
INSERT INTO Products VALUES ('Paper Towels', 30, 80, '2024-08-05');

select * from LoginCredentials
select * from Customers
select * from EmployeeAttendances
select * from Attendances
select * from LookUps

select * from Orders
select * from OrderItems
select * from Products

INSERT INTO Orders VALUES(7, 3, 170, 7, NULL, GETDATE(), NULL, 8)
INSERT INTO OrderItems VALUES (22, 1, 4)

alter table Orders alter column DateUpdated date 

delete from Employees

INSERT INTO LoginCredentials(Username, Password, Role) VALUES('Employee 1', '56789012345678901234', 'Employee')
INSERT INTO LoginCredentials(Username, Password, Role) VALUES('Employee 2', '67890123456789012345', 'Employee')

UPDATE Employees 
SET UserId = 5 WHERE Id = 8

INSERT INTO EmployeeAttendances VALUES (6, 7, 3)
INSERT INTO EmployeeAttendances VALUES (6, 8, 3)
INSERT INTO EmployeeAttendances VALUES (6, 9, 3)
INSERT INTO EmployeeAttendances VALUES (7, 7, 3)
INSERT INTO EmployeeAttendances VALUES (7, 8, 3)
INSERT INTO EmployeeAttendances VALUES (7, 9, 4)

select * from ShipmentItems
select * from Shipments
select * from Products  s join SubCategories c on c.Id = s.SubCategoryId
INSERT INTO ShipmentItems VALUES(24, 2, 5);
INSERT INTO ShipmentItems VALUES(23, 2, 5);
INSERT INTO ShipmentItems VALUES(22, 3, 5);

update ShipmentItems set Quantity = 6 where Id = 5

--Products received in a particular shipment
select p.Name, p.Price, i.Quantity, p.ExpiryDate, i.ShipmentId from Shipments s Join ShipmentItems i on s.Id = i.ShipmentId join Products p on i.ProductId = p.Id where s.Id = 5

--Calculate total price of a Shipment
select i.ShipmentId, SUM(i.TotalPrice) TotalBill from
(select p.Name, p.Price, i.Quantity, p.ExpiryDate, i.ShipmentId, Price*Quantity TotalPrice from Shipments s Join ShipmentItems i on s.Id = i.ShipmentId join Products p on i.ProductId = p.Id where s.Id = 4) i
group by i.ShipmentId

--Calculate Incoming Quantity(In Shipments) of a Specific Product
select p.Id, p.Name, SUM(Quantity) Stock from ShipmentItems i Join Products p ON i.ProductId = p.Id WHERE p.Id = 6 GROUP BY p.Id, p.Name

--Calculate Outgoing Quantity(In Orders) of a Specific Product
select p.Id, p.Name, SUM(Quantity) Stock from OrderItems i Join Products p ON i.ProductId = p.Id WHERE p.Id = 6 GROUP BY p.Id, p.Name

--Calculate Present Stock of a Specific Product
select i.Id, i.Name, CASE WHEN j.Stock is NULL THEN i.Stock ELSE i.Stock-j.Stock END Stock from 
(select p.Id, p.Name, SUM(Quantity) Stock from ShipmentItems i Join Products p ON i.ProductId = p.Id WHERE p.Id = 6 GROUP BY p.Id, p.Name) i
left join (select p.Id, p.Name, SUM(Quantity) Stock from OrderItems i Join Products p ON i.ProductId = p.Id WHERE p.Id = 6 GROUP BY p.Id, p.Name ) j
on i.Id = j.Id


--Calculate out of stock products (including those which are not shiped yet, showing there stock to be zero) 
--Parameter = Threshold Value
select p.Id, p.Name, CASE WHEN temp.Stock is NULL THEN 0 ELSE temp.Stock END Stock from Products P 
left join (select i.Id, i.Name, CASE WHEN j.Stock is NULL THEN i.Stock ELSE i.Stock-j.Stock END Stock from 
(select p.Id, p.Name, SUM(Quantity) Stock from ShipmentItems i Join Products p ON i.ProductId = p.Id GROUP BY p.Id, p.Name) i
left join (select p.Id, p.Name, SUM(Quantity) Stock from OrderItems i Join Products p ON i.ProductId = p.Id GROUP BY p.Id, p.Name ) j
on i.Id = j.Id) temp
ON p.Id = temp.Id
where temp.Stock < 7 OR temp.Stock is NULL
ORDER BY temp.Stock DESC

--Calculate out of stock products (excluding those which are not shiped yet) 
--Parameter = Threshold Value
select * from
(select i.Id, i.Name, CASE WHEN j.Stock is NULL THEN i.Stock ELSE i.Stock-j.Stock END Stock from 
(select p.Id, p.Name, SUM(Quantity) Stock from ShipmentItems i Join Products p ON i.ProductId = p.Id GROUP BY p.Id, p.Name) i
left join (select p.Id, p.Name, SUM(Quantity) Stock from OrderItems i Join Products p ON i.ProductId = p.Id GROUP BY p.Id, p.Name ) j
on i.Id = j.Id) temp
where temp.Stock = 1

--Sold Out Products
select * from
(select i.Id, i.Name, CASE WHEN j.Stock is NULL THEN i.Stock ELSE i.Stock-j.Stock END Stock from 
(select p.Id, p.Name, SUM(Quantity) Stock from ShipmentItems i Join Products p ON i.ProductId = p.Id GROUP BY p.Id, p.Name) i
left join (select p.Id, p.Name, SUM(Quantity) Stock from OrderItems i Join Products p ON i.ProductId = p.Id GROUP BY p.Id, p.Name ) j
on i.Id = j.Id) temp
where temp.Stock = 0


--Nearly Expiring Product
--exactly some days from now
SELECT * FROM Products WHERE DATEADD(day, 13, CAST(GETDATE() AS DATE)) = ExpiryDate
--products expiring in range from today and are not expired yet
SELECT * FROM Products WHERE ExpiryDate <= DATEADD(day, 30, CAST(GETDATE() AS DATE)) AND ExpiryDate > CAST(GETDATE() AS DATE)



--Employees Productivity (No of Orders Placed)
select e.Id, e.Name, COUNT(o.Id) OrdersPlaced
from Employees e
left join Orders o
ON e.Id = o.EmployeeId
group by e.Id, e.Name 
ORDER BY e.Id
--Shipments added
select e.Id, e.Name, COUNT(o.Id) ShipmentsAdded
from Employees e
left join Shipments o
ON e.Id = o.EmployeeId
group by e.Id, e.Name 
ORDER BY e.Id

--Customer Preferences
--Most Products bought by a customer
SELECT o.CustomerId, c.Name, p.Id, p.Name, SUM(i.Quantity) TotalQuantity, COUNT(i.ProductId) ManyTimes
FROM Orders o JOIN OrderItems i ON o.Id = i.OrderId JOIN Products p ON p.Id = i.ProductId JOIN Customers c ON c.Id = o.CustomerId
WHERE CustomerId = 3 and isDeleted = 8
GROUP BY o.CustomerId, c.Name, p.Id, p.Name

--Loan Account of Each Customer
select o.CustomerId, c.Name, SUM(TotalPrice) AmountDebted
from Orders o JOIN Customers c ON c.Id = o.CustomerId WHERE isPurchased = 8 AND isDeleted = 8
GROUP BY o.CustomerId, c.Name


--Loan History Remaining of each customer
select *
from OrderItems i JOIN Orders o ON i.OrderId = o.Id JOIN Products p ON p.Id = i.ProductId JOIN Customers c ON c.Id = 
WHERE o.CustomerId = 4
GROUP BY 



select * from Customers
select * from Orders
select * from OrderItems
select * from Lookups

INSERT INTO Orders VALUES (7, 4, 410, 8, NULL, GETDATE(), NULL, 8)
INSERT INTO OrderItems VALUES (19, 2, 1004)
INSERT INTO OrderItems VALUES (18, 1, 1004)
INSERT INTO OrderItems VALUES (22, 1, 1004)
-- carrot 2
--canola oil 1
--chocalte 1
alter table lookups
drop column Id
drop constraint PK__LookUps__3214EC07103E6AFE

alter table EmployeeAttendances Drop Constraint FK_Status_LookUps

ALTER TABLE LookUps ADD CONSTRAINT PK_LookUps_Status PRIMARY KEY (Status);


ALTER TABLE EmployeeAttendances ADD CONSTRAINT FK_EmployeeAttendances_Status FOREIGN KEY (Status) REFERENCES  LookUps(Status);

alter table OrderItems
drop column OrderId
drop constraint FK__OrderItem__Order__5EBF139D

alter table Orders add constraint FK_OrderItems_OrderItemsId FOREIGN KEY (OrderItemsId) REFERENCES OrderItems(Id)


alter table Orders
drop column OrderItemsId
drop constraint FK_OrderItems_OrderItemsId

alter table OrderItems
add OrderId int NOT NULL

alter table OrderItems add constraint FK_Orders_OrderId FOREIGN KEY (OrderId) REFERENCES Orders(Id)

alter table Orders add constraint FK_LookUps_isPurchased FOREIGN KEY (isPurchased) REFERENCES LookUps(Status)
alter table Orders add constraint FK_LookUps_isDeleted FOREIGN KEY (isDeleted) REFERENCES LookUps(Status)

alter table Suppliers add constraint FK_LookUps_Status FOREIGN KEY (Status) REFERENCES LookUps(Status)


alter table employees
add constraint FK_LoginCredentials_UserId
FOREIGN KEY (UserId) REFERENCES LoginCredentials(Id);







--insert Order with the procedure
CREATE PROCEDURE InsertOrder
	@EmployeeId INT, 
	@CustomerId INT, 
	@TotalPrice DECIMAL(18, 2), 
	@isPurchased INT, 
	@DateUpdated DATE, 
	@CreatedOn DATE, 
	@UpdatedBy INT, 
	@isDeleted INT
AS
BEGIN
    INSERT INTO Orders (EmployeeId, CustomerId, TotalPrice, isPurchased, DateUpdated, CreatedOn, UpdatedBy, isDeleted) 
	VALUES (@EmployeeId, @CustomerId, @TotalPrice, @isPurchased, @DateUpdated, @CreatedOn, @UpdatedBy, @isDeleted);
END;


---insert order items with the procedure
CREATE PROCEDURE InsertOrderItem
    @ProductId INT,
    @Quantity INT
    @OrderId INT,
AS
BEGIN
    INSERT INTO OrderItems (ProductId, Quantity, OrderId)
    VALUES (@ProductId, @Quantity, @OrderId)
END;


--insert shipment with procedure
CREATE PROCEDURE InsertShipment
	@SupplierId INT, 
	@TotalPrice INT, 
	@EmployeeId DECIMAL(18, 2)
AS
BEGIN
    INSERT INTO Orders (EmployeeId, CustomerId, TotalPrice, isPurchased, DateUpdated, CreatedOn, UpdatedBy, isDeleted) 
	VALUES (@EmployeeId, @CustomerId, @TotalPrice, @isPurchased, @DateUpdated, @CreatedOn, @UpdatedBy, @isDeleted);
END;





---insert shipment items with the procedure
CREATE PROCEDURE InsertShipmentItem
    @ProductId INT,
    @Quantity INT
    @ShipmentId INT
AS
BEGIN
    INSERT INTO OrderItems (ProductId, Quantity, OrderId)
    VALUES (@ProductId, @Quantity, @ShipmentId)
END;


--update EmployeeLoginTime
CREATE PROCEDURE UpdateLoginTime
	@Id INT,
	@EndTime DATETIME

AS 
BEGIN 
		Update EmployeeLoginTimes
		SET EndTime = @EndTime WHERE Id = @Id
END;








-- Transaction to add the Order Items 
BEGIN TRY
	BEGIN TRANSACTION;

	DECLARE @EmployeeId INT = @eid;
	DECLARE @CustomerId INT = @cid; 
	DECLARE @TotalPrice DECIMAL(18, 2) = @totalprice;
	DECLARE @isPurchased INT = @isPurch;
	DECLARE @DateUpdated DATE = @dateupdate;
	DECLARE @CreatedOn DATE = @createdon;
	DECLARE @UpdatedBy INT = @updatedby;
	DECLARE @isDeleted INT = @isdeleted;

	-- Add the order to the Orders table
	EXEC InsertOrder @EmployeeId, @CustomerId, @TotalPrice, @isPurchased, @DateUpdated, @CreatedOn, @UpdatedBy, @isDeleted;

	-- Get the OrderID of the newly added order
	SET @OrderID = SCOPE_IDENTITY();        --new added order id will be retrieved
	DECLARE @ProductId INT; 
	DECLARE @Quantity INT;

	DECLARE curItems CURSOR FOR
	SELECT ProductId, Quantity FROM table;

	OPEN curItems;
	FETCH NEXT FROM curItems INTO @ProductId, @Quantity;
	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert each item into the OrderItems table
		EXEC InsertOrderItem @ProductId, @Quantity, @OrderId;
		FETCH NEXT FROM curItems INTO @ProductId, @Quantity;
	END
	CLOSE curItems;
	DEALLOCATE curItems;
	COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;
END CATCH;


--insert shipement and shipment items using transaction
BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @SupplierId INT = @supplierid;
    DECLARE @TotalPrice DECIMAL(18, 2) = @totalprice;
    DECLARE @EmployeeId INT = @employeeid;
    
    -- Add the shipment to the Shipments table
    EXEC InsertShipment @SupplierId, @TotalPrice, @EmployeeId;

    -- Get the ShipmentID of the newly added shipment
    DECLARE @ShipmentId INT = SCOPE_IDENTITY();

    DECLARE @ProductId INT; 
    DECLARE @Quantity INT;

    DECLARE curItems CURSOR FOR
    SELECT ProductId, Quantity FROM ShipmentItemsTable; -- Assuming you have a table for shipment items

    OPEN curItems;
    FETCH NEXT FROM curItems INTO @ProductId, @Quantity;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Insert each item into the ShipmentItems table
        EXEC InsertShipmentItem @ProductId, @Quantity, @ShipmentId;
        FETCH NEXT FROM curItems INTO @ProductId, @Quantity;
    END
    CLOSE curItems;
    DEALLOCATE curItems;

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;
END CATCH;


--Transaction to add employee Attendance
BEGIN TRY
    BEGIN TRANSACTION;

    -- Add the attendance record
    DECLARE @AttendanceDate DATE = @date;
    DECLARE @Shift VARCHAR(50) = @shift;

    INSERT INTO Attendances VALUES (@AttendanceDate, @Shift);

    -- Get the AttendanceID of the newly added attendance record
    DECLARE @AttendanceID INT = SCOPE_IDENTITY();

    -- Add employee attendance records
    DECLARE @EmployeeID INT;
    DECLARE @Status VARCHAR(50);

    -- Assuming you have a table or variable with employee IDs
    DECLARE curEmployees CURSOR FOR
    SELECT EmployeeID, Status FROM table;

    OPEN curEmployees;
    FETCH NEXT FROM curEmployees INTO @EmployeeID, @Status;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Insert each employee attendance record
        INSERT INTO EmployeeAttendances VALUES (@AttendanceID, @EmployeeID, @Status);
        FETCH NEXT FROM curEmployees INTO @EmployeeID, @Status;
    END
    CLOSE curEmployees;
    DEALLOCATE curEmployees;

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;
END CATCH;






















---View 1
SELECT s.Id, s.SupplierId, s.Id, s.EmployeeId, i.ProductId, p.Price, s.TotalPrice
FROM Shipments s 
JOIN ShipmentItems i ON i.ShipmentId = s.Id 
JOIN Products p ON p.Id = i.ProductId



---View 2
SELECT o.Id, o.CustomerId, o.Id, o.EmployeeId, i.ProductId, p.Price, o.TotalPrice
FROM Orders o
JOIN OrderItems i ON i.OrderId = o.Id 
JOIN Products p ON p.Id = i.ProductId




---View 3
SELECT ea.AttendanceId, a.Date, ea.Status, e.Id, e.Name, a.Shift, l.Value
FROM EmployeeAttendances ea
JOIN Employees e ON e.Id = ea.EmployeeId
JOIN Attendances a ON ea.AttendanceId = a.Id
JOIN LookUps l ON l.Status = ea.Status




---View 4
SELECT c.Id, c.Name, p.Id, p.Name, p.Price, r.Rating, r.Description
FROM Customers c 
JOIN Reviews r ON r.CustomerId = c.Id
JOIN Products p ON p.Id = r.ProductId



---View 5
SELECT s.Id, COUNT(p.Id), SUM(o.TotalPrice)
FROM Orders o 
JOIN DiscountedOrders do ON do.OrderId = o.Id
JOIN Discounts d ON d.Id = do.DiscountId
JOIN OrderItems oi ON oi.OrderId = o.Id
JOIN Products p ON p.Id = oi.ProductId
JOIN SubCategories s ON s.Id = p.SubCategoryId
WHERE o.isPurchased = 7
GROUP BY s.Id
