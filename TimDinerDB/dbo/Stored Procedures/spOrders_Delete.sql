CREATE PROCEDURE [dbo].[spOrders_Delete]
	@Id int
AS
begin 

	Delete
	From [Order]
	where Id = @Id

end