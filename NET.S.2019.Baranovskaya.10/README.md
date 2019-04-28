## Description 

### Task 1. Book

Implement for Book class objects the possibility of a different string representation.

For example, object: ISBN = 978-0-7356-6745-7, AuthorName
= Jeffrey Richter, Title = CLR via C#, Publisher = Microsoft Press, Year = 2012,
NumberOPpages = 826, Price = 59.99$  can be displayed as:

* Jeffrey Richter, CLR via C#
* Jeffrey Richter, CLR via C#, &quot;Microsoft Press&quot;, 2012
* ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, &quot;Microsoft Press&quot;,
2012, P. 826.
* Jeffrey Richter, CLR via C#, &quot;Microsoft Press&quot;, 2012
* ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, &quot;Microsoft Press&quot;,
2012, P. 826., 59.99$.


### Task 2. Book

Without changing the class Book, add additional objects for this class.
formatting capability not originally provided by the class.

### Task 3. Book

Create Unit-tests for the functionalities implemented in the first and second tasks.

### Task 4. GCD

Perform class refactoring (to reduce re-code) in algorithms
Euclid (for refactoring to use delegates, refactoring is possible only in
case when all methods are in the same class!). Class interface does not change
should.
Perform class refactoring (to reduce re-code) in Euclid algorithms using delegates. Class interface shouldn't change.

### Task 5. Sorting

Work with Sorting class that get interface IComparer<int> as acomparator:

* add method that take delegate comparator as a parameter and encapsulate the logic of comparison of rows of the matrix.
* test this method using previous comparison criteria. 
Implement a class in two ways: "Closing" in the first embodiment, the implementation of the method of sorting with the delegate to the method with
interface, and the opposite in the second way.