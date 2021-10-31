# Accomadation_Booking_Application
University accomadation booking system (C#, Material design)

**Requirements:**
C# WinForms




**_Classes:_**

_Student class_

We all have an idea of a person who has a name, age, and some other characteristics. That is, some template - this template can be called a class. The exact embodiment of this pattern may differ, for example, some people have one name, others a different name. And a real person (a real instance of this class) will be an object of this class. For example, the program has a Student class that has properties: ID, Login, Password, Name, Email, Warden, Gender, Phone. It also has many methods that allow you to work with this class.



_Warden class_


Its properties are: ID, Login, Password, Name, Email, Warden, Gender, Phone.




_DB class_

To simplify working with the database, there is a DB class. It is created in order to define a Connection String, and contains methods that, by checking the connected connection, open or close the connection, this will help to reduce errors, and the connection will not be reopened if it is already open, and will not close if it is already closed. There is also a GetConnection method that simply returns the connection.


**Screenshots:**


