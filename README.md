# Introduction
The main goal of this project is to build an online book store application that contains products for sale, such as books, magazines and music cd’s. Users can create an account and sign up to this application and browse the book store to buy from various products for sale. The book store has a graphical interface on which the users can see the descriptions and details about each product. Users can also manage their shopping carts and examine their invoices using the interface. We used MsSql to store both user and product data.

# Design
   Using MsSql, we created a database to keep, manage and receive user data and product descriptions. User login is handled according to the user data in the database. The product data is received from database and visually presented to the user. The user can view the details about the products and add products to the shopping cart. Upon checkout, the user can select a payment method and may choose to receive the invoice via e-mail. 
* Product class is an abstract class representing each product for sale in the store. Product class’ functions will be overridden by the book, magazine and musiccd classes.
* Customer class represents the current logged in customer. A singleton instance is created and used for the customer operations.
* ShoppingCart class keeps the products added to the cart, the customer that the cart belongs to, the amount of the payment that will be made.
* Product class is inherited by Book, Magazine and MusicCd classes and its functions will be overridden by the same subclasses.
* Customer class’ instance is created using the Singleton pattern so the created singleton object will represent the current logged in customer.
* DataBaseHandler class is used to set up connection with our database and manage signing up and logging in operations. Also, receiving descriptions and details about the products. A singleton instance is created used for database handling operations. 
* FactoryPanelCreator class uses factory pattern to determine the product types and return a product panel according to taken argument
* Logger class keeps the date and time data of the operations made.
* MailSender class sends the invoice to the user’s e-mail address.

### Team Members:

 * [Azmi Cibi](https://github.com/azmicibii) 
 * [Erkin Semiz](https://github.com/ErkinSemiz)
 * [Tahir Özdemir](http://cv.tahirozdemir.com)
 * [Mahmut Bilgehan Serbest](https://github.com/Bilgehan-Serbest)
