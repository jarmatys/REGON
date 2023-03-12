using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace REGON.Models
{
	[XmlRoot(ElementName = "dane")]
	public class DanePobierzPelnyRaport
	{
		[XmlElement(ElementName = "praw_regon9")]
		public string PrawRegon9 { get; set; }

		[XmlElement(ElementName = "praw_nip")]
		public string PrawNip { get; set; }

		[XmlElement(ElementName = "praw_statusNip")]
		public string PrawStatusNip { get; set; }

		[XmlElement(ElementName = "praw_nazwa")]
		public string PrawNazwa { get; set; }

		[XmlElement(ElementName = "praw_nazwaSkrocona")]
		public string PrawNazwaSkrocona { get; set; }

		[XmlElement(ElementName = "praw_numerWRejestrzeEwidencji")]
		public string PrawNumerWRejestrzeEwidencji { get; set; }

		[XmlElement(ElementName = "praw_dataWpisuDoRejestruEwidencji")]
		public string PrawDataWpisuDoRejestruEwidencji { get; set; }

		[XmlElement(ElementName = "praw_dataPowstania")]
		public string PrawDataPowstania { get; set; }

		[XmlElement(ElementName = "praw_dataRozpoczeciaDzialalnosci")]
		public string PrawDataRozpoczeciaDzialalnosci { get; set; }

		[XmlElement(ElementName = "praw_dataWpisuDoRegon")]
		public string PrawDataWpisuDoRegon { get; set; }

		[XmlElement(ElementName = "praw_dataZawieszeniaDzialalnosci")]
		public string PrawDataZawieszeniaDzialalnosci { get; set; }

		[XmlElement(ElementName = "praw_dataWznowieniaDzialalnosci")]
		public string PrawDataWznowieniaDzialalnosci { get; set; }

		[XmlElement(ElementName = "praw_dataZaistnieniaZmiany")]
		public string PrawDataZaistnieniaZmiany { get; set; }

		[XmlElement(ElementName = "praw_dataZakonczeniaDzialalnosci")]
		public string PrawDataZakonczeniaDzialalnosci { get; set; }

		[XmlElement(ElementName = "praw_dataSkresleniaZRegon")]
		public string PrawDataSkresleniaZRegon { get; set; }

		[XmlElement(ElementName = "praw_dataOrzeczeniaOUpadlosci")]
		public string PrawDataOrzeczeniaOUpadlosci { get; set; }

		[XmlElement(ElementName = "praw_dataZakonczeniaPostepowaniaUpadlosciowego")]
		public string PrawDataZakonczeniaPostepowaniaUpadlosciowego { get; set; }

		[XmlElement(ElementName = "praw_adSiedzKraj_Symbol")]
		public string PrawAdSiedzKrajSymbol { get; set; }

		[XmlElement(ElementName = "praw_adSiedzWojewodztwo_Symbol")]
		public string PrawAdSiedzWojewodztwoSymbol { get; set; }

		[XmlElement(ElementName = "praw_adSiedzPowiat_Symbol")]
		public string PrawAdSiedzPowiatSymbol { get; set; }

		[XmlElement(ElementName = "praw_adSiedzGmina_Symbol")]
		public string PrawAdSiedzGminaSymbol { get; set; }

		[XmlElement(ElementName = "praw_adSiedzKodPocztowy")]
		public string PrawAdSiedzKodPocztowy { get; set; }

		[XmlElement(ElementName = "praw_adSiedzMiejscowoscPoczty_Symbol")]
		public string PrawAdSiedzMiejscowoscPocztySymbol { get; set; }

		[XmlElement(ElementName = "praw_adSiedzMiejscowosc_Symbol")]
		public string PrawAdSiedzMiejscowoscSymbol { get; set; }

		[XmlElement(ElementName = "praw_adSiedzUlica_Symbol")]
		public string PrawAdSiedzUlicaSymbol { get; set; }

		[XmlElement(ElementName = "praw_adSiedzNumerNieruchomosci")]
		public string PrawAdSiedzNumerNieruchomosci { get; set; }

		[XmlElement(ElementName = "praw_adSiedzNumerLokalu")]
		public string PrawAdSiedzNumerLokalu { get; set; }

		[XmlElement(ElementName = "praw_adSiedzNietypoweMiejsceLokalizacji")]
		public string PrawAdSiedzNietypoweMiejsceLokalizacji { get; set; }

		[XmlElement(ElementName = "praw_numerTelefonu")]
		public string PrawNumerTelefonu { get; set; }

		[XmlElement(ElementName = "praw_numerWewnetrznyTelefonu")]
		public string PrawNumerWewnetrznyTelefonu { get; set; }

		[XmlElement(ElementName = "praw_numerFaksu")]
		public string PrawNumerFaksu { get; set; }

		[XmlElement(ElementName = "praw_adresEmail")]
		public string PrawAdresEmail { get; set; }

		[XmlElement(ElementName = "praw_adresStronyinternetowej")]
		public string PrawAdresStronyinternetowej { get; set; }

		[XmlElement(ElementName = "praw_adSiedzKraj_Nazwa")]
		public string PrawAdSiedzKrajNazwa { get; set; }

		[XmlElement(ElementName = "praw_adSiedzWojewodztwo_Nazwa")]
		public string PrawAdSiedzWojewodztwoNazwa { get; set; }

		[XmlElement(ElementName = "praw_adSiedzPowiat_Nazwa")]
		public string PrawAdSiedzPowiatNazwa { get; set; }

		[XmlElement(ElementName = "praw_adSiedzGmina_Nazwa")]
		public string PrawAdSiedzGminaNazwa { get; set; }

		[XmlElement(ElementName = "praw_adSiedzMiejscowosc_Nazwa")]
		public string PrawAdSiedzMiejscowoscNazwa { get; set; }

		[XmlElement(ElementName = "praw_adSiedzMiejscowoscPoczty_Nazwa")]
		public string PrawAdSiedzMiejscowoscPocztyNazwa { get; set; }

		[XmlElement(ElementName = "praw_adSiedzUlica_Nazwa")]
		public string PrawAdSiedzUlicaNazwa { get; set; }

		[XmlElement(ElementName = "praw_podstawowaFormaPrawna_Symbol")]
		public string PrawPodstawowaFormaPrawnaSymbol { get; set; }

		[XmlElement(ElementName = "praw_szczegolnaFormaPrawna_Symbol")]
		public string PrawSzczegolnaFormaPrawnaSymbol { get; set; }

		[XmlElement(ElementName = "praw_formaFinansowania_Symbol")]
		public string PrawFormaFinansowaniaSymbol { get; set; }

		[XmlElement(ElementName = "praw_formaWlasnosci_Symbol")]
		public string PrawFormaWlasnosciSymbol { get; set; }

		[XmlElement(ElementName = "praw_organZalozycielski_Symbol")]
		public string PrawOrganZalozycielskiSymbol { get; set; }

		[XmlElement(ElementName = "praw_organRejestrowy_Symbol")]
		public string PrawOrganRejestrowySymbol { get; set; }

		[XmlElement(ElementName = "praw_rodzajRejestruEwidencji_Symbol")]
		public string PrawRodzajRejestruEwidencjiSymbol { get; set; }

		[XmlElement(ElementName = "praw_podstawowaFormaPrawna_Nazwa")]
		public string PrawPodstawowaFormaPrawnaNazwa { get; set; }

		[XmlElement(ElementName = "praw_szczegolnaFormaPrawna_Nazwa")]
		public string PrawSzczegolnaFormaPrawnaNazwa { get; set; }

		[XmlElement(ElementName = "praw_formaFinansowania_Nazwa")]
		public string PrawFormaFinansowaniaNazwa { get; set; }

		[XmlElement(ElementName = "praw_formaWlasnosci_Nazwa")]
		public string PrawFormaWlasnosciNazwa { get; set; }

		[XmlElement(ElementName = "praw_organZalozycielski_Nazwa")]
		public string PrawOrganZalozycielskiNazwa { get; set; }

		[XmlElement(ElementName = "praw_organRejestrowy_Nazwa")]
		public string PrawOrganRejestrowyNazwa { get; set; }

		[XmlElement(ElementName = "praw_rodzajRejestruEwidencji_Nazwa")]
		public string PrawRodzajRejestruEwidencjiNazwa { get; set; }

		[XmlElement(ElementName = "praw_liczbaJednLokalnych")]
		public string PrawLiczbaJednLokalnych { get; set; }
	}

	[XmlRoot(ElementName = "root")]
	public class PobierzPelnyRaport
	{
		[XmlElement(ElementName = "dane")]
		public DanePobierzPelnyRaport Dane { get; set; }
	}
}
