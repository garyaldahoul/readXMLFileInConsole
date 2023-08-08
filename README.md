# Display Data on FE-React & .NET Server REST API

I used .NET 7 server,  SQL databases and React frontend for this solution where it read the data from XML file and write the data to DB on the frontend we call the backend using REST API  to fetch the data.

### Running the code 
To run it locally clone the project and checkout to xml-Api-DB and open the project in Visual Studio and upload these packages[ `Microsoft.EntityFrameworkCore`, `Microsoft.EntityFrameworkCore.Tools`, `Microsoft.EntityFrameworkCore.SqlServer` , `Swashbuckle.AspNetCore.SwaggerGen` , `Microsoft.AspNetCore.OpenApi` ].
you should to connect with SQL database (Docker Desktop - Azure platform for mac )
then click to run the program in .NET visual studio
On the frontend start react app in visual studio code npm start
After the program run you will see three routes Home / Trans Units / SearchID
In Trans Units route  you find all the target the exit in the xml file
In SearchID route you enter the ID you want and get the target depend on the ID you enter.
