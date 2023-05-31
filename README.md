# Vacation Hire Inc.
I will describe the application I created, bellow.
This application consists of a backend, built on .Net Core 7, and a front-end built with Angular 16.0

## The architecture
### The back-end
For the backend I've created a solution, using .Net Core 7, based on the onion architecture. I've used Entity Framework Core 7 for accessing the data from a an MSSQL database, that is hosted in Azure. I've used FluentValidation, for validating models, Automapper for mapping between models, and xUnit with FluentAssertions for writing unit tests.

The solution is based on the onion architecture, and it consists of the following layers:

- **The presentaion layer**: VacationHireInc.API
    - this a web api, its responsability is to handle API requests
    - I'm a big fan of global error handling, I've created a middleware (_CustomExceptionHandlerMiddleware_) that handles all the error handling, and returns the correct responses in case there is an error. This way, I don't have to put a lot of try-catch blocks all over the code, and error handling logic is not repeated all over the place
    - it is loosely coupled to the service layer, the layer bellow
- **The service layer**: VacationHireInc.Service
    - this layer is responsible for doing all the business logic, such as: data valition, and model mapping
    - it is loosely coupled to the data-access-layer, and delegates all data crud operation to this layer
    - there is a solution called _VacationHireInc.Service.Tests_, that cointain unit tests for this layer, although I don't have a good code coverage, I've only created one test for demonstration purposes
    - I've segregated all of the actions in sepparate classes, for example, for creating an order there is a class called _CreateOrderStrategy_, I like breaking up the service layer to this atomic level, because in this case these classes can have fewer dependencies, thus unit tests can be written faster, with less amount of code, then in the case where I would have all the actions of a single domain in one class.
- **The data access layer**: VacationHireInc.DataAccess
    - This is where all the database related logic happen, it contains entity framework related configurations, and migrations
    - I've created repositories for all CRUD operations for the domain models. These repositories are children of generic repositories. I know that this is an overkill, expecially because EF's dbcontext is also a repository, and it would've been easier to create a simple store for each entity, but I was just flexing my capabilities a bit 😎
- **The domain layer:** VacationHireInc.Domain
    - This is the core layer, the core of the onion.
    - It doesn't have any dependencies
    - It only contains models, like data-transfer-object models, and entity models that represent tha data from the datebase (although these two could be broken up into their own projects, depending on the size of the application)
    - Each action has their on DTO, like the model for creating an order is different from that of retrieving it

### The front-end
For the front-end, I've created an Angular 16 app, using the Angular CLI to initialize, develop and scaffold the application. I've used Angular Material as a UI library.

To run the app on your local machine, I expect that you already have the Angular CLI installed, naviagate to the root folder of the app and run the following commands to install all the dependencies, then to run the app: 
```sh
npm install
ng serve
```

## Design decisions on the problem at hand

### The integration of the currencylayer API
For integrating the [currencylayer API](http://currencylayer.com), I have abstracted/proxied all the calls to the API via the back-end. This has two benefits:
- The front-end app doesn't need to have knowledge about a third-party API
- The API key, used for this outside API is not exposed through the front-end, thus its more secure

### The representation of the rentable products
Since the Vacation Hire Inc. is currently only offering vechicle renting, but plans to extend their offerings with other types of products, the open/closed principle has to be enforced on the order model. This is done by a simple strategy pattern, the order model doesn't have information about the product itself, it only refrences it. On the database level, the products have their own tables, where their name is stored (like "Sedan" or "Truck"), but also their type (for now the only possible value is "vechicle"). This type comes helpful later, when we decide to return the product, as a different form has to be shown for each type product (We don't care about fuel percentage, when checking out from a hotel room).

### The representation of the product returnal (in our case the vechicle returnal)
Since in the future, we could have multiple types of products in the lineup, modeling the product returnal process has to be flexible. I will start explaining the decisions made from the database level up to the frontend level.

There are common informations for all product returnals, like payment informations, and each product type will have its own informations to store, like the fuel percentage and damage notes for vechicles. I've achieved this by using the Table-per-Hierarchy inheritance strategy
```
public class VechicleReturnalInfo : ProductReturnalInfo
```
The _ProductReturnalInfo_ contains the base informations shared by all the possible types, with the relation to the order. The _VechicleReturnalInfo_ contains vechicle returnal data specificaly and it extends the base class. In the database there will one table to store every returnal, with a discriminator column which distinguishes between inheritance classes.

On the API level, I had to make a decision between two solutions
The first would be to represent the all the returnals in one action, and use a custom model binder to distinguish the possible types with some sort of discriminator field. Or, to have sepparate endpoints, for each type of returnal, each dealing with a specific set of resources. 
I've chosen the later, as it is more correct from the perspective of a restful API, having different endpoints for different resources, like vechicles vs hotel rooms. But this is debatable, both solutions have their ups and downs
In case we want to extend to new product types, we need to create a new controller. The service that handles the business logic could be the same, with replacing the validation and the mappings for type-specific ones.

On the front-end level, we already know that different types of returnals point to different endpoints. For each of the product returnal types, I've created a sepparate service, each of these services extend the same interface. When accesing the product returnal page, I've used the factory method pattern to create the specific product returnal service. I have a service specificaly to represent this facory. Instead of getting the concrete service from dependency injection, the factory will create me a type-specific instance.
```
public createProductReturnalService(productType: string) {
    switch (productType) {
      case 'vechicle':
        return new VechicleReturnalInfoService(this.http, this.formBuilder);
      
      // Whenever there are new product types, that Vacation Hire Inc. wants to extend, will add here.
      
      default:
        throw Error('Not implemented');
    }
  }
```
I intentionaly not used the _useFactory_ factory provider of angluar, as for knowing the product type, I first need to query the order, of what I want to return, and this is an async operation.

All of the product returnal services have to be able to do three things: retrieve an existing returnal, create a new one, and provide an angular form-group to represent the returnal form.
```
export interface IProductReturnalInfoService {
  get(id: string): Observable<ProductReturnalInfo>;
  create(returnalInfo: ProductReturnalInfo): Observable<ProductReturnalInfo>;
  buildProductReturnalForm(): FormGroup;
}
```
