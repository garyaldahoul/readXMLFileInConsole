// See https://aka.ms/new-console-template for more information

using System.Xml;
using etteplan_xml_enterID;
int targetID = 42007;



TransUnitModel transUnitModel = new TransUnitModel();
transUnitModel.TransUnits = new List<TransUnit>();
List<int> ids = new List<int>();


XmlDocument doc = new XmlDocument();

// I used route import pass because I using mac os machin for development
doc.Load("/Users/User/Projects/Etteplan-xml-project/Etteplan-xml-project/sma_gentext.xml");

XmlNodeList xmlNodeList = doc.GetElementsByTagName("trans-unit");

for (int i = 0; i < xmlNodeList.Count; i++)
{
    ids.Add(int.Parse(xmlNodeList[i].Attributes[0].Value));
    transUnitModel.TransUnits.Add(new TransUnit
    {
        ID = int.Parse(xmlNodeList[i].Attributes[0].Value.ToString()),
        target = xmlNodeList[i].SelectSingleNode("target").InnerText.ToString(),
        source = xmlNodeList[i].SelectSingleNode("source").InnerText.ToString()

    });
}


while (true)
{
    Console.ForegroundColor = ConsoleColor.White;
    string enterID = "";
    do
    {
        Console.WriteLine("Enter Your ID...");
        enterID = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(enterID)&& enterID.All(char.IsDigit))
        {
            checkTarget(transUnitModel.TransUnits, ids,Int32.Parse( enterID), targetID);
        }
    } while (string.IsNullOrWhiteSpace(enterID));
}





static bool CheckIDs(List<int>ids, int enterID,int targetID)
{
    if (ids.Contains(enterID) && enterID == targetID)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Right Target ID");
        return true;
    }
    else if (ids.Contains(enterID))
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Exit ID But It IS Not The Target!!!");
        return true;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid ID!!!");
        return false;
    }
    
}
static void showResult(List<TransUnit> transUnits,int enterID)
{
    transUnits?.ForEach(tu => {
        if(tu.ID == enterID)
        {
            Console.WriteLine("The target is " + tu.target);
        }
    });
}

static void checkTarget(List<TransUnit>transUnits, List<int>ids,int enterID, int targetID)
{
    if(CheckIDs(ids,enterID,targetID) && enterID == targetID)
    {
        showResult(transUnits,enterID);
    }
    else if(enterID != targetID)
    {
        showResult(transUnits, enterID);
    }
    Console.ReadLine();
}



Console.ReadLine();
