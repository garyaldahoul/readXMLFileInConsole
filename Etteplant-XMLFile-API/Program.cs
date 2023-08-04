using System.Xml;
using Etteplant_XMLFile_API.Controllers;
using Etteplant_XMLFile_API.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(connectionString));


static void InsertDataFromXMLFileToDB(string connectionString)
{
    SqlConnection connection = new SqlConnection(connectionString);
    XmlDocument doc = new XmlDocument();
    // I used route import pass because I using mac os machin for development
    doc.Load("/Users/User/Projects/Etteplant-XMLFile-API/Etteplant-XMLFile-API/Data/XMLFile/sma_gentext.xml");
    XmlNodeList xmlNodeList = doc.GetElementsByTagName("trans-unit");


    connection.Open();
    for (int i = 0; i < xmlNodeList.Count; i++)
    {

        string sql = "Insert INTO [TransUnits] (Id,Target,Source) values (@Id,@Target,@Source)";

        SqlCommand sqlCommand = new SqlCommand(sql, connection);

        sqlCommand.Parameters.AddWithValue("@Id", Int32.Parse(xmlNodeList[i].Attributes[0].Value));
        sqlCommand.Parameters.AddWithValue("@Target", xmlNodeList[i].SelectSingleNode("target").InnerText.ToString());
        sqlCommand.Parameters.AddWithValue("@Source", xmlNodeList[i].SelectSingleNode("source").InnerText.ToString());

        sqlCommand.ExecuteNonQuery();

    }

    connection.Close();

}

var app = builder.Build();

app.UseCors(options => options.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



InsertDataFromXMLFileToDB(connectionString);
