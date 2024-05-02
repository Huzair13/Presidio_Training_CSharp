use pubs

--1)Print all the titles names
select title 'Titles' from titles

select * from titles

--2) Print all the titles that have been published by 1389
select title 'Titles' , pub_id 'Published by' from titles where pub_id = 1389

--3) Print the books that have price in rangeof 10 to 15
select title_id 'ID', title 'Book', type 'Book Type',price 'Price' from titles where price between 10 and 15

--4) Print those books that have no price
select title_id 'ID', title 'Book', type 'Book Type',price 'Price' from titles where price is NULL

--5) Print the book names that strat with 'The'
select title_id 'Book Id',title 'Book Names starting with THE' from titles where title like 'The%'

--6) Print the book names that do not have 'v' in their name
select title_id 'Book Id',title 'Book Names with no v letter' from titles where title not like '%v%' 

--7) print the books sorted by the royalty
select title_id 'ID', title 'Book' , royalty 'Royalty'  from titles order by royalty

--8) print the books sorted by publisher in descending then by types in asending then by price in descending
select title_id 'ID', title 'Book', pub_id 'Publisher', type 'Book Type',price 'Book Price'
from titles
order by pub_id desc,type, price desc

--9) Print the average price of books in every type
select avg(price) 'Average Price' ,type 'Book Type' from titles 
group by type

--10) print all the types in uniques
select distinct type 'Distinct Book Types' from titles

--11) Print the first 2 costliest books
select top(2) title_id 'ID', title 'Book', price 'Book Price' 
from titles order by price desc

--12) Print books that are of type business and have price less than 20 which also have advance greater than 7000
select title_id 'ID', title 'Book'from titles where type='business' and (price<20 and advance>7000)

--13) Select those publisher id and number of books which have price between 15 to 25 and have 'It' in its name. 
--Print only those which have count greater than 2. Also sort the result in ascending order of count

select pub_id, COUNT(title) 'Number of Books' from titles
where price BETWEEN 15 AND 25 AND title LIKE '%It%'
group by pub_id
having count(title) > 2
order by count(title) ;

select * from authors

--14) Print the Authors who are from 'CA'
select au_id 'Author ID',au_fname 'First Name', au_lname 'Last Name' , state 'State'
from authors  where state='CA'

--15) Print the count of authors from every state
select count(au_id) 'count of Author' , state 'State of author' 
from authors group by state