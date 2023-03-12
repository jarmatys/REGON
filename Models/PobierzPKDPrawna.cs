﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace REGON.Models
{
	[XmlRoot(ElementName = "dane")]
	public class DanePrawna
	{

		[XmlElement(ElementName = "praw_pkdKod")]
		public string PrawPkdKod { get; set; }

		[XmlElement(ElementName = "praw_pkdNazwa")]
		public string PrawPkdNazwa { get; set; }

		[XmlElement(ElementName = "praw_pkdPrzewazajace")]
		public int PrawPkdPrzewazajace { get; set; }
	}

	[XmlRoot(ElementName = "Root")]
	public class PobierzPKDPrawna
	{

		[XmlElement(ElementName = "dane")]
		public List<DanePrawna> Dane { get; set; }
	}
}
