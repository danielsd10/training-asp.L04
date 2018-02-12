/* Procedimientos */

CREATE PROCEDURE ListAllCategories
AS
BEGIN
	SELECT * FROM [dbo].[Categories] C
	ORDER BY C.CategoryName ASC;
END
GO