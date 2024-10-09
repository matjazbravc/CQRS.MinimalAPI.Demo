![](res/Title.jpg)

# CQRS Pattern (with Minimal API)
The Command and Query Responsibility Segregation (CQRS) it’s an architectural pattern where the main focus is to separate the way of reading and writing data. This pattern uses two separate models:

**Queries** - are used to read data from the database. Queries objects only return data and do not make any changes. Queries will only contain the methods for getting data. They are used to read the data in the database to return the DTOs to the client, which will be displayed in the user interface.

**Commands** - represent the intention of changing the state of an entity. They execute operations like Insert, Update, Delete. Commands objects alter state and do not return data. Commands represent a business operation and are always in the imperative tense, because they are always telling the application server to do something.

# Benefits of CQRS
Building your architecture using CQRS principles offers many advantages:

* **Separation of concerns**  
When the read and write sides are separate, the models become more maintainable and flexible. The read model is typically simpler, while the write model involves more complex business logic.

* **Independent scaling**  
With CQRS, read and write workloads can scale independently, resulting in fewer lock contentions.

* **Optimized data schemas**  
On the read side, a schema can be optimized for queries, and on the write side, a schema can be optimized for updates.

* **Security**  
It’s easier to ensure that only the right domain entities are performing writes on the data.

* **Simpler queries**  
Application queries can avoid complex joins by storing a materialized view in the read database.

# Implementation
This simple demo is based on the use of **Minimal API** pattern, using the **MediatR** library, **SQLite** database and **EFCore7** as an ORM framework.
**Minimal API** is the simple way to build small microservices and HTTP APIs in ASP.NET Core. It hooks into ASP.NET Core's hosting and routing capabilities and allow you to build fully functioning APIs with just a few lines of code.  
 
**Note: this does not replace building APIs with MVC, if you are building complex APIs or prefer MVC, you can keep using it as you always have.**

# Summary
At the end, we split the responsibility into **Command** and **Query**, and we use an **ORM** (Entity Framework Core) for the **Command** side. To improve the benefits, we can synchronize the data into a **NoSQL** database to be consumed from the read side and implement **Event Sourcing**.
**Event Sourcing** ensures that all changes to application state are stored as a sequence of events. Not just can we query these events, we can also use the event log to reconstruct past states, and as a foundation to automatically adjust the state to cope with retroactive changes. But this is another story.

Enjoy!

- [Visual Studio](https://www.visualstudio.com/vs/community) 2022 17.2.6 or greater
- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)

## Tags & Technologies
- [.NET 8](https://github.com/dotnet/core/blob/main/release-notes/8.0)
- [SQLite](https://sqlite.org/index.html)
- [MediatR](https://github.com/jbogard/MediatR)
- [Entity Framework Core 8.x](https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-8.0/whatsnew)

## Licence
Licenced under [MIT](http://opensource.org/licenses/mit-license.php).
Contact me on [LinkedIn](https://si.linkedin.com/in/matjazbravc).
