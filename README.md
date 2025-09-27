
# TaskManagementSystem  

# TaskManagement.Application  

## Overview  

This project implements the application layer for a Task Management System using CQRS and MediatR. It provides query and command handlers, DTOs, and interfaces for managing tasks, users, and related entities.  

## Features  

- Retrieve all tasks with optional filtering by status and assignee.  
- Standardized response objects for API consistency.  
- Extensible repository pattern for data access.  
- Implements CQRS pattern with MediatR for separation of concerns.  
- Uses C# 13.0 and targets .NET 9.  

## Structure  

- **CQRS/Query**: Contains query handlers (e.g., `GetAllTaskQueryHandler`) for reading data.  
- **CQRS/Command**: Contains command handlers (e.g., `CreateTaskCommandHandler`) for writing data.  
- **Dtos**: Data Transfer Objects for API responses.  
- **Domain/IRepository**: Repository interfaces for data access abstraction.  

## Usage  

### Example: Retrieve All Tasks  

1. Inject `IMediator` into your service or controller.  
2. Use the `GetAllTasksQuery` to retrieve tasks.
### Response Format  

The response will be a standardized DTO:
## Extensibility  

- Add new query/command handlers for additional features.  
- Extend DTOs for more detailed responses.  
- Implement repository interfaces for different data sources.  

## Requirements  

- .NET 9 SDK  
- C# 13.0  
- MediatR NuGet package  

## Getting Started  

1. Clone the repository.  
2. Restore NuGet packages.  
3. Build the solution.  
4. Run the application and use the provided handlers via MediatR.  

## License  

No License.
