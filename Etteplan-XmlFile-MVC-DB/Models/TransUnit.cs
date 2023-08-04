
using System.ComponentModel.DataAnnotations;


namespace Etteplan_XmlFile_MVC_DB.Models
{
	public class TransUnit
	{
		[Key]
		public int Id { get; set; }
		public string Target { get; set; }
		public string Source { get; set; }
	}
}

