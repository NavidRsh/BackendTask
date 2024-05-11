# BackendTask

The following concepts and techniques have been used for creating this project : 
* Domain-Drive Design
* Clean Architecture
* CQRS Pattern
* Strategy Pattern
* Repository Pattern
* EfCore
* Unit Testing  

**How did you verify that everything works correctly?**

To verify that everything works correctly, I utilized a combination of unit testing and manual testing. Unit testing was used to cover a considerable coverage of the domain code, while manual testing and manual regression testing were being used to ensure the functionality works as intended

**How long did it take you to complete the task?**

About 10 hours.

**What else could be done to your solution to make it ready for production?**

To answer this question we need to have a rough estimation about the usage of the software, the importance of its functionality and other environmental factors.

But generally we could consider the following items as necessary for moving this code to production : 

1- Security enhancements like implementing authentication and authorization for accessing the API or considering any possible exploitations of the API and implementing necessary measures to prevent them    

2- Error handling and logging 

3- Having more unit testing coverage and implementing integration testing or acceptance testing if necessary 

4- Performance enhancement : we may use some caching mechanism to enhance the performance, if the API is supposed to be called frequently 

5- Adjusting the code and the architecture to the standards and policies of the organization 

6- Some minor enhancements like using Poly for sending Http requests to handle temporary communication problems 

7- Getting the code reviewed by the other developers of the organization 


