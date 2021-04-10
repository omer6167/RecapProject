create trigger chk_findexScore
on Customers
for insert,update
as
declare @findeks int,@Id int
begin 
	select @Id=UserId,@findeks=FindeksScore from inserted
		if(@findeks>1900)
			begin
				update Customers set FindeksScore=1900 where UserId=@Id
			end
		if(@findeks<0)
			begin
				update Customers set FindeksScore=0 where UserId=@Id
			end
end
