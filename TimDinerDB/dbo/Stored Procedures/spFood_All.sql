CREATE PROCEDURE [dbo].[spFood_All]
AS
begin

	-- return one last piece of information about how many records you queried
	set nocount on; 

	select [Id], [Title], [Description], [Price]
	from dbo.Food;


end
