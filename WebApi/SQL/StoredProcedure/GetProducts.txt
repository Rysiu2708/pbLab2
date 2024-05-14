CREATE PROCEDURE GetProducts
    @SortBy NVARCHAR(50),
    @FilterByName NVARCHAR(100),
    @FilterByGroupName NVARCHAR(100),
    @FilterByGroupId INT = NULL,
    @IncludeInactive BIT = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.Id,
        p.Name,
        p.Price,
        g.Name AS GroupName
    FROM 
        Products p
    INNER JOIN 
        ProductGroups g ON p.GroupId = g.Id
    WHERE 
        (@IncludeInactive = 1 OR p.IsActive = 1)
        AND (@FilterByGroupId IS NULL OR p.GroupId = @FilterByGroupId)
        AND (@FilterByName IS NULL OR p.Name LIKE '%' + @FilterByName + '%')
        AND (@FilterByGroupName IS NULL OR g.Name LIKE '%' + @FilterByGroupName + '%')
    ORDER BY
        CASE WHEN @SortBy = 'Name' THEN p.Name END,
        CASE WHEN @SortBy = 'Price' THEN p.Price END,
        CASE WHEN @SortBy = 'GroupName' THEN g.Name END;
END