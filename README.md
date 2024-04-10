# Refactoring test in C#

## The implementation
Thats was not implemented a full Clean Code Architecture due some limitations in the LegacyApp.Consumer project.
However, the database is lousely coupled and the consumer doesn't know nothing about it, it is just used to inject the dependency in the Application.
I did not keep the CQRS Pattern because the use of MediatR would be necessary.
We have all dependencies coming from in to out

domain does not have any dependencies 
application only depends of domain.
