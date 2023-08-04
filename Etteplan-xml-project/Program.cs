using System;
using System.Xml;
using System.Linq;



 static void ReadXMLFile()
{

    int targetID = 42007;

    XmlDocument doc = new XmlDocument();

    // I used route import pass because I using mac os machin for development
    doc.Load("/Users/User/Projects/Etteplan-xml-project/Etteplan-xml-project/sma_gentext.xml");

    XmlNodeList xmlNodeList = doc.GetElementsByTagName("trans-unit");

    Console.WriteLine(xmlNodeList);
    foreach (XmlNode xmlNode in xmlNodeList)
    {
        if (xmlNode.Attributes[0].Value == targetID.ToString())
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(xmlNode.Attributes[0].Value);
            Console.WriteLine("The target for the id " + xmlNode.Attributes[0].Value + " : " + xmlNode.SelectSingleNode("target").InnerText);
            Console.WriteLine("The source for the id " + xmlNode.Attributes[0].Value + " : " + xmlNode.SelectSingleNode("source").InnerText);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.WriteLine();
    }
}

ReadXMLFile();
Console.ReadLine();