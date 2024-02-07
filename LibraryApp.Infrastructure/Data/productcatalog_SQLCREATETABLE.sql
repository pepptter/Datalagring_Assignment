CREATE TABLE Categories
(
	Id int not null identity primary key,
	CategoryName nvarchar(100) not null unique
)

CREATE TABLE Products
(
	ArticleNumber nvarchar(100) not null primary key,
	Title nvarchar(200) not null,
	Description nvarchar(max) not null,
	Price money not null,
	CategoryId int not null references Categories(Id)
)