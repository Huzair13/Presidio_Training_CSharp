use Pubs

--1) Print the storeid and number of orders for the store
select st.stor_id 'Store ID', sum(qty) from stores st 
join sales s on st.stor_id=s.stor_id
group by st.stor_id

--2) print the numebr of orders for every title
select t.title 'Title',count(s.ord_num) from titles t 
join sales s on s.title_id=t.title_id
group by t.title

--3) print the publisher name and book name
select p.pub_name 'Publisher Name', t.title 'Book Name' from publishers p 
join titles t on p.pub_id=t.pub_id
order by 1

--4) Print the author full name for all the authors
select concat(a.au_fname,a.au_lname) "Author's Full Name" from authors a;

--5) Print the price or every book with tax (price+price*12.36/100)
select title 'Book',(price+price*12.36/100) 'Price With Tax' from titles

--6) Print the author name, title name
select concat(a.au_fname,au_lname) 'Author Name',t.title 'Title Name' from titles t 
join titleauthor ta on t.title_id=ta.title_id 
join authors a on ta.au_id =a.au_id

--7) print the author name, title name and the publisher name
select concat(a.au_fname,au_lname) 'Author Name',t.title 'Title Name' , p.pub_name 'Publisher Name' 
from titles t 
join titleauthor ta on t.title_id=ta.title_id 
join authors a on ta.au_id =a.au_id
join publishers p on p.pub_id=t.pub_id

--8) Print the average price of books pulished by every publicher
select pub_id 'Publisher ID' ,avg(price) 'Average Price'
from titles group by pub_id

--9) print the books published by 'Marjorie'
select t.title 'Books' from titles t 
where t.pub_id= 
(select pub_id from publishers where pub_name='Marjorie')

--10) Print the order numbers of books published by 'New Moon Books'
select ord_num from sales where title_id in
(select title_id from titles where pub_id= 
(select pub_id from publishers where pub_name='New Moon Books'))

--11) Print the number of orders for every publisher
select p.pub_name 'Publisher ID',count(s.qty)'Number of orders' 
from publishers p 
join titles t on p.pub_id=t.pub_id
join sales s on s.title_id=t.title_id
group by p.pub_name

--12) print the order number , book name, quantity, price and the total price for all orders
select s.ord_num 'Order Number' ,
t.title 'Book Name',
s.qty 'Quantity',
t.price 'Price',
(t.price * s.qty) 'Total Price'
from sales s join titles t on t.title_id = s.title_id

--13) print he total order quantity fro every book
select t.title 'Book',sum(s.qty) 'Total Order Quantity' 
from titles t 
join sales s on s.title_id=t.title_id
group by t.title

--14) print the total ordervalue for every book
select t.title 'Book',sum(s.qty * t.price) 'Total Order value' 
from titles t 
join sales s on s.title_id=t.title_id
group by t.title

--15) print the orders that are for the books published by the publisher for which 'Paolo' works for
select title_id 'Title ID', ord_num 'Order Number' from sales where title_id in
(select  title_id from titles where pub_id=
(select pub_id from employee where fname='Paolo'))
