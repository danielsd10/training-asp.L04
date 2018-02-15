/* Procedimientos 2018-02-13 */

CREATE PROCEDURE ListAllCategories
AS
BEGIN
	SELECT * FROM [dbo].[Categories] C
	ORDER BY C.CategoryName ASC;
END
GO

CREATE PROCEDURE InsertCategory (
@CategoryName nvarchar(15),
@Description ntext,
@Picture image = null
) AS
BEGIN
	INSERT INTO [dbo].[Categories] (CategoryName, Description, Picture)
	VALUES (@CategoryName, @Description, @Picture);
END
GO

CREATE PROCEDURE UpdateCategory (
@CategoryID int,
@CategoryName nvarchar(15),
@Description ntext,
@Picture image = null
) AS
BEGIN
	UPDATE [dbo].[Categories] SET CategoryName = @CategoryName, Description = @Description, Picture = @Picture
	WHERE CategoryID = @CategoryID;
END
GO

CREATE PROCEDURE DeleteCategory (
@CategoryID int
) AS
BEGIN
	DELETE FROM [dbo].[Categories]
	WHERE CategoryID = @CategoryID;
END
GO

CREATE PROCEDURE ListAllSuppliers
AS
BEGIN
	SELECT * FROM [dbo].[Suppliers] S
	ORDER BY S.CompanyName ASC;
END
GO

CREATE PROCEDURE InsertSupplier (
@CompanyName nvarchar(40),
@ContactName nvarchar(30) = null,
@ContactTitle nvarchar(30) = null,
@Address nvarchar(60) = null,
@City nvarchar(15) = null,
@Region nvarchar(15) = null,
@PostalCode nvarchar(10) = null,
@Country nvarchar(15) = null,
@Phone nvarchar(24) = null,
@Fax nvarchar(24) = null,
@HomePage ntext = null
) AS
BEGIN
	INSERT INTO [dbo].[Suppliers] (CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax, HomePage)
	VALUES (@CompanyName, @ContactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax, @HomePage);
END
GO

CREATE PROCEDURE UpdateSupplier (
@SupplierID int,
@CompanyName nvarchar(40),
@ContactName nvarchar(30) = null,
@ContactTitle nvarchar(30) = null,
@Address nvarchar(60) = null,
@City nvarchar(15) = null,
@Region nvarchar(15) = null,
@PostalCode nvarchar(10) = null,
@Country nvarchar(15) = null,
@Phone nvarchar(24) = null,
@Fax nvarchar(24) = null,
@HomePage ntext = null
) AS
BEGIN
	UPDATE [dbo].[Suppliers] SET CompanyName = @CompanyName,
	ContactName = @ContactName, ContactTitle = @ContactTitle,
	Address = @Address, City = @City, Region = @Region,
	PostalCode = @PostalCode, Country = @Country,
	Phone = @Phone, Fax = @Fax, HomePage = @HomePage
	WHERE SupplierID = @SupplierID;
END
GO

CREATE PROCEDURE DeleteSupplier (
@SupplierID int
) AS
BEGIN
	DELETE FROM [dbo].[Suppliers]
	WHERE SupplierID = @SupplierID;
END
GO

CREATE PROCEDURE ListAllProducts
AS
BEGIN
	SELECT * FROM [dbo].[Products] P
	ORDER BY P.ProductName ASC;
END
GO

CREATE PROCEDURE InsertProduct (
@ProductName nvarchar(40),
@SupplierID int = null,
@CategoryID int = null,
@UnitPrice money = null
) AS
BEGIN
	INSERT INTO [dbo].[Products] (ProductName, SupplierID, CategoryID, UnitPrice)
	VALUES (@ProductName, @SupplierID, @CategoryID, @UnitPrice);
END
GO

CREATE PROCEDURE UpdateProduct (
@ProductID int,
@ProductName nvarchar(40),
@SupplierID int = null,
@CategoryID int = null,
@UnitPrice money = null
) AS
BEGIN
	UPDATE [dbo].[Products] SET ProductName = @ProductName, SupplierID = @SupplierID, CategoryID = @CategoryID, UnitPrice = @UnitPrice
	WHERE ProductID = @ProductID;
END
GO

CREATE PROCEDURE DeleteProduct (
@ProductID int
) AS
BEGIN
	DELETE FROM [dbo].[Products]
	WHERE ProductID = @ProductID;
END
GO

CREATE PROCEDURE ListAllEmployees
AS
BEGIN
	SELECT * FROM [dbo].[Employees] E
	ORDER BY E.LastName ASC, E.FirstName ASC;
END
GO

CREATE PROCEDURE ListAllCustomers
AS
BEGIN
	SELECT * FROM [dbo].[Customers] C
	ORDER BY C.CompanyName ASC;
END
GO

CREATE PROCEDURE FindOrders (
@OrderDateFrom datetime = null,
@OrderDateTo datetime = null,
@CustomerID nchar(5) = null,
@EmployeeID int = null
)
AS
BEGIN
	SELECT * FROM [dbo].[Orders] O
	WHERE (@CustomerID = NULL OR (O.CustomerID = @CustomerID))
	AND (@EmployeeID = NULL OR (O.EmployeeID = @EmployeeID))
	AND (@OrderDateFrom = NULL OR (O.OrderDate BETWEEN @OrderDateFrom AND @OrderDateTo))
	ORDER BY OrderID DESC;
END
GO

CREATE PROCEDURE InsertOrder (
@CustomerID nchar(5),
@EmployeeID int = null,
@OrderDate datetime = null,
@RequiredDate datetime = null
) AS
BEGIN
	INSERT INTO [dbo].[Orders] (CustomerID, EmployeeID, OrderDate, RequiredDate)
	VALUES (@CustomerID, @EmployeeID, @OrderDate, @RequiredDate);
END
GO

CREATE PROCEDURE InsertOrderDetail (
@OrderID int,
@ProductID int,
@UnitPrice money,
@Quantity smallint,
@Discount real
) AS
BEGIN
	INSERT INTO [dbo].[Order Details] (OrderID, ProductID, UnitPrice, Quantity, Discount)
	VALUES (@OrderID, @ProductID, @UnitPrice, @Quantity, @Discount);
END
GO

/* Procedimientos 2018-02-15 */
CREATE PROCEDURE GetCategory(
@CategoryID int
)
AS
BEGIN
	SELECT C.* FROM [dbo].[Categories] C
	WHERE C.CategoryID = @CategoryID;
END
GO

CREATE PROCEDURE GetProduct(
@ProductID int
)
AS
BEGIN
	SELECT P.*, C.CategoryName, C.Description, S.CompanyName
	FROM [dbo].[Products] P
	LEFT JOIN [dbo].[Categories] C ON P.CategoryID = C.CategoryID
	LEFT JOIN [dbo].[Suppliers] S ON P.SupplierID = S.SupplierID
	WHERE P.ProductID = @ProductID;
END
GO

CREATE PROCEDURE GetSupplier(
@SupplierID int
)
AS
BEGIN
	SELECT S.* FROM [dbo].[Suppliers] S
	WHERE S.SupplierID = @SupplierID;
END
GO

CREATE PROCEDURE GetOrder(
@OrderID int
)
AS
BEGIN
	SELECT O.*, C.CompanyName, E.LastName, E.FirstName FROM [dbo].[Orders] O
	LEFT JOIN [dbo].[Customers] C ON O.CustomerID = C.CustomerID
	LEFT JOIN [dbo].[Employees] E ON O.EmployeeID = E.EmployeeID
	WHERE O.OrderID = @OrderID;
END
GO

CREATE PROCEDURE GetOrderDetails (
@OrderID int
)
AS
BEGIN
	SELECT OD.*, P.ProductName FROM [dbo].[Order Details] OD
	LEFT JOIN [dbo].[Products] P ON OD.ProductID = P.ProductID
	WHERE OD.OrderID = @OrderID;
END
GO