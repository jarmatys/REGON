 # REGON

 Klient dla REGON SOAP API dla aplikacji .NET. 
 
![GitHub](https://img.shields.io/github/license/jarmatys/REGON) ![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/jarmatys/REGON/release-package.yml?label=release) ![Nuget](https://img.shields.io/nuget/v/REGON?label=version) ![Nuget](https://img.shields.io/nuget/dt/REGON) ![GitHub issues](https://img.shields.io/github/issues/jarmatys/REGON) ![GitHub pull requests](https://img.shields.io/github/issues-pr/jarmatys/REGON) 


## Instalacja
```
dotnet add package REGON --version X.X.X
```

## Użycie

Wstrzykiwanie klienta REGON za pomocą dependency injection:

```bash
services.AddRegonClient("<TWOJ-KLUCZ-API>");
```

Użycie klienta:
```
private readonly IRegonClient _regonClient;

public Konstruktor(IRegonClient regonClient)
{
    _regonClient = regonClient;
}
```

## Metody
- GetCompanyDataByNip(string nip)
- GetCompanyDataByKrs(string krs)

## Przykładowa odpowiedź z `RegonClient`

```json
{
  "Nip": "7010790303",
  "Krs": "",
  "Name": "RK RECOVERY SPÓŁKA AKCYJNA",
  "Street": "Plac Konesera",
  "City": "Warszawa",
  "BuildingNumber": "10 A",
  "FlatNumber": "",
  "PostCode": "03-736",
  "REGON": "369010805",
  "Commune": "Praga-Północ",
  "District": "Warszawa",
  "Voivodeship": "MAZOWIECKIE",
  "LegalForm": 3,
  "MainPkd": "6920Z",
  "StartDate": "2017-12-15T00:00:00",
  "EndDate": null,
  "IsSuspended": false,
  "IsActive": true,
  "PhoneNumber": null,
  "Email": null,
  "WebsiteUrl": null,
  "Pkds": [
    {
      "Value": "6920Z",
      "Name": "DZIAŁALNOŚĆ RACHUNKOWO-KSIĘGOWA; DORADZTWO PODATKOWE"
    },
    {
      "Value": "6910Z",
      "Name": "DZIAŁALNOŚĆ PRAWNICZA"
    }
  ]
}
```

### Szukasz pomocy w implementacji klienta REGON we własnym projekcie?

Skontaktuj się ze mną korzystając z danych na stronie [armatys.me](https://armatys.me).