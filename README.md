# _Eau Clair's Salon_

#### _C# web application using mySQL and Entity Framework Core for Epicodus_, _20 March 2020_

#### By _**Patrick Kille**_

## Description

_This web application will keep track of stylists and their clients using a local database for Eau Clair's Salon_

## Specifications:

| Specification | Example Input | Example Output |
|:-:|:-:|:-:|
| Have Welcome Page | localhost:5000/ | Welcome To Your Stylist Organizer |
| Have a page to add a stylist | Add stylist | database updated with stylist |
| Have a page to view stylists | View Stylists | All stylists listed as links to their details |
| Have detail page for each stylist | Jane's info | Lists clients as links to their info and links to add a client and edit or delete the stylist |
| Have client detail pages | Suzie's info | List details plus links to edit and delete client forms |



## Setup/Installation Requirements

### Prerequisites

1. .NET Framework
* Download the .NET Core SDK [Software Development Kit](https://dotnet.microsoft.com/download)
* Open the .Net Core SDK file and install
* To confirm installation was successful, run the ```$ dotnet --version``` command in your terminal

* Install dotnet script, run the ```$ dotnet tool install -g dotnet-script``` command in your terminal
* Restart your terminal to complete installation

2. mySQL
* Follow the instructions provided [here](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql) to install mySQL. You can ignore the instructions for mySQL workbench.

3. Text Editor: [Visual Studio Code](https://code.visualstudio.com/) preferred.

### To Download the Project Files

1. Cloning
  * _First, clone this repository to your desktop by opening your terminal and entering the prompt "cd desktop" followed by pressing the enter(return) key. Then type "git clone https://github.com/PRKille/EauClairsSalon.git" and press enter(return) again._

2. Download
  * _In a web browswer navigate [here](https://github.com/PRKille/EauClairsSalon.git) to find the GitHub repository._
  * _Click the green "Clone or download" button and selct "Download ZIP"_.

### Running the Progam

1. Navigate to the HairSalon directory inside the main folder using your terminal.

2. Restore the dependencies with the "dotnet restore" command.

3. Type the following commands in the my SQL command line:
  * CREATE DATABASE `patrick_kille`;
  * USE `patrick_kille`;
  * CREATE TABLE `clients` (
  `clientId` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `stylistId` int DEFAULT '0',
  PRIMARY KEY (`clientId`));
  * CREATE TABLE `stylists` (
  `stylistId` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`stylistId`));

4. Build and run the code with your standard terminal using these commands:
  * dotnet build
  * dotnet run

5. Navigate to "localhost:5000/" in your web browser to view the application.

## Technologies Used

* C#
* ASP.NET core MVC 2.2
* Entity Framework Core 2.2.0
* MySQL + MySQL Workbench version 8.0.15
* Git

### License

*This webpage is licensed under the MIT license.*

Copyright (c) 2020 **Patrick Kille**