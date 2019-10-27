>## Books Api
> Techologies Used
1) Dotnet core Version 3.0
2) Visual Studio Code.
3) Dotnet core cli
4) Localdb Mssql database server

>### Key packages Used

**nb.** You could decide to install **Microsoft.AspNetCore.All -Version 2.2.7** which installs all the dependencies you might need. Its Called a  **Metapackage**. Its a package of packages.

But since am learning i add the dependencies that i currently need.

```xml
// From my .csproj file I have the following
 <PackageReference Include="Microsoft.EntityFrameworkCore" Version="2.2.6" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="2.2.6" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="2.2.6">
```
>## Classes and Entities 
Since am using **Code first approach** .I will be using Entity Framework key as my *Object-relational mapping(ORM)* This classes and Entities are the one match to => Database tables.

> ## General overview of the classes
>### classes and some relationships
![img](/images/classes.png)


> ## Type of relatioships Availabe
1. **One to many Relatioship**

This is the most common relatioship
- A Reviewer can only give one review to a book.
   - A book could have many Reviwer
- An Author can only be associated with one country.
   - A country could have many authors.
- A Review can only be from one Reviwer. 
   - A Reviwer could have many reviews (diff books).
This easy to represent in the entity classes.</br>

if i take **Reviewer** and and **review**.
- I create an object reference of Reviwer in Review class.
- I create a virtual collection of Reviews in the Reviewer class.

<table border=0>
<tr>
 <td><b style="font-size:18px">Reviewer</b></td>
  <td><b style="font-size:18px">Review</b></td>
</tr>
<tr>
  <td>

   ```Csharp
  public class Reviewer {
       ...
  public virtual ICollection<Review> Reviews { get; set; }
     }
   ```    
  </td>
  <td>

  ```Csharp
       public class Review {
         ...
         public virtual Reviewer Reviewer { get; set; }
       }
   ```
    
  </td>
</tr>
</table>
2. **Many to many Relatioship**
Also very common 
-  **Book and Author** 
    - A book can be from many Authors whileus many an Author can have many books.
-  **Book and Category**
    - A book can belong to many categories whileus A Category can posses many books.

for many to many relatioship: The approach is a bit different. We need finaly to have a **join table** in the database. 

For instance lets take **Author** and **Book**. We will create an **BookAuthor** class with AuthorId and BookId properties. We will add the object of each class entity in this **BookAuthor** class which we will use later to define the **many to many** relatioship using a ModelBuilder in the DbContextClass.
> ### The BookAuthor Class.

> ### Diagramatic Representation of Properties and Relatioships

![img](/images/relatioships.png)

## DataBase Migrations and Seeding Data
Database use in sql database. Used for developement

## Dtos (Data Transfer Objects)
- Simplified object with limited properties used for transfer only the needed data (for example, we do not want to always transfer full objects will all referenced classes). 

