# Property Management REST API

## Overview

This project involves the development of a robust REST API for property management using ASP.NET Core. The API serves as a central platform for managing information related to houses, apartments, and residents. It leverages modern technologies, including Entity Framework Core and AutoMapper, to provide efficient and scalable data processing.

## Features

### 1. House Management

- **Create**: Users can create a new house by specifying details such as house number, street, city, country, and postal code.
- **Read**: The API allows users to retrieve information about existing houses.
- **Update**: House details can be edited, enabling users to keep property information up to date.
- **Delete**: Houses that are no longer relevant can be deleted from the system.

### 2. Apartment Management

- **Create**: Users have the ability to create apartments, specifying attributes like apartment number, floor, room count, total area, and living area.
- **Read**: Information about apartments can be retrieved from the API.
- **Update**: Users can edit apartment details, ensuring that data is accurate and current.
- **Delete**: Apartments that are no longer needed can be removed from the database.

### 3. Resident Management

- **Create**: Residents can be added to apartments with details such as first name, last name, personal ID, date of birth, phone number, and email.
- **Read**: Information about residents is accessible through the API.
- **Update**: Resident details can be modified as needed.
- **Delete**: Residents can be removed from apartments when necessary.

### 4. Database Integration

- The API is integrated with an SQL database, ensuring data persistence and reliability.
- Default data is seeded into the database, including two houses, five apartments, and four residents. This data serves as a starting point for property management.

### 5. Data Relationships

- The project implements complex data relationships:
  - One resident can be associated with multiple apartments.
  - One apartment can house multiple residents.
  - Each apartment belongs to only one house.

### 6. Additional Features

- A boolean field "IsOwner" is introduced for residents, allowing identification of property owners.
- AutoMapper is used to simplify the mapping of DTO models.

## Technologies

- ASP.NET Core
- Entity Framework Core
- AutoMapper
- SQLServer Database

## Future Enhancements

This project lays the foundation for an extensive property management system. Future enhancements could include:

- User authentication and authorization for role-based access control.
- Advanced search and filtering capabilities.
- Integration with a front-end application for a complete property management solution.

## Conclusion

The Property Management REST API is a powerful tool for managing property-related data efficiently and accurately. Its modular architecture and robust features make it a valuable asset for property management applications.


1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/property-management-api.git
