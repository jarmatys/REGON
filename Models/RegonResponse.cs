using System;
using System.Collections.Generic;

namespace REGON.Models
{
    public class RegonResponse
    {
        public string Name { get; set; }
        public string Krs { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string BuildingNumber { get; set; }
        public string FlatNumber { get; set; }
        public string PostCode { get; set; }
        public string NIP { get; set; }
        public string REGON { get; set; }
        public string Commune { get; set; }
        public string District { get; set; }
        public string Voivodeship { get; set; }
        public string LegalForm { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsSuspended { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string WebsiteUrl { get; set; }
        public Pkd MainPkd { get; set; }
        public List<Pkd> Pkds { get; set; }
    }
}
