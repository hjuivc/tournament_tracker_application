-- =============================================
-- Author:		<Bj�rnar, Borge>
-- Create date: <11.01.2023>
-- Description:	<Stored procedure for inserting people>
-- =============================================
CREATE PROCEDURE dbo.spPeople_Insert
	-- Add the parameters for the stored procedure here
	@FirstName nvarchar(100),
	@LastName nvarchar(100),
	@EmailAddress nvarchar(100),
	@CellphoneNumber varchar(20),
	@id int = 0 output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into dbo.People(FirstName, LastName, EmailAddress, CellphoneNumber)
	values (@FirstName, @LastName, @EmailAddress, @CellphoneNumber);

	select @id=SCOPE_IDENTITY();
END
GO
