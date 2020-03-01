# Introduction

This will introduce identity into the project and how basic can be upgraded to utilise basic Identity, a more sophisticated authentication mechanisms. Look at history to see changes

## Steps to reproduce

1. Create empty identity ASP.net core project
2. Install **Entity Framework Core** into the project
3. Install **Microsoft.EntityFrameworkCore.InMemory** into the project for testing and developing faster
4. In *startup*, register In memory database with AppDbContext
5. **AddIdentity** with *IdentityUser* and *IdentityRole* to register built in providers and repositories and add default token provider
6. Add identity package **Microsoft.AspNetCore.Identity.EntityFrameworkCore** associated with entity framework
7. Refactor ***AppDbContext*** with ***IdentityDbContext*** to utilise built Identity mechanisms
8. Create **HomeController** similar to basic project, except there should be a login and register method for Authorising the user
9. Create **login** and **register** *views* with form inputs
10. **Inject** the ***UserManager*** and ***SignManager*** into the home controller and setup dependency which is wired through singleton dependency injection when setting up the service
11. Play with app to see flows working and configure more options in sign up to understand simple identity logic
