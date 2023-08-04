using System;
using Etteplant_XMLFile_API.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Xml;

namespace Etteplant_XMLFile_API.Data
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