## Shopping Cart Web Appllication
> An example product using .Net Core, Bootstrap 4, and database-first approach with SQL

## Scope of Project
Using a SQL sript named `SQLQuery`, which is found in the root directory of the project, to scaffold a database and then build a web application built on its sceme.

The application then randomly adds 12 entites based on the `Product` model upon startup.

A `Cart` contains a collection of these `Products` and their `Order`. The database is updated once a purchase is made on the number of orders made.

## Tools
The following was used to create the project:
- A script written in SQL to scaffold a database
- ASP.Net Core 2.2
- Bootstrap 4