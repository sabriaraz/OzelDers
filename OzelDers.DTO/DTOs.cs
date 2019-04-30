using System;
using System.Collections.Generic;
using System.Text;
using static OzelDers.ENT.Entities;

namespace OzelDers.DTO
{
    public class DTOs
    {
        public class derslerDTO
        {
            public int egitmenId  { get; set; }
            public string EgitmenAd  { get; set; }
            public string DersKonusu   { get; set; }
            public List<AraTablo> AraTablo { get; set; }
            
        }
        public class IlDTO
        {
            public int id { get; set; }
            public string ad { get; set; }
        }
        public class IlceDTO
        {
            public int id { get; set; }
            public string ad { get; set; }
            public int ilId { get; set; }
        }
        public class DersAlaniDTO
        {
            public int id { get; set; }
            public string ad { get; set; }
        }
        public class DersKonusuDTO
        {
            public int id { get; set; }
            public string ad { get; set; }
            public int dersAlaniId { get; set; }
        }
        public class EgitmenDTO
        {
            public int id { get; set; }
            public string ad { get; set; }
            public int ilceId { get; set; }
            public int dersKonusuId { get; set; }
            public decimal fiyat { get; set; }
            public string ozgecmis { get; set; }
            public double telefonNo { get; set; }
        }
    }
}
