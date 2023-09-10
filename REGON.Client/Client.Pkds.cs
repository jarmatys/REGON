using REGON.Client.Enums;
using REGON.Client.Models;

namespace REGON.Client;

public partial class Client
{
    private async Task<PkdModel> GetPkdForPhysicalPerson(string regon)
    {
        var pkds = await _httpClient.PobierzPkdFizyczna(regon);

        var result = new PkdModel();
        var pkdList = new List<Pkd>();

        foreach (var pkd in pkds.Dane)
        {
            if (pkd.FizPkdPrzewazajace == 1)
            {
                result.MainPkd = new Pkd { Value = pkd.FizPkdKod, Name = pkd.FizPkdNazwa };
            }

            pkdList.Add(new Pkd { Value = pkd.FizPkdKod, Name = pkd.FizPkdNazwa });
        }

        result.RestPkds = pkdList;

        return result;
    }

    private async Task<PkdModel> GetPkdForLegalPerson(string regon)
    {
        var pkds = await _httpClient.PobierzPKDPrawna(regon);

        var result = new PkdModel();
        var pkdList = new List<Pkd>();

        foreach (var pkd in pkds.Dane)
        {
            if (pkd.PrawPkdPrzewazajace == 1)
            {
                result.MainPkd = new Pkd { Value = pkd.PrawPkdKod, Name = pkd.PrawPkdNazwa };
            }

            pkdList.Add(new Pkd { Value = pkd.PrawPkdKod, Name = pkd.PrawPkdNazwa });
        }

        result.RestPkds = pkdList;

        return result;
    }

    private async Task<PkdModel> GetPkds(LegalForm legalForm, string regon)
    {
        switch (legalForm)
        {
            case LegalForm.JDG:
            case LegalForm.SC:
                return await GetPkdForPhysicalPerson(regon);
            case LegalForm.SPZOO:
            case LegalForm.SA:
            case LegalForm.SPZOOSK:
            case LegalForm.SJ:
            case LegalForm.SKA:
            case LegalForm.SK:
                return await GetPkdForLegalPerson(regon);
            case LegalForm.ERROR:
            default:
                return null;
        }
    }
}