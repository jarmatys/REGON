using System.Collections.Generic;
using System.Xml.Serialization;

namespace REGON.Infrastructure.Models
{
	[XmlRoot(ElementName = "dane")]
	public class Dane
	{

		[XmlElement(ElementName = "fiz_pkd_Kod")]
		public string FizPkdKod { get; set; }

		[XmlElement(ElementName = "fiz_pkd_Nazwa")]
		public string FizPkdNazwa { get; set; }

		[XmlElement(ElementName = "fiz_pkd_Przewazajace")]
		public int FizPkdPrzewazajace { get; set; }

		[XmlElement(ElementName = "fiz_SilosID")]
		public int FizSilosID { get; set; }

		[XmlElement(ElementName = "fiz_Silos_Symbol")]
		public string FizSilosSymbol { get; set; }

		[XmlElement(ElementName = "fiz_dataSkresleniaDzialalnosciZRegon")]
		public object FizDataSkresleniaDzialalnosciZRegon { get; set; }
	}

	[XmlRoot(ElementName = "Root")]
	public class PobierzPKDFizyczna
	{

		[XmlElement(ElementName = "dane")]
		public List<Dane> Dane { get; set; }
	}
}
