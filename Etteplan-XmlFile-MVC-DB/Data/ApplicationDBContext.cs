using System;
using Microsoft.EntityFrameworkCore;
using Etteplan_XmlFile_MVC_DB.Models;
using System.Xml;

namespace Etteplan_XmlFile_MVC_DB.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<TransUnit> TransUnits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            XmlDocument doc = new XmlDocument();
            // I used route import pass because I using mac os machin for development
            doc.Load("/Users/User/Projects/Etteplant-XMLFile-API/Etteplant-XMLFile-API/Data/XMLFile/sma_gentext.xml");
            XmlNodeList xmlNodeList = doc.GetElementsByTagName("trans-unit");

            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                modelBuilder.Entity<TransUnit>().HasData(
                    new TransUnit
                    {
                        Id = Int32.Parse(xmlNodeList[i].Attributes[0].Value),
                        Target = xmlNodeList[i].SelectSingleNode("target").InnerText.ToString(),
                        Source = xmlNodeList[i].SelectSingleNode("source").InnerText.ToString()
                    });
            }
        }

    }

}