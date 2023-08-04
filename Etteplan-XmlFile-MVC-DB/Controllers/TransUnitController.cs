using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Etteplan_XmlFile_MVC_DB.Data;
using Etteplan_XmlFile_MVC_DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace Etteplan_XmlFile_MVC_DB.Controllers
{
    public class TransUnitController : Controller
    {
        private readonly ApplicationDBContext _db;
        public TransUnitController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<TransUnit> transUnitsList = _db.TransUnits.ToList();
            return View(transUnitsList);
        }


        [HttpPost]
        public IActionResult InsertDataFromXMLFileToDB()
        {
            XmlDocument doc = new XmlDocument();
            // I used route import pass because I using mac os machin for development
            doc.Load("/Users/User/Projects/Etteplant-XMLFile-API/Etteplant-XMLFile-API/Data/XMLFile/sma_gentext.xml");
            XmlNodeList xmlNodeList = doc.GetElementsByTagName("trans-unit");


         
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
               var  tu = new TransUnit
                {
                    Id = Int32.Parse(xmlNodeList[i].Attributes[0].Value),
                    Target = xmlNodeList[i].SelectSingleNode("target").InnerText.ToString(),
                    Source = xmlNodeList[i].SelectSingleNode("source").InnerText.ToString()
                };
            _db.TransUnits.Add(tu);
                _db.SaveChanges();                

            }

            return (IActionResult)_db;
        }
         
    }
}