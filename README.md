# Accomadation_Booking_Application
University accomadation booking system (C#, Material design)

## **Requirements:**

```
.NET 5
MySQL 5.6.35
MaterialSkin 2.2.1
```




## **Classes:**

### _Student class_

We all have an idea of a person who has a name, age, and some other characteristics. That is, some template - this template can be called a class. The exact embodiment of this pattern may differ, for example, some people have one name, others a different name. And a real person (a real instance of this class) will be an object of this class. For example, the program has a Student class that has properties: ID, Login, Password, Name, Email, Warden, Gender, Phone. It also has many methods that allow you to work with this class.



### _Warden class_


Its properties are: ID, Login, Password, Name, Email, Warden, Gender, Phone.




### _DB class_

To simplify working with the database, there is a DB class. It is created in order to define a Connection String, and contains methods that, by checking the connected connection, open or close the connection, this will help to reduce errors, and the connection will not be reopened if it is already open, and will not close if it is already closed. There is also a GetConnection method that simply returns the connection.


## **Screenshots:**

### _Login page_

![Login](https://user-images.githubusercontent.com/88096391/139598100-64fb2ee3-13b8-470d-8972-1aeaf1c65b28.PNG)



### _Warden_

![Home](https://user-images.githubusercontent.com/88096391/139598099-d2ec8bc3-87eb-43f9-b6f8-36e52c4c079d.png)
![Feedbacks](https://user-images.githubusercontent.com/88096391/139598096-0cffbca9-379c-4492-a346-f8adde9af98f.png)
![Report](https://user-images.githubusercontent.com/88096391/139598101-fad0f5e7-713e-441a-a84b-6520a0f4c1e0.png)
![Settings](https://user-images.githubusercontent.com/88096391/139598102-214ca598-cec8-4a5a-8701-b619a86a3041.png)
![Assign Rooms](https://user-images.githubusercontent.com/88096391/139598094-ec15cdc8-027e-4117-a101-b5427946f41f.png)


### _Student_

![Home](https://user-images.githubusercontent.com/88096391/139598130-b05448bb-5ea3-43b0-a417-8761d20ef7cb.png)
![Change](https://user-images.githubusercontent.com/88096391/139598128-de5352c6-b6b5-48ec-8c4a-d32f5311333b.png)
![Feedback](https://user-images.githubusercontent.com/88096391/139598129-f43d3809-ddd1-4422-a6e4-f845a99fc313.png)
![Settings](https://user-images.githubusercontent.com/88096391/139598137-3bdf88ca-c999-4aa8-b3c3-19f0c9a22458.png)
![Termination](https://user-images.githubusercontent.com/88096391/139598139-d0c2e584-9638-403f-b4df-f8837b6fdc00.png)
![Book](https://user-images.githubusercontent.com/88096391/139598126-9f2bb7d2-e592-48c3-ad88-c8653d43c22b.png)

