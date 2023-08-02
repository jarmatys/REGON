using System;
using System.Collections.Generic;

namespace REGON.Models
{
    public class RegonResponse
    {
        public string Name { get; init; }
        public string Krs { get; init; }
        public string Street { get; init; }
        public string City { get; init; }
        public string BuildingNumber { get; init; }
        public string FlatNumber { get; init; }
        public string PostCode { get; init; }
        public string NIP { get; init; }
        public string REGON { get; init; }
        public string Commune { get; init; }
        public string District { get; init; }
        public string Voivodeship { get; init; }
        public string LegalForm { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime? EndDate { get; init; }
        public bool IsSuspended { get; init; }
        public bool IsActive { get; init; }
        public string PhoneNumber { get; init; }
        public string Email { get; init; }
        public string WebsiteUrl { get; init; }
        public Pkd MainPkd { get; init; }
        public List<Pkd> Pkds { get; init; }
    }
}
