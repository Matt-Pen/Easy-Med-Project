# About This Project
This project entitled **"Easy-Medicine"**, has been designed to streamline the process of 
managing a pharmacy and to make it easier to do the tasks. Some of the functions it will 
contain is have a billing system and a system to control and keep track of the inventory of 
medicines. 

It is designed to be used by 2 users, the pharmacist and the assistant or cashier. The person 
in control is decided by the login information of the employee. If the assistant or cashier is 
logging in, then they can only make use of the billing system as they are not qualified to 
interact with the inventory. 

If the pharmacist logs in, they can access and use both the billing system and manage the 
inventory database. 

When using the billing system all the medicine present in the database will show as a drop
down list so you can choose instead of typing it and the price for one will also be 
automatically displayed and all the user has to do is enter the quantity of items chosen. 

It will be capable of keeping count of how many of each medicine is in the inventory and 
deduct the quantity as sales take place. When using the inventory function, it will consist of
a user-friendly interface where you can view all the medicines and also add and remove 
them. 
It will also be capable of generating reports on various topics such as the payment history 
for a specific time period or get the purchase history of a particular customer. 

The Easy-Medicine application will be created using VB.NET for the front end and MySQL 
for backend. 

# Features/Modules
<ins>**1) Login Module:** </ins> The user that is in control of the system is decided by the login page.

- a) Pharmacist: This user has total control of the system and can access all the functions. 

- b) Cashier/Assistant: This user can only access the Billing system as they are not qualified to access the other functions.

<ins>**2) Product Module:** </ins> Contains all the data related to the functioning of a pharmacy. It has the functions to 
add, update and remove data from the database allowing the user make all the necessary changes.
 
- a) Adding/updating/Deleting products and supplier details from the database.

- b) View the current records in the database

- c) Store details of the Suppliers.

<ins>**3) Billing Module:** </ins> This billing system allows the Pharmacist or Cashier to add medicines to and order 
and confirm payment. Unique customer is created for each customer. You can add and remove items 
from the cart, and the selected quantity of the product is deducted from the database. 
 
- a) Add to cart 

- b) Payment: Cash or Card 

<ins>**4) Reports Module:** </ins> It is capable of creating reports based on the data in the database or certain search 
conditions. The final printed pdf will contain the total of what is shown also display the search condition 
if there is any.

- a) Customer Purchase Reports 

- b) Supplier Purchase Reports 

- c) Payment Reports 

- d) Inventory Reports


# Screenshots (Form Design)

### Login Form

<img src="https://github.com/user-attachments/assets/656ac6a1-f07e-4758-ac2d-13675e8b38c7" alt="login Form" width="825" height="500">


### Pharmacist Dashboard
<img src="https://github.com/user-attachments/assets/2e76c4af-a83e-49cd-9a32-89b5bf59c110" alt="Pharmacist Dashboard" width="825" height="500">

### Medicine Inventory Management Form

<img src="https://github.com/user-attachments/assets/174eb1c3-3dea-4cf8-9507-aae26442c74e" alt="Medicne Imventory Management Form" width="825" height="500">


### Supplier Details Form

<img src="https://github.com/user-attachments/assets/0ca06504-9987-48b2-b205-7296585ac949" alt="Supplier Details Form" width="825" height="500">

### Supplier Purchase Form

<img src="https://github.com/user-attachments/assets/d88fd227-bfa9-40b6-a65b-fbe96a84e70a" alt="Supplier Purchase Form" width="825" height="500">

### Billing System Form

<img src="https://github.com/user-attachments/assets/fef7e560-270e-45b9-92ed-18aef7b4f9d9" alt="Billing System Form" width="825" height="500">

### Payment Portal Form

<img src="https://github.com/user-attachments/assets/d2b87a4e-8278-4c58-94e3-9cc9a146a2a0" alt="Payment Portal Form" width="550" height="550">


### Payment Summary Form(Report Formation and Viewing)

<img src="https://github.com/user-attachments/assets/3b94fbc2-25da-44d6-954d-cbd0ac45f41d" alt="Payment Summary Form" width="825" height="500">

### Inventory Summary Form(Report Formation and Viewing)

<img src="https://github.com/user-attachments/assets/7a46f55d-cbe3-4987-b040-c66c7f5ce816" alt="Inventory Summary Form" width="825" height="500">


### Customer Purchase SummaryForm(Report Formation and Viewing)

<img src="https://github.com/user-attachments/assets/bb629396-16c6-4578-a5cb-e39e39318e00" alt="Cust purch Summary Form" width="825" height="500">

### Supplier Purchase Summary Form(Report Formation and Viewing)

<img src="https://github.com/user-attachments/assets/f1ed717a-c361-49e6-a2ab-82d56f7cba54" alt="supp purch Summary Form" width="825" height="500">

### Inventory Summary Print Preview(Form That Is Turned To PDF)

<img src="https://github.com/user-attachments/assets/81333393-ed03-40d5-9858-0ea0f93c3121" alt="inventory Summary PP Form" width="600" height="685">

### Customer Purchase Summary Print Preview(Form That Is Turned To PDF)

<img src="https://github.com/user-attachments/assets/f52f7288-259b-448e-b93f-58f8613c906d" alt="cust purch Summary PP Form" width="600" height="685">

### Supplier Purchase Summary Print Preview(Form That Is Turned To PDF)

<img src="https://github.com/user-attachments/assets/c8f03c86-4fd5-4d9a-b187-864f0452058f" alt="supp purch Summary PP Form" width="600" height="685">

### Payment Summary Print Preview(Form That Is Turned To PDF)

<img src="https://github.com/user-attachments/assets/496045d9-1072-48f7-bb51-cbdaf2f7652f" alt="payment purch Summary PP Form" width="600" height="685">

# Table Stuctures(Using MySQL Workbench)

### Login Table

#### **Description**: Contains all the usernames, passwords and designations.

![1 Login](https://github.com/user-attachments/assets/16695a8d-a7bb-456e-b64b-05bc8d2c1c5e)

## Medicine Table

#### **Description**: Stores all the details of the medicine, how much it costs and how many in stock.

![2 Medicine](https://github.com/user-attachments/assets/5c8b6f5a-f554-4a21-b88b-1ce8b013b54e)

## Supplier Details Table

#### **Description**: Stores all the details about Suppliers.

![3 Supplier Details](https://github.com/user-attachments/assets/41fc7727-d575-40d5-9f50-a585cfc42741)

## Customer Table

#### **Description**: Contains the customer ID and their phone number.

![4 Customer](https://github.com/user-attachments/assets/865d2f58-f2c9-4e53-aeca-9b8075fe3cc7)

## Supplier Purchase Table

#### **Description**: Stores information about what item was bought and how much was paid between to the supplier.

![5 Supplier Purchase](https://github.com/user-attachments/assets/a3f123b0-ce08-4e8e-a16f-54b5c293d71e)

## Customer Purchase Table

#### **Description**: Stores Information of what item was bought by which customer.

![6 Cust Purchase](https://github.com/user-attachments/assets/68e7237e-7a07-467e-9ddc-85a93febfefb)

## Payment Table

#### **Description**: Stores all the transaction history with both customer and supplier.

![7 Payment](https://github.com/user-attachments/assets/5e3a650e-784b-4197-8de1-a4abeb029d55)

## Report ID Table

#### **Description**: Stores report ID which is incremented after every report generation.

![8 report id](https://github.com/user-attachments/assets/dad9a7a6-20c2-4a09-bd62-c0b5c850d68a)

### will be adding more screenshots with data soon..
### Thank you for checking out my project, there are still many improvemnts to be made and hope to do so in the future. Take Care BYE 👋🥳
