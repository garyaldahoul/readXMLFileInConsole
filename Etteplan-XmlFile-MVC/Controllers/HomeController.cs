using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Etteplan_XmlFile_MVC.Models;
using System.Xml;

namespace Etteplan_XmlFile_MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        TransUnitModel transUnit = new TransUnitModel();
        transUnit.TransUnits = new List<TransUnit>();

        XmlDocument doc = new XmlDocument();
        string xmlFilePath = "/Users/User/Projects/Etteplan-XmlFile-MVC/Etteplan-XmlFile-MVC/XMLFile/sma_gentext.xml";
        doc.Load("/Users/User/Projects/Etteplan-xml-consoleDB/Etteplan-xml-consoleDB/XMLFile/sma_gentext.xml");
        XmlNodeList xmlNodeList = doc.GetElementsByTagName("trans-unit");

        for (int i = 0; i < xmlNodeList.Count; i++)
        {
            transUnit.TransUnits.Add(new TransUnit
            {
                Id = Int32.Parse(xmlNodeList[i].Attributes[0].Value),
                target = xmlNodeList[i].SelectSingleNode("target").InnerText.ToString(),
                source = xmlNodeList[i].SelectSingleNode("source").InnerText.ToString()
            }) ;
        }


        return View(transUnit);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

