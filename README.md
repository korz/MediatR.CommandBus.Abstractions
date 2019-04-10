# MediatR.CommandBus.Abstractions

## Purpose
  The sole intention of this library, is to provide more explict abstractions around common Command Bus objects, such as **ICommand**, **IQuery**, and **IEvent** to MediatR in an unobtrusive way.

## Installation
  This project is exposed as a NuGet package for your convenience. If you would like more information on installing the NuGet package, please refer to the installation section of the [Wiki](https://github.com/korz/MediatR.CommandBus.Abstractions/wiki/Installation). 
  
## Target Frameworks
  You can use this in your **.Net Framework**, **.Net Standard**, and **.Net Core** apps that are, or are planning, to use MediatR.
  
## Example Usage
  These interfaces and implementations are just wrappers around the base **IRequest** and **IRequestHandler** interfaces that MediatR provides. 
  
  Notice, in the Command example below, where we simple inherit from **ICommand** and **ICommandHandler** instead of **IRequest** and **IRequestHandler** respectively.
  
### Command
```csharp
public class SetCustomerInactiveCommand : ICommand<Customer>
{
    public Customer Customer { get; set; }
}
```

### Command Handler
```csharp
public class SetCustomerInactiveCommandHandler : ICommandHandler<SetCustomerInactiveCommand, Customer>
{
    private readonly ICustomerCommandRepository repository;

    public Handler(ICustomerCommandRepository repository)
    {
        this.repository = repository;
    }

    public async Task<Customer> Handle(SetCustomerInactiveCommand command, CancellationToken cancellationToken)
    {
        command.Customer.IsActive = false;

        return await this.repository.UpdateAsync(command.Customer.Id, command.Customer, cancellationToken);
    }
}
```

### Command Invocation
```csharp
var command = new new SetCustomerInactiveCommand { Customer = someCustomer };

await Mediator.Send(command);
```

## Want More?
For more examples, and to try this out for yourself, clone or download the repository and look at the solution in the [tests](https://github.com/korz/MediatR.CommandBus.Abstractions/tree/master/tests) folder.

For more information, please check out the [Wiki](https://github.com/korz/MediatR.CommandBus.Abstractions/wiki).