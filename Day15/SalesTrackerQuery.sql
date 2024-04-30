--Create Database called Sales Tracker
create database SalesTrackerDatabase

--Using SalesTracker Database
use SalesTrackerDatabase

--Create Item Table
create table Items
(
ItemName varchar(40)
constraint pk_itemName primary key(ItemName),
ItemType varchar(20),
ItemColor varchar(10)
)

sp_help Items


--Create Department Table
create table Departments
(
DeptName varchar(20)
constraint pk_deptName primary key(DeptName),
DeptFloor int,
DeptPhone char(10),
DepHead int
)

--Create Employee  Table
create table Employees (
    empNo int constraint pk_empNo primary key(empno),
    empName varchar(100),
    salary float,
    deptName varchar(20) ,
    bossNo int ,
    constraint fk_empDepartment foreign key (deptName) references Departments(deptName),
    constraint fk_empBoss foreign key (bossNo) references Employees(empNo)
);


--create table for Sales
create table Sales (
    salesNo int primary key,
    saleQty int,
    ItemName varchar(40) constraint fk_sales_item foreign key references Items(ItemName),
    DeptName varchar(20) constraint fk_sales_department foreign key references Departments(DeptName)
);

sp_help sales


--Insert Items data
insert into Items (ItemName, ItemType, ItemColor) values
('Pocket Knife-Nile', 'E', 'Brown'),
('Pocket Knife-Avon', 'E', 'Brown'),
('Compass', 'N', '--'),
('Geo positioning system', 'N', '--'),
('Elephant Polo stick', 'R', 'Bamboo'),
('Camel Saddle', 'R', 'Brown'),
('Sextant', 'N', '--'),
('Map Measure', 'N', '--'),
('Boots-snake proof', 'C', 'Green'),
('Pith Helmet', 'C', 'Khaki'),
('Hat-polar Explorer', 'C', 'White'),
('Exploring in 10 Easy Lessons', 'B', '--'),
('Hammock', 'F', 'Khaki'),
('How to win Foreign Friends', 'B', '--'),
('Map case', 'E', 'Brown'),
('Safari Chair', 'F', 'Khaki'),
('Safari cooking kit', 'F', 'Khaki'),
('Stetson', 'C', 'Black'),
('Tent - 2 person', 'F', 'Khaki'),
('Tent -8 person', 'F', 'Khaki');

--Select all rows
select * from items


--create department table
insert into Departments(DeptName, DeptFloor, DeptPhone) values
('Management', 5, 34),
('Books', 1, 81),
('Clothes', 2, 24),
('Equipment', 3, 57),
('Furniture', 4, 14),
('Navigation', 1, 41),
('Recreation', 2, 29),
('Accounting', 5, 35),
('Purchasing', 5, 36),
('Personnel', 5, 37),
('Marketing', 5, 38);


--select departments table
select * from Departments



--Add Employees Table Details
insert into Employees(empNo, empName, salary, deptName, bossNo) values
(1, 'Alice', 75000, 'Management', NULL),
(2, 'Ned', 45000, 'Marketing', 1),
(3, 'Andrew', 25000, 'Marketing', 2),
(4, 'Clare', 22000, 'Marketing', 2),
(5, 'Todd', 38000, 'Accounting', 1),
(6, 'Nancy', 22000, 'Accounting', 5),
(7, 'Brier', 43000, 'Purchasing', 1),
(8, 'Sarah', 56000, 'Purchasing', 7),
(9, 'Sophile', 35000, 'Personnel', 1),
(10, 'Sanjay', 15000, 'Navigation', 3),
(11, 'Rita', 15000, 'Books', 4),
(12, 'Gigi', 16000, 'Clothes', 4),
(13, 'Maggie', 11000, 'Clothes', 4),
(14, 'Paul', 15000, 'Equipment', 3),
(15, 'James', 15000, 'Equipment', 3),
(16, 'Pat', 15000, 'Furniture', 3),
(17, 'Mark', 15000, 'Recreation', 3);

--select employee rows
select * from Employees

--insert sales data
insert into Sales(salesNo, saleQty, ItemName, DeptName) values
(101, 2, 'Boots-snake proof', 'Clothes'),
(102, 1, 'Pith Helmet', 'Clothes'),
(103, 1, 'Sextant', 'Navigation'),
(104, 3, 'Hat-polar Explorer', 'Clothes'),
(105, 5, 'Pith Helmet', 'Equipment'),
(106, 2, 'Pocket Knife-Nile', 'Clothes'),
(107, 3, 'Pocket Knife-Nile', 'Recreation'),
(108, 1, 'Compass', 'Navigation'),
(109, 2, 'Geo positioning system', 'Navigation'),
(110, 5, 'Map Measure', 'Navigation'),
(111, 1, 'Geo positioning system', 'Books'),
(112, 1, 'Sextant', 'Books'),
(113, 3, 'Pocket Knife-Nile', 'Books'),
(114, 1, 'Pocket Knife-Nile', 'Navigation'),
(115, 1, 'Pocket Knife-Nile', 'Equipment'),
(116, 1, 'Sextant', 'Clothes'),
(117, 1, '', 'Equipment'),
(118, 1, '', 'Recreation'),
(119, 1, '', 'Furniture'),
(120, 1, 'Pocket Knife-Nile', 'Navigation'),
(121, 1, 'Exploring in 10 easy lessons', 'Books'),
(122, 1, 'How to win foreign friends', 'Recreation'),
(123, 1, 'Compass', 'Navigation'),
(124, 1, 'Pith Helmet', 'Equipment'),
(125, 1, 'Elephant Polo stick', 'Recreation'),
(126, 1, 'Camel Saddle', 'Recreation');

--select all rows from sales table
select * from Sales


--update department head id 
update Departments
set DepHead = 1
where DeptName='Management';

update Departments
set DepHead = 4
where DeptName='Books';

update Departments
set DepHead = 4
where DeptName='Clothes';

update Departments
set DepHead = 3
where DeptName='Equipment';

update Departments
set DepHead = 3
where DeptName='Furniture';

update Departments
set DepHead = 3
where DeptName='Navigation';

update Departments
set DepHead = 4
where DeptName='Recreation';

update Departments
set DepHead = 5
where DeptName='Accounting';

update Departments
set DepHead = 7
where DeptName='Purchasing';

update Departments
set DepHead = 9
where DeptName='Personnel';

update Departments
set DepHead = 2
where DeptName='Marketing';

select * from Departments