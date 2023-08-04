using System.Xml;
using System.Data.SqlClient;

int targetID = 42007;

List<TransUnit> transUnits = new List<TransUnit>();

SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
builder.DataSource = "localhost";
builder.UserID = "sa";
builder.Password = "********";
builder.InitialCatalog = "TransUnitXMLFileDB";
SqlConnection connection = new SqlConnection(builder.ConnectionString);


    
    GetingDataFromDB(transUnits, connection,targetID);
    InsertDataFromXMLFileToDB(transUnits,connection);



static void GetingDataFromDB(List<TransUnit> transUnits, SqlConnection connection ,int targetID)
{
    Console.WriteLine("ID".PadRight(50) + "Target".PadRight(50) + "Source".PadRight(50));

    connection.Open();

    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TransUnits", connection);

    var Result = sqlCommand.ExecuteReader();

    while (Result.Read())
    {

        var id = Result.GetValue(0).ToString();
        var target = Result.GetValue(1).ToString();
        var source = Result.GetValue(2).ToString();

        if(Int32.Parse(id) == targetID) 
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.WriteLine(id.PadRight(50) + target.PadRight(50) + source.PadRight(50));

        transUnits.Add(new TransUnit(id,target,source));
    }
    connection.Close();
}

static void InsertDataFromXMLFileToDB(List<TransUnit>transUnits, SqlConnection connection)
{

    XmlDocument doc = new XmlDocument();
    // I used route import pass because I using mac os machin for development
    doc.Load("/Users/User/Projects/Etteplan-xml-consoleDB/Etteplan-xml-consoleDB/XMLFile/sma_gentext.xml");
    XmlNodeList xmlNodeList = doc.GetElementsByTagName("trans-unit");


    connection.Open();
    for (int i = 0; i < xmlNodeList.Count; i++)
    {
        if (CheckingId(transUnits, Int32.Parse(xmlNodeList[i].Attributes[0].Value)))
        {
            string sql = "Insert INTO [TransUnits] (Id,Target,Source) values (@Id,@Target,@Source)";

            SqlCommand sqlCommand = new SqlCommand(sql, connection);


            sqlCommand.Parameters.AddWithValue("@Id", Int32.Parse(xmlNodeList[i].Attributes[0].Value));
            sqlCommand.Parameters.AddWithValue("@Target", xmlNodeList[i].SelectSingleNode("target").InnerText.ToString());
            sqlCommand.Parameters.AddWithValue("@Source", xmlNodeList[i].SelectSingleNode("source").InnerText.ToString());



            sqlCommand.ExecuteNonQuery();

        }
    }

    connection.Close();


}

static bool CheckingId(List<TransUnit> transUnits, int id)
{

    List<int> ids = new List<int>();
    foreach ( TransUnit transUnit in transUnits)
    {
        ids.Add(Int32.Parse( transUnit.Id));
    }
    if (ids.Contains(id))
    {
        return false;
    }
    else
    {

        return true;
    }

}




Console.ReadLine();

class TransUnit
{

    public TransUnit() { }
    public TransUnit(string id, string target, string source)
    {
        Id = id;
        Target = target;
        Source= source;
    
    }



    public string Id { get; set; }
    public string Target { get; set; }
    public string Source { get; set; }
 
}


