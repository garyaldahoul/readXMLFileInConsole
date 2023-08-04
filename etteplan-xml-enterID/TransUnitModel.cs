
using System;
namespace etteplan_xml_enterID
{
	public class TransUnitModel
	{
		public List<TransUnit>? TransUnits { get; set; }
    }

	public class TransUnit
	{
		public int ID { get; set; }
		public string target { get; set; }
		public string source { get; set; }
	}

   
}

