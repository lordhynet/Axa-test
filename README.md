# Excel Processor

This project consists of an Angular front-end application and a .NET 6 backend API. The system allows users to upload Excel files (.xlsx format only), processes the data on the backend, and returns computed metrics to the front-end application.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Node.js](https://nodejs.org/en/) (which includes npm for managing Angular CLI installations)
- [Angular CLI](https://angular.io/cli) (`npm install -g @angular/cli`)
- A code editor like [Visual Studio Code](https://code.visualstudio.com/)

### Setting Up the Backend

1. Navigate to the backend project directory:

```bash
cd path/to/your/dotnet/project
Build the .NET project to restore any NuGet packages:
bash
Copy code
dotnet build
Run the .NET project:
bash
Copy code
dotnet run
By default, the API will be available at https://localhost:44350/api.

Setting Up the Frontend
Navigate to the front-end Angular project directory:
bash
Copy code
cd path/to/your/angular/project
Install npm packages:
bash
Copy code
npm install
Serve the Angular application:
bash
Copy code
ng serve
By default, the Angular application will be available at http://localhost:4200.

Connecting Angular to the Backend API
In your Angular project, you've already set the base URL for the backend API in your UploadService. To make requests to your backend, ensure this URL matches your .NET backend's URL:

typescript
Copy code
const baseUrl = 'https://localhost:44350/api';
This URL is used in your Angular services to make HTTP requests to the backend.