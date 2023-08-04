
using System;
namespace Etteplan_XmlFile_MVC.Models
{
	public class TransUnitModel
	{
		public List<TransUnit> TransUnits { get; set; }
	}
    public class TransUnit
    {
        public int Id { get; set; }
        public string target { get; set; }
        public string source { get; set; }
    }
}

