## Description 

### Task 1. Book service
Develop a Book class (ISBN, author, title, publisher, year of publication,
number of pages, price), overriding for it the necessary Object class methods. 
For class objects implement equivalence and order relations. (using appropriate 
interfaces). To perform basic operations with
a list of books that can be downloaded and, if necessary,
save to some BookListStorage storage; develop BookListService class
(as a service for working with a collection of books) with functionality: 
* AddBook  (add a book if there is no such book, otherwise throw an exception); 
* RemoveBook (remove the book if it is, otherwise throw an exception);
* FindBookByTag (find a book by a given criterion); 
* SortBooksByTag (sort list of books by a given criterion).

Usebinary file as storage, to work with it use only the classes BinaryReader,
BinaryWriter. Storage can be changed / added later.

### Task 2. Bank system
Develop a type system for describing work with a bank account. condition
account is determined by its number, data on the account holder (name, surname), amount
on the account and some bonus points that increase / decrease
each time you refill an account / debit an account with values different for
replenishment and write-off and calculated depending on some values
values of the "value" of the balance and the "cost" of replenishment. The value of "cost"
balance and replenishment “costs” are integer values and depend on
from the gradation of the account.

To work with the account to realize the following features:
* make a deposit to the account;
* write off the account;
* create a new account;
* close an account.
Information about the accounts stored in a binary file.

Take into account that the functionality may expand or change:
* adding new types of accounts;
* change / add sources of information storage about accounts;
* change the logic of calculating bonus points.