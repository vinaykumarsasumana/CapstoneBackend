create database ShoppingCapstoneDB

use ShoppingCapstoneDB

--drop database ShoppingCapstoneDB

CREATE TABLE SellerRegistration
  ( 
	 SellerRegID int primary key identity(1, 1),
     FirstNAME NVARCHAR(255) NOT NULL,
	 LastName NVarchar(255),
	 EmailID nvarchar(255),
	 SellerPassword nvarchar(255),
	 Country nvarchar(255),
	 MobileNo nvarchar(255),
	 SellerAddress nvarchar(255),
	 CompanyName nvarchar(255),
	 CompanyURL nvarchar(255)
	 ) 
GO  


CREATE TABLE SellerLogin
  ( 	
	SellerLoginId int primary key identity(1,1),
	SellerId int,
     Email nVARCHAR(255) not NULL, 
     SellerPassword nVARCHAR(255) NULL, 
     FOREIGN KEY (SellerId) REFERENCES SellerRegistration(SellerRegID)
  ) 
GO 

drop table SellerLogin

create table ProductTable
(
	ProductId int primary key identity(1,1),
	SellerID int,
	ProductBrandName nvarchar(255),
	ProductType nvarchar(255),
	ProductSubType nvarchar(255),
	ProductName nvarchar(255),
	ProductPrice int,
	DeliveryCharge int,
	ProductDescription nvarchar(1000),
	ProductionCountryOrigin nvarchar(255),
	ProductTermsandCondition nvarchar(1000),
    FOREIGN KEY (SellerID) REFERENCES SellerRegistration(SellerRegID)
);

create table ProductImage
(
	ProductImageID int primary key identity(1,1),
	ProductID int,
	ProductImageURL nvarchar(Max),
	ImageCaption nvarchar(255)
    FOREIGN KEY (ProductID) REFERENCES ProductTable(ProductID)
);

CREATE TABLE BuyerRegistration(
	BuyerRegId int primary key identity(1,1),
	FirstName nvarchar(255) NOT NULL,
	LastName nvarchar(255),
	EmailID nvarchar(255) NOT NULL,
	BuyerPassword nvarchar(255) NOT NULL,
	BuyerAddress nvarchar(255) not null,
	City nvarchar(255) not null,
	BuyerState nvarchar(255) not null,
	Pincode nvarchar(255) not null,
	Country nvarchar(255) NOT NULL,
	MobileNo nvarchar(255) not null,
);

CREATE TABLE BuyerLogin (
	BuyerLoginId int primary key identity(1,1),
	BuyerId int,
	EmailID varchar(50) NOT NULL,
	BuyerPassword varchar(50) NOT NULL,
	FOREIGN KEY (BuyerId) REFERENCES BuyerRegistration(BuyerRegId)
);

Create table OrderTable(
	OrderID int primary key identity(1,1),
	ProductID int,
	BuyerID int,
	SellerID int,
	ProductName nvarchar(255),
	ProductPrice int,
	ProductQuantity int,
	BuyerAddress nvarchar(255),
	City nvarchar(255),
	BuyerState nvarchar(255),
	Pincode nvarchar(255),
	Country nvarchar(255),
	Mobile nvarchar(255),
	Email nvarchar(255),
	DeliverCharge nvarchar(255),
	TotalPrice nvarchar(255),
	Foreign key (BuyerID) References BuyerRegistration(BuyerRegId),
	Foreign key (SellerID) References SellerRegistration(SellerRegId),
	Foreign key (ProductID) References ProductTable(ProductId)
);

--drop table OrderTable
--drop table ProductImage
--drop table CartTable
--drop table Wishlist
--drop table ProductTable
--drop table SellerRegistration
--drop table SellerLogin
--drop table BuyerRegistration
--drop table BuyerLogin

create table CartTable(
	CartId int primary key identity(1,1),
	BuyerId int ,
	ProductId int ,
	ProductName nvarchar(255),
	ProductPrice int,
	ProductQuantity int,
	ProductImage nvarchar(max),
	Foreign key (BuyerID) References BuyerRegistration(BuyerRegId),
	Foreign key (ProductID) References ProductTable(ProductId)
)

create table Wishlist(
	CartId int primary key identity(1,1),
	BuyerId int ,
	ProductId int,
	ProductName nvarchar(255),
	ProductPrice nvarchar(255),
	OneImage nvarchar(max)
	FOREIGN KEY (BuyerId) REFERENCES BuyerRegistration(BuyerRegId),
	FOREIGN KEY (ProductId) REFERENCES ProductTable(ProductId)
)

select * from SellerRegistration

insert into SellerRegistration values ('vini','kumar','string','string','string','string','string','string','string')

select * from SellerLogin

select * from ProductTable
select * from OrderTable
select * from ProductImage
select * from CartTable
select * from Wishlist
select * from BuyerRegistration
select * from BuyerLogin


insert into BuyerLogin values(1,'string','string')
