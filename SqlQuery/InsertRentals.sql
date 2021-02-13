  insert Rentals values (1,1,GETDATE(),null)
  insert Rentals values (2,1,GETDATE(),null)
  update Rentals set ReturnDate = GETDATE() where CarId =1
