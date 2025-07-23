# BillsSystem

A simple billing management system built with **ASP.NET Core MVC 8** and **ASP.NET Identity**.  
This project demonstrates a real-world implementation of invoice tracking, customer relations, product listings, and payment history in a web application context.

---

## ⚙️ Features

- Full CRUD for Customers, Products, Invoices (Bills), and Payments
- Associate multiple items with each invoice (BillItems)
- Automatic financial calculations: Total, Discount, Net, Paid, Remaining
- Admin dashboard showing real-time statistics
- Identity system integrated for user linkage and data ownership
- Seeded test data (customers, items, bills, payments)

---

## 👤 Admin User

- **Username:** `admin`
- **Email:** `admin@example.com`
- **Note:** This admin account exists in the database only for internal linking.  
  No password has been assigned — login is disabled for this user.

---

## 📦 Seeded Data

To allow direct functionality and testing, the following were inserted manually via SQL:

- 10 Customers
- 10 Products
- 11 Invoices (Bills)
- Each invoice has associated BillItems
- Each invoice has a Payment record (some partial, some full)

---

## 🚀 Getting Started

1. Clone the repository
2. Ensure SQL Server is running
3. Run `Update-Database` to apply migrations
4. Start the app and explore the system

---

## 🔍 Notes & Limitations

- No actual login is enabled at the moment (Admin has no password hash)
- No role-based authorization implemented yet
- No PDF export or reporting features
- UI is based on default Bootstrap styling without customization
- No unit tests or CI/CD pipeline configured

---

## 📁 Project Purpose

This project was developed as part of a training task,  
meant to reflect a realistic grasp of MVC structure, entity relationships, and real data interaction —  
not just UI mockups.

---

## 🧠 Developed by

**Nour Ghobashy**  
Final delivery commit includes:
- Working system logic
- Populated database
- Ready-to-demo functionality

