# PersonalSectorManager

This application is to validate zip files uploaded by the user. 

## Table of Contents

- [Overview](#overview)
- [Tasks Completed](#task-completed)
- [Repository Contents](#reposotory-contents)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
  - [Clone the github project](#clone-the github-project)
  - [Restore the SQL server](#restore-the-sql-server)
  - [Update databse connection string and run the project](#update-database-connection-string-and-run-the-project)
- [How to use this application](#how-to-use-this-application)
- [Assumptions](#assumptions)
- [Conclusion](#conclusion)

## Overview

This repository contains the solution for the test task provided by Helmes. The task involved correcting deficiencies in the index.html file, implementing functionality to manage and display "Sectors" from a database, validating and storing user input data, and enabling users to edit their data during the session.


## Tasks Completed

`Corrected deficiencies in provided 'index.html'` <br> The HTML file has been thoroughly reviewed and corrected to address any identified deficiencies, ensuring proper functionality and adherence to best practices.

`'Sectors' Selectbox` <br> Added entries to the database and composed the 'Sectors' selectbox using database data.

`Actions after 'Save' Button Pressed` <br> Validated input data. <br> Stored input data to the database. <br> Refilled the form with stored data. <br> Enabled user data editing during the session. 


## Repository Contents

`Database Dump: DatabaseBackups/DatabaseBackup.bak` <br> This repository includes a full database dump containing both structure and data. Please refer to the provided dump file for complete details.

`Source Code` <br> The source code for the solution is available in this repository. Please explore the codebase to understand the implementation details.


## Prerequisites

* Download .NET 6 SDK or latest<br>
https://dotnet.microsoft.com/en-us/download
* Download a competoble IDE (Visual Studio or Visual Studio Code) <br>
https://visualstudio.microsoft.com/ <br>
* You can download SQL Server along with SQL Server Management Studio, which can be used to effectively view tables and other database components.


## Getting Started

### `Clone the github project`

Navigate to your desired folder and run the following command using a terminal.

```
git clone https://github.com/anjalinimz/PersonalSectorManager.git
```

### `Restore the SQL server database`

`Step 1` <br> Launch SQL Server Management Studio (SSMS) and connect to the appropriate SQL Server instance.

`Step 3` <br> Locate the "Object Explorer" window in SSMS.Then, right-click on the "Databases" node and choose "Restore Database..."

`Step 3` <br>
Select "Device" as the source <br>
Click the ellipsis (...) to browse for the backup file <br>
Choose the DatabaseBackup.bak file and click "OK" to initiate the restore process

### `Update databse connection string and run the project`

Update the databse connection string in the appsettings.json file using your SQL server Uid and the Pwd. Then, build and run the project.


## How to use this application

`Step 1` <br> Before you start, I recommend using Google Chrome as the preferred browser for the best experience. Some features in the application are optimized and better supported in Google Chrome.

`Step 2` <br> Add your name in the designated field, choose the relevant sectors ('Ctrl + left' click to select multiple options) from the provided options in the dropdown and indicate your agreement to the terms by checking the checkbox.

`Step 3` <br> Click 'Save' button to submit your inputs. 

`Step 4` <br> If validations are successful, the application will save user input to the database and navigate to the confirmation page.

`Step 5` <br> The user can modify or cancel the operation by utilizing the 'Edit' or 'Cancel' button provided.


## Assumptions

1. I have assumed that users can select multiple sectors from the 'Sectors' dropdown. However, if child options are available for a parent sector, users can only select from the child options. This restriction is in place to avoid a situation where a user selects both the parent and the child simultaneously, as it would not be meaningful.

2. I have assumed that the parent sectors in the dropdown menu should be arranged in alphabetical ascending order. Additionally, the child sectors within each parent should also be organized alphabetically in ascending order.

3. I have assumed that 'Name' is a required field. Additionally, before submitting their inputs, users must select at least one option from the 'Sectors' dropdown, and they are required to check the 'Agreed to Terms' checkbox.


## Conclusion

This application represents the successful completion of the Helmes test task, encompassing a range of tasks from correcting deficiencies in the index.html file to implementing robust functionality for data management and user interactions.
<br>
I invite you to explore the provided source code. Your feedback is valuable, and I appreciate your time spent reviewing this project.
<br>
If you have any questions or require further clarification, please feel free to reach out:
<br>
anjalinimz@gmail.com

github URL: <br>
https://github.com/anjalinimz/PersonalSectorManager
