using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OzelDers.ENT
{
    public class Entities
    {
        [Table("Il")]
        public class Il
        {
            [Key]
            public int Id { get; set; }
            public string Ad { get; set; }

            public virtual ICollection<Ilce> Ilce { get; set; }
        }
        [Table("Ilce")]
        public class Ilce
        {
            [Key]
            public int Id { get; set; }
            public string Ad { get; set; }

            public int IlId { get; set; } 
            [ForeignKey("IlId")]
            public virtual Il Il { get; set; }

            public virtual ICollection<Egitmen> Egitmen { get; set; }
        }
        [Table("DersAlani")]
        public class DersAlani
        {
            [Key]
            public int Id { get; set; }
            public string Ad { get; set; }

            public virtual ICollection<DersKonusu> DersKonusu { get; set; }
        }
        [Table("DersKonusu")]
        public class DersKonusu
        {
            [Key]
            public int Id { get; set; }
            public string Ad { get; set; }

            public int DersAlaniId { get; set; } 
            [ForeignKey("DersAlaniId")]
            public virtual DersAlani DersAlani { get; set; }
            public virtual ICollection<AraTablo> AraTablo { get; set; }
            
        }

        [Table("AraTablo")]
        public class   AraTablo
        {
            public int Id { get; set; }

            public int EgitmenId { get; set; }
            [ForeignKey("EgitmenId")]
            public virtual Egitmen Egitmen { get; set; }

            public int DersKonusuId  { get; set; }

            [ForeignKey("DersKonusuId")]
            public virtual DersKonusu DersKonusu { get; set; }
        }

        [Table("Egitmen")]
        public class Egitmen
        {
            [Key]
            public int Id { get; set; }
            public string Ad { get; set; }

            public int IlceId { get; set; }
            [ForeignKey("IlceId")]
            public virtual Ilce Ilce { get; set; }


            public decimal Fiyat { get; set; }
            public string Ozgecmis { get; set; }
            public double TelefonNo { get; set; }

            public virtual ICollection<AraTablo> AraTablo { get; set; }
        }
    }
}
