use Pubs
--1) Create a stored procedure that will take the author firstname and print all the books polished by him with the publisher's name

create proc GetBooksByAuthor
    @AuthorFirstName varchar(30)
as
begin
    select 
        t.title AS 'Book Name',
        p.pub_name AS 'Publisher Name'
    from 
        titles t
    join 
        titleauthor ta on ta.title_id = t.title_id
	join 
		authors a on a.au_id=ta.au_id
    join
        publishers p on t.pub_id = p.pub_id
    where 
        a.au_fname = @AuthorFirstName;
end;

exec GetBooksByAuthor @AuthorFirstName = 'Johnson';

select * from authors

--2) Create a sp that will take the employee's firtname and print all the titles sold by him/her, price, quantity and the cost.

select * from employee
create proc GetEmployeesSalesDetails
    @EmpFirstName varchar(30)
as
begin
	select 
		t.title 'Title', t.price 'Price', s.qty 'Quantity', (s.qty*t.price) 'Cost'  from employee e
	join
		titles t on t.pub_id=e.pub_id
	join 
		sales s on s.title_id=t.title_id
	where e.fname=@EmpFirstName
end;

exec GetEmployeesSalesDetails @EmpFirstName='Paolo'

--3) Create a query that will print all names from authors and employees
select concat(au_fname,au_lname) 'Names' from authors 
union
select concat(fname,lname) from employee

--4) Create a  query that will float the data from sales,titles, publisher and authors table to print title name, Publisher's name, author's full name with quantity ordered and price for the order for all orders,
 --print first 5 orders after sorting them based on the price of order
 select top 5 t.title 'Title Name', p.pub_name 'Publisher Name', 
 concat(a.au_fname,a.au_lname) 'Author Name', s.qty 'Qunatity Ordered', 
 (t.price*s.qty) 'Price for the order',s.ord_num 'Order Number'
 from titles t
 join publishers p on t.pub_id=p.pub_id
 join titleauthor ta on ta.title_id = t.title_id
 join authors a on ta.au_id=a.au_id
 join sales s on s.title_id=t.title_id
 order by t.price


