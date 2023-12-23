USE [Sample]
GO

/****** Object:  StoredProcedure [dbo].[SearchProducts]    Script Date: 23-12-2023 19:03:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SearchProducts]
    @ProductName NVARCHAR(255) = NULL,
    @Size NVARCHAR(50) = NULL,
    @Price INT = NULL,
    @MfgDate DATETime = NULL,
    @Category NVARCHAR(50) = NULL,
    @Conjunction NVARCHAR(30) = 'AND'
AS
BEGIN
    SET NOCOUNT ON;
	print(@Conjunction)
    DECLARE @SqlQuery NVARCHAR(MAX);

    SET @SqlQuery = '
        SELECT *
        FROM tbl_Product 
		';

	Declare @Conditions nvarchar(max) = ''

    IF @ProductName IS NOT NULL
		If @Conditions = ''
			SET @Conditions = ' WHERE (ProductName LIKE ''%' + @ProductName + '%'') ';
		ELSE
			SET @Conditions = @Conditions + + @Conjunction + ' (ProductName LIKE ''%' + @ProductName + '%'') ';

    IF @Size IS NOT NULL
		If @Conditions = ''
			SET @Conditions = ' WHERE (Size = '''+@Size+''') ';
		ELSE
			SET @Conditions = @Conditions + @Conjunction + ' (Size = '''+@Size+''') ';

    IF @Price IS NOT NULL
		If @Conditions = ''
			SET @Conditions =  ' WHERE (Price = Cast('+ Cast(@Price as nvarchar)+' as int)) ';
		ELSE
			SET  @Conditions =  @Conditions + @Conjunction + ' (Price = Cast('+ Cast(@Price as nvarchar)+' as int)) ';

    IF @MfgDate IS NOT NULL
		If @Conditions = ''
			SET @Conditions  = ' WHERE (Cast(MfgDate as date) = convert(date,'+''''+cast(@MfgDate as nvarchar)+''''+',107)) ';
		ELSE
			SET @Conditions  = @Conditions +  @Conjunction + ' (Cast(MfgDate as date) = convert(date,'+''''+cast(@MfgDate as nvarchar)+''''+',107)) ';

    IF @Category IS NOT NULL
		If @Conditions = ''
			SET @Conditions = ' WHERE (Category LIKE ''%'+@Category+'%'') ';
		ELSE
			SET @Conditions = @Conditions + @Conjunction + '(Category LIKE ''%'+@Category+'%'') ';

    SET @SqlQuery = @SqlQuery + @Conditions + ' ORDER BY ProductId;';

	print(@SqlQuery)

    EXEC sp_executesql @SqlQuery

END

GO


