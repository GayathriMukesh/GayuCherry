create database exam
use exam
create table tblCandidates(name varchar(100),
email varchar(100),
phone varchar(10),
username varchar (50) primary key,
password varchar (50))

insert into tblCandidates values('Priya','priya123@gmail.com','9876543210','PriyaSweety','priya123')
insert into tblCandidates values('Gayathri','gayu68@gmail.com','9879663210','GayuCherry','gayu06')
insert into tblCandidates values('Siva','siva456@gmail.com','9876524510','SivaRokzz','siva222')
insert into tblCandidates values('Sowmeya','sowmi@gmail.com','9046843210','SowmiKutti','sowmi39')

select * from tblCandidates

create table tblQuestions(SNo int constraint pk_Sn primary key,TestModel varchar(50),Questions varchar(1000),
Answers varchar(100),option1 varchar(100),option2 varchar(100),option3 varchar(100),option4 varchar(100),
Mark int)

Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(01,'Aptitude',
'A sum of money at simple interest amounts to Rs. 815 in 3 years and to Rs. 854 in 4 years','option3','Rs.650','Rs.690','Rs.698','Rs.700',1)

Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(02,'Aptitude',
'A sum fetched a total simple interest of Rs. 4016.25 at the rate of 9 p.c.p.a. in 5 years. What is the sum?','option4',
'Rs.4462.50',
'Rs.8032.50',
'Rs.8900',
'Rs.8925',
1)

Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(3,'Technical',
'Which of these constructors is used to create an empty String object?','option1',
'String()',
'String(void)',
'String(0)',
'none',
1)


Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(4,'Technical',
'What is the return type of Constructors?','option4',
'int',
'float',
'void',
'none of the mentioned above',
1)


select *from tblQuestions

create proc proc_GetTestTypeQuestions(@TestModel varchar(50))
as
begin
  select * from tblQuestions where TestModel=@TestModel
  end


exec proc_GetAllQuestions 'Aptitude'

create proc proc_GetQuestions
as
begin
select * from tblQuestions
end


create proc proc_AddQuestion(@TestModel varchar(50),@Questions varchar(1000),@Answers varchar(100),@option1 varchar(100),@option2 varchar(100),@option3 varchar(100),@option4 varchar(100),@Mark int)
as
declare @No varchar(10),@null varchar(10),@SNo int,@SNo1 int
set @null = 0

begin	
select @No = (select count(*) from tblQuestions)
if @No = @null
begin
set @SNo = @No+1
insert into tblQuestions values(@SNo,@TestModel,@Questions,@Answers,@option1,@option2,@option3 ,@option4,@Mark)
end
else
begin
select @SNo1 = (select max(SNo) from tblQuestions)
set @SNo1 = @SNo1+1
    insert into tblQuestions values(@SNo1,@TestModel,@Questions,@Answers,@option1,@option2,@option3 ,@option4,@Mark)
end
end
select * from tblQuestions
delete from tblQuestions
exec proc_AddQuestion 'Aptitude','add 2+2','4','1','4','3','5','1'
insert into tblQuestions values('1','Aptitude','add 2+2','4','1','4','3','5','1')

update tblQuestions set SNo=10 where SNo=215

create proc proc_GetTestType(@testtype varchar(50))
as begin
select SNo,Questions,Answers,option1,option2,option3,option4,Mark from tblQuestions where TestModel=@testtype
end

exec proc_GetTestType'Aptitude'

create proc proc_UpdateQuestion(@TestModel varchar(50),@Question varchar(1000),@Answer varchar(100),@option1 varchar(100),
@option2 varchar(100),@option3 varchar(100),@option4 varchar(100),@Mark int,@SNo int)
as
begin
    update tblQuestions set TestModel=@TestModel,Questions=@Question,Answers=@Answer,option1=@option1,option2=@option2,
         option3=@option3,option4=@option4,Mark=@Mark where SNo=@SNo
end

exec proc_UpdateQuestion 'Aptitude','eeeeeeee','option1','qwerfds','erefdfd','ewewe','tryuii','1','10'

create proc proc_DeleteQuestion(@SNo int)
as 
declare @inc int
set @inc = 1
begin
delete from tblQuestions where SNo=@SNo
while(@inc <= 10000)
begin 
update tblQuestions set SNo = @inc where SNo=(select min(SNo) as T from tblQuestions where SNo > @inc )
set @inc = @inc + 1
end
end
exec proc_DeleteQuestion '1'



create table tblRegisterDetails(name varchar(100),
email varchar(100),
phone varchar(10),
username varchar (50) primary key)

insert into tblRegisterDetails values('Priya','priya123@gmail.com','9876543210','PriyaSweety')
insert into tblRegisterDetails values('Gayathri','gayu68@gmail.com','9879663210','GayuCherry')
insert into tblRegisterDetails values('Siva','siva456@gmail.com','9876524510','SivaRokzz')
insert into tblRegisterDetails values('Sowmeya','sowmi@gmail.com','9046843210','SowmiKutti')

create proc proc_GetUserDetails
as
begin
  select *from tblRegisterDetails
end

exec proc_GetUserDetails

-------------------------------------------------------------------------------
create table tblAdminDetails
(Admin_name varchar(100),Admin_email varchar(100),Admin_phone varchar(10),Admin_username varchar(50))

insert into tblAdminDetails values('Ahamed','ahamed123@gmail.com','9876547810','ahamed123')
insert into tblAdminDetails values('Aravind','aravind68@gmail.com','9879664410','aravind456')
insert into tblAdminDetails values('ShanmugaPriya','priya456@gmail.com','9876524890','priyasp789')
insert into tblAdminDetails values('Gayathri','gayu11@gmail.com','9054843210','gayu012')
insert into tblAdminDetails values('Sowmeya','sowmeya123@gmail.com','9876987810','sowmi123')
insert into tblAdminDetails values('Anusha','anu68@gmail.com','9779664410','anusha456')
insert into tblAdminDetails values('Priya','priya456@gmail.com','9876524890','priya789')
insert into tblAdminDetails values('ShivaGanesh','siva11@gmail.com','9054843210','siva012')

drop table tblAdminDetails
create proc proc_AdminDetails

as
begin
 select *from tblAdminDetails
end


exec proc_AdminDetails
----------------------------------------------------------------------------------------------------------------
create table tblPaidUsers(name varchar(100),
email varchar(100),
phone varchar(10),
TestModel varchar(50),date varchar(20))

insert into tblPaidUsers values('Priya','priya123@gmail.com','9876543210','Aptitude','26/12/2019')
insert into tblPaidUsers values('Gayathri','gayu68@gmail.com','9879663210','Technical','27/12/2019')
insert into tblPaidUsers values('Siva','siva456@gmail.com','9876524510','Aptitude','28/12/2019')
insert into tblPaidUsers values('Gayathri','gayu11@gmail.com','9054843210','Technical','29/12/2019')

create proc proc_GetPaidUsers
as
begin
  select  *from tblPaidUsers
end

exec proc_GetPaidUsers
---------------------------------------------------------------------------------------------------------


create table tblScores(name varchar(50),email varchar(100),phone varchar(10),Testmodel varchar(50),score int)

insert into tblScores values('Priya','priya123@gmail.com','9876543210','Aptitude',8)
insert into tblScores values('Gayathri','gayu68@gmail.com','9879663210','Technical',7)
insert into tblScores values('Siva','siva456@gmail.com','9876524510','Aptitude',9)
insert into tblScores values('Gayathri','gayu11@gmail.com','9054843210','Technical',9)

create proc proc_GetScoreDetails
as
begin
select *from tblScores
end

exec proc_GetScoreDetails
