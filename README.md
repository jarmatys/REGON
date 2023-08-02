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
