create trigger trg_createCustomerAfterUsersInsert
on Users
after insert
as
begin 
declare @Id int
	select @ýd=Id from inserted
	insert Customers(UserId,FindeksScore) values(@Id,1900)
end