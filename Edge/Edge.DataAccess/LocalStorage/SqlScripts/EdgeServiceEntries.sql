Declare @Id int
Set @Id = 1

While @Id <= 1000
Begin 
   Insert Into EdgeServices values (@id,'EdgeService-' + CAST(@Id as nvarchar(10)))
   Print @Id
   Set @Id = @Id + 1
End