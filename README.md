Documentation

This document provides a brief guide on how to set up and run the FileUpload solution.

Before getting started, ensure that you have the following software installed on your machine:

- [.NET SDK](https://dotnet.microsoft.com/download) (compatible version)
- [Node.js](https://nodejs.org/en/download/)
- [Visual Studio](https://visualstudio.microsoft.com/downloads/) or [Visual Studio Code](https://code.visualstudio.com/download/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)



1. **Clone the Repository:**

2. **Navigate to the Project Directory:**
   - Open your terminal or command prompt and run:

     ```bash
     cd path/to/FileUpload
     ```

3. **Set Up the Database:**
   - Open `appsettings.json` in the `FileUpload.Context` and 'Program.cs' in FileUpload.Api project and configure the connection string.
   - Run the following commands in the Package Manager Console or Terminal:

     ```bash
     cd FileUpload
     dotnet ef database update
     ```

4. **Build and Run the Backend:**
   - Open the solution file in Visual Studio or Visual Studio Code.
   - Set the startup project to `FileUpload.Api` and run the application.

5. **Run the Frontend:**
   - Navigate to the `FileUpload.Api.ClientApp` directory.
   - Run the following commands:

     ```
     npm install --force
     ng serve
     ```

6. **Access the Application:**
   - Open your web browser and go to [http://localhost:your-port-number](http://localhost:your-port-number).
