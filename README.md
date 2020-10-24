]

# _Pierre Sweet & Savory_

#### _Week 5 C# ASP.NET MCV w/ MySQL Project for Epicodus, October 23rd, 2020_

#### By _**Natalie Murphy**_

## Description

Bakery site for Pierre with Authentication using Identity. Includes admin.

<!-- Brainstorming
User Authentication
User Login
logged in users can
-create
-update
-delete

anon
-read

flavors
-sweet
-savory
-spicy
-creamy

splash page
-list of all treats

- list of all flavors
  -click on treat oor flavor to see all
  :q
 -->

### Specs

| Spec                                                            | Input | Output |
| :-------------------------------------------------------------- | :---- | :----- |
| 1. Map Enviorment                                               | ...   | ...    |
| 2. Create all models                                            | ...   | ...    |
| 3. Create View Models                                           | ...   | ...    |
| 4. Create User Login                                            | ...   | ...    |
| 5. Create Admin login                                           | ...   | ...    |
| 6. Build Home Controllers and View for Index                    | ...   | ...    |
| 7. Build Snack Views for Index, Create, Details, Delete, Edit   | ...   | ...    |
| 8. Build Flavors Views for Index, Create, Details, Delete, Edit | ...   | ...    |
| 9. Create a Basket for Users to add Items to                    | ...   | ...    |
| 10. Add CSS and Styling                                         | ...   | ...    |

## Setup/Installation Requirements

### Project from GitHub

- Download option

  - Download files from GitHub repository by click Code and Download Zip
  - Extract files into a single directory
  - Run GitBASH in directory
  - Type "dotnet restore" to get bin and obj files
  - Type "dotnet run" in GitBash to run the program
  - Add database per the instructions below.
  - Have fun with Online Bakery <!-- TITLE HERE -->

- Cloning options
  - For cloning please use the following GitHub [tutorial](https://docs.github.com/en/enterprise/2.16/user/github/creating-cloning-and-archiving-repositories/cloning-a-repository)
  - Place files into a single directory
  - Run GitBASH in directory
  - Type "dotnet restore" to get bin and obj files
  - Type "dotnet run" in GitBash to run the program
  - Add database per the instructions below.
  - Have fun with Online Bakery <!-- TITLE HERE -->

### Database Setup

- Go to appsettings.json and change the password if needed.

- Setup with SQL migrations

  - In the terminal, navigate to the project folder
  - Type "dotnet ef migrations add Initial" and wait for migration file to be built
  - Type "dotnet ef database update" and wait for build confirmation

- Setup with SQL Import
  - MySQL
    - In the Navigator > Administration window, select Data Import/Restore.
    - In Import Options select Import from Self-Contained File.
    - Navigate to mike_manchee.sql.
    - Under Default Schema to be Imported To, select the New button.
      - Enter 'mike_manchee' as the name of your database.
      - Click Ok.
    - Click Start Import.

## Technologies Used

Project Specifics

- Many to Many Database relationships
- Authentication with Identity

Main Programs

- MySQL
- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet)
  - [Entity](https://docs.microsoft.com/en-us/ef/core/)
  - [Razor](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/razor?view=aspnetcore-3.1)
  - [MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-3.1)
- CSS
  - [Bootstrap](https://getbootstrap.com/docs/4.5/getting-started/introduction/)
  - [Font Awesome](https://www.w3schools.com/icons/fontawesome_icons_intro.asp)

### Other Links

[Natalie's GitHub](https://github.com/muprhynd)
[LinkedIn](https://www.linkedin.com/in/nataliedoraismurphy)

### License

Copyright (c) 2020 **_{Natalie Murphy}_**
Licensed under MIT
