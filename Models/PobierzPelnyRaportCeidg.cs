using System;
using System.Xml.Serialization;

namespace REGON.Models
{
	[XmlRoot(ElementName = "dane")]
	public class DanePobierzPelnyRaportCeidg
	{
		[XmlElement(ElementName = "fiz_regon9")]
		public string FizRegon9 { get; set; }

		[XmlElement(ElementName = "fiz_nazwa")]
		public string FizNazwa { get; set; }

		[XmlElement(ElementName = "fiz_nazwaSkrocona")]
		public string FizNazwaSkrocona { get; set; }

		[XmlElement(ElementName = "fiz_dataPowstania")]
		public string FizDataPowstania { get; set; }

		[XmlElement(ElementName = "fiz_dataRozpoczeciaDzialalnosci")]
		public string FizDataRozpoczeciaDzialalnosci { get; set; }

		[XmlElement(ElementName = "fiz_dataWpisuDzialalnosciDoRegon")]
		public string FizDataWpisuDzialalnosciDoRegon { get; set; }

		[XmlElement(ElementName = "fiz_dataZawieszeniaDzialalnosci")]
		public string FizDataZawieszeniaDzialalnosci { get; set; }

		[XmlElement(ElementName = "fiz_dataWznowieniaDzialalnosci")]
		public string FizDataWznowieniaDzialalnosci { get; set; }

		[XmlElement(ElementName = "fiz_dataZaistnieniaZmianyDzialalnosci")]
		public string FizDataZaistnieniaZmianyDzialalnosci { get; set; }

		[XmlElement(ElementName = "fiz_dataZakonczeniaDzialalnosci")]
		public string FizDataZakonczeniaDzialalnosci { get; set; }

		[XmlElement(ElementName = "fiz_dataSkresleniaDzialalnosciZRegon")]
		public string FizDataSkresleniaDzialalnosciZRegon { get; set; }

		[XmlElement(ElementName = "fiz_dataOrzeczeniaOUpadlosci")]
		public string FizDataOrzeczeniaOUpadlosci { get; set; }

		[XmlElement(ElementName = "fiz_dataZakonczeniaPostepowaniaUpadlosciowego")]
		public string FizDataZakonczeniaPostepowaniaUpadlosciowego { get; set; }

		[XmlElement(ElementName = "fiz_adSiedzKraj_Symbol")]
		public string FizAdSiedzKrajSymbol { get; set; }

		[XmlElement(ElementName = "fiz_adSiedzWojewodztwo_Symbol")]
		public string FizAdSiedzWojewodztwoSymbol { get; set; }

		[XmlElement(ElementName = "fiz_adSiedzPowiat_Symbol")]
		public string FizAdSiedzPowiatSymbol { get; set; }

		[XmlElement(ElementName = "fiz_adSiedzGmina_Symbol")]
		public string FizAdSiedzGminaSymbol { get; set; }

		[XmlElement(ElementName = "fiz_adSiedzKodPocztowy")]
		public string FizAdSiedzKodPocztowy { get; set; }

		[XmlElement(ElementName = "fiz_adSiedzMiejscowoscPoczty_Symbol")]
		public string FizAdSiedzMiejscowoscPocztySymbol { get; set; }

		[XmlElement(ElementName = "fiz_adSiedzMiejscowosc_Symbol")]
		public string FizAdSiedzMiejscowoscSymbol { get; set; }

		[XmlElement(ElementName = "fiz_adSiedzUlica_Symbol")]
		public string FizAdSiedzUlicaSymbol { get; set; }

		[XmlElement(ElementName = "fiz_adSiedzNumerNieruchomosci")]
		public string FizAdSiedzNumerNieruchomosci { get; set; }

		[XmlElement(ElementName = "fiz_adSiedzNumerLokalu")]
		public string FizAdSiedzNumerLokalu { get; set; }

		[XmlElement(ElementName = "fiz_adSiedzNietypoweMiejsceLokalizacji")]
		public string FizAdSiedzNietypoweMiejsceLokalizacji { get; set; }

		[XmlElement(ElementName = "fiz_numerTelefonu")]
		public string FizNumerTelefonu { get; set; }

		[XmlElement(ElementName = "fiz_numerWewnetrznyTelefonu")]
		public string FizNumerWewnetrznyTelefonu { get; set; }

		[XmlElement(ElementName = "fiz_numerFaksu")]
		public string FizNumerFaksu { get; set; }

		[XmlElement(ElementName = "fiz_adresEmail")]
		public string FizAdresEmail { get; set; }

		[XmlElement(ElementName = "fiz_adresStronyinternetowej")]
		public string FizAdresStronyinternetowej { get; set; }

		[XmlElement(ElementName = "fiz_adSiedzKraj_Nazwa")]
		public string FizAdSiedzKrajNazwa { get; set; }

		[XmlElement(ElementName = "fiz_adSiedzWojewodztwo_Nazwa")]
		public string FizAdSiedzWojewodztwoNazwa { get; set; }

		[XmlElement(ElementName = "fiz_adSiedzPowiat_Nazwa")]
		public string FizAdSiedzPowiatNazwa { get; set; }

		[XmlElement(ElementName = "fiz_adSiedzGmina_Nazwa")]
		public string FizAdSiedzGminaNazwa { get; set; }

		[XmlElement(ElementName = "fiz_adSiedzMiejscowosc_Nazwa")]
		public string FizAdSiedzMiejscowoscNazwa { get; set; }

		[XmlElement(ElementName = "fiz_adSiedzMiejscowoscPoczty_Nazwa")]
		public string FizAdSiedzMiejscowoscPocztyNazwa { get; set; }

		[XmlElement(ElementName = "fiz_adSiedzUlica_Nazwa")]
		public string FizAdSiedzUlicaNazwa { get; set; }

		[XmlElement(ElementName = "fizC_dataWpisuDoRejestruEwidencji")]
		public string FizCDataWpisuDoRejestruEwidencji { get; set; }

		[XmlElement(ElementName = "fizC_dataSkresleniaZRejestruEwidencji")]
		public string FizCDataSkresleniaZRejestruEwidencji { get; set; }

		[XmlElement(ElementName = "fizC_numerWRejestrzeEwidencji")]
		public string FizCNumerWRejestrzeEwidencji { get; set; }

		[XmlElement(ElementName = "fizC_OrganRejestrowy_Symbol")]
		public string FizCOrganRejestrowySymbol { get; set; }

		[XmlElement(ElementName = "fizC_OrganRejestrowy_Nazwa")]
		public string FizCOrganRejestrowyNazwa { get; set; }

		[XmlElement(ElementName = "fizC_RodzajRejestru_Symbol")]
		public string FizCRodzajRejestruSymbol { get; set; }

		[XmlElement(ElementName = "fizC_RodzajRejestru_Nazwa")]
		public string FizCRodzajRejestruNazwa { get; set; }

		[XmlElement(ElementName = "fizC_NiePodjetoDzialalnosci")]
		public bool FizCNiePodjetoDzialalnosci { get; set; }
	}

	[XmlRoot(ElementName = "root")]
	public class PobierzPelnyRaportCeidg
	{

		[XmlElement(ElementName = "dane")]
		public DanePobierzPelnyRaportCeidg Dane { get; set; }
	}

}
