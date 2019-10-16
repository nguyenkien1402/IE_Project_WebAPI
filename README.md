A mental health API web service for the mobile application name Liberzy in IE's project

# IE_Project_WebAPI

This a a web service API that I developed in 12 weeks program of IE, the mobile application can be found [here](https://github.com/nguyenkien1402/IE_Project_AndroidApp) 

The whole project is intened to develop a mobile application under the theme mental health.
We work as a group of 4 and we've done almost everything from business analyst, target customer, customer insight to develop application with the help of Agile and Scrum. 

As a core developer in the group, I responded for developing an Android mobile application, the RESTful API Webservice by using ASP.NET Core and an API for movie recommendation, the repository about how i made movie recommendation service from getting data, making a recommendation algorithm to deploy to Google App Engine can be found [here](link)

------

In this repository contain the main project named "XBrain" and the SQL Script for SQL Server Database.
Following is instruction of how to deploy project to Microsoft Azure Platform. 
As i used ASP.NET Core to develop RESTful API, you can deploy the service to any cloud platform or your Linux VM.

### Instruction.
1. Clone the repository
2. Register to the Microsoft Azure Cloud Platform.
3. Create SQL Server Database in the Cloud and note down all of this information:
    -	Database Name 
    -	Server Name 
    -	Server admin login
    -	Password
4. Open SQL Server Management Studio and connect to the SQL Server you've created above 
5. Open the SQL script in the repository folder and run the script to init the schema
6. Import project to Visual Studio, open the file named "appsettings.json " and replace all the parameter bellow with your parameters.
    -   your-db-server = your database server name. E.g: liberzy.database.windows.net
    -   your-database  = your database name. E.g: LiberzyDatabase
    -   your-identity =  your admin login. E.g: liberzyadmin
    -   your-password =  your admin password. E.g: liberzypassword
7. Choose the project and choose published
8. Use your Azure account you've registered above and follow the instruction to publish the web service.
 

