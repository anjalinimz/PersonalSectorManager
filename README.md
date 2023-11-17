# PersonalSectorManager

This application is designed to oversee and manage user sector information.

## Table of Contents

- [Overview](#overview)
- [Tasks Completed](#task-completed)
- [Repository Contents](#reposotory-contents)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
  - [Clone the github project](#clone-the-github-project)
  - [Restore the SQL server](#restore-the-sql-server)
  - [Update databse connection string and run the project](#update-database-connection-string-and-run-the-project)
- [How to use this application](#how-to-use-this-application)
- [Assumptions](#assumptions)
- [Conclusion](#conclusion)

## Overview

This repository contains the solution for the test task provided by Helmes. The task involved correcting deficiencies in the index.html file, implementing functionality to manage and display "Sectors" from a database, validating and storing user input data, and enabling users to edit their data during the session.


## Tasks Completed

- **Corrected deficiencies in provided 'index.html'**: The HTML file has been thoroughly reviewed and corrected to address any identified deficiencies, ensuring proper functionality and adherence to best practices.
- **'Sectors' Selectbox**: Added entries to the database and composed the 'Sectors' selectbox using database data.
- **Actions after 'Save' Button Pressed**: Validated input data. Stored input data in the database. Refilled the form with stored data. Enabled user data editing during the session.

## Repository Contents

- **Database Dump: DatabaseBackups/DatabaseBackup.bak**: This repository includes a full database dump containing both structure and data. Please refer to the provided dump file for complete details.
- **Source Code**: The source code for the solution is available in this repository. Please explore the codebase to understand the implementation details.

## Prerequisites

- Download [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download) or the latest version.
- Download a compatible IDE (Visual Studio or Visual Studio Code) from [here](https://visualstudio.microsoft.com/).
- Download SQL Server along with SQL Server Management Studio or Azure Data Studio, which can be used to effectively view tables and other database components.


## Getting Started

### Clone the GitHub Project

Navigate to your desired folder and run the following commands using a terminal.

```
git clone https://github.com/anjalinimz/PersonalSectorManager.git
git clone https://github.com/anjalinimz/PersonalSectorManager.Tests.git
```

If you've cloned both the main project and the test project repositories into the same folder, Visual Studio should automatically recognize them as part of the same solution. In this case, you can open the solution file directly.

### `Restore the SQL server database`

**Step 1:** Launch SQL Server Management Studio (SSMS) and connect to the appropriate SQL Server instance.

**Step 2:** Locate the "Object Explorer" window in SSMS. Then, right-click on the "Databases" node and choose "Restore Database..."

**Step 3:**
- Select "Device" as the source.
- Click the ellipsis (...) to browse for the backup file.
- Choose the `DatabaseBackup.bak` file and click "OK" to initiate the restore process.

### `Update database connection string and run the project`

Update the database connection string in the `appsettings.json` file using your SQL server Uid and Pwd. Then, build and run the project.


## How to use this application

**Step 1:** Before you start, it's recommended to use Google Chrome for the best experience. Some features in the application are optimized and better supported in Google Chrome.

**Step 2:**
- Add your name in the designated field.
- Choose the relevant sectors (use 'Ctrl + left-click' to select multiple options) from the provided dropdown.
- Indicate your agreement to the terms by checking the checkbox.

**Step 3:** Click the 'Save' button to submit your inputs.

**Step 4:**
- If validations are successful, the application will save user input to the database and navigate to the confirmation page.

**Step 5:** The user can modify or cancel the operation by utilizing the 'Edit' or 'Cancel' button provided.


## Assumptions

1. Users can select multiple sectors from the 'Sectors' dropdown. However, if child options are available for a parent sector, users can only select from the child options. This restriction is in place to avoid a situation where a user selects both the parent and the child simultaneously, as it would not be meaningful.

2. The parent sectors in the dropdown menu should be arranged in alphabetical ascending order. Additionally, the child sectors within each parent should also be organized alphabetically in ascending order.

3. 'Name' is a required field. Before submitting their inputs, users must select at least one option from the 'Sectors' dropdown, and they are required to check the 'Agreed to Terms' checkbox.


## Conclusion

This application represents the successful completion of the Helmes test task, encompassing a range of tasks from correcting deficiencies in the `index.html` file to implementing robust functionality for data management and user interactions.

I invite you to explore the provided source code. Your feedback is valuable, and I appreciate your time spent reviewing this project. If you have any questions or require further clarification, please feel free to reach out:

- Email: [anjalinimz@gmail.com](mailto:anjalinimz@gmail.com)
- GitHub URL: [https://github.com/anjalinimz/PersonalSectorManager](https://github.com/anjalinimz/PersonalSectorManager)
