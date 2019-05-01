using OzelDers.DAL;
using OzelDers.REP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OzelDers.DTO.DTOs;
using static OzelDers.ENT.Entities;

namespace OzelDers.BL
{
    public class Repository
    {
        public class IlRepository : BaseRepository<Il>
        {
            public IlRepository(OzelDersContext db) : base(db)
            {

            }
            public async Task<ICollection<Il>> AsnDoldur()
            {
                return await ListAll();

            }
            public ICollection<IlDTO> Doldur()
            {
                return Set().Select(x => new IlDTO
                {
                    id = x.Id,
                    ad = x.Ad
                }).ToList();
            }
        }
        public class IlceRepository : BaseRepository<Ilce>
        {
            public IlceRepository(OzelDersContext db) : base(db)
            {

            }
            public async Task<ICollection<Ilce>> AsnDoldur()
            {
                return await ListAll();

            }
            public ICollection<IlceDTO> Doldur()
            {
                return Set().Select(x => new IlceDTO
                {
                    id = x.Id,
                    ad = x.Ad,
                    ilId = x.IlId
                }).ToList();
            }
        }
        public class DersAlaniRepository : BaseRepository<DersAlani>
        {
            public DersAlaniRepository(OzelDersContext db) : base(db)
            {

            }
            public async Task<ICollection<DersAlani>> AsnDoldur()
            {
                return await ListAll();

            }
            public ICollection<DersAlaniDTO> Doldur()
            {
                return Set().Select(x => new DersAlaniDTO
                {
                    id = x.Id,
                    ad = x.Ad
                }).ToList();
            }
        }
        public class DersKonusuRepository : BaseRepository<DersKonusu>
        {
            public DersKonusuRepository(OzelDersContext db) : base(db)
            {

            }
            public async Task<ICollection<DersKonusu>> AsnDoldur()
            {
                return await ListAll();

            }
            public ICollection<DersKonusuDTO> Doldur()
            {
                return Set().Select(x => new DersKonusuDTO
                {
                    id = x.Id,
                    ad = x.Ad,
                    dersAlaniId = x.DersAlaniId
                }).ToList();
            }
        }
        public class EgitmenRepository : BaseRepository<Egitmen>
        {
            public EgitmenRepository(OzelDersContext db) : base(db)
            {

            }
            public async Task<ICollection<Egitmen>> AsnDoldur()
            {
                return await ListAll();

            }
            public ICollection<EgitmenDTO> Doldur()
            {
                return Set().Select(x => new EgitmenDTO
                {
                    id = x.Id,
                    ad = x.Ad,
                    ilceId = x.IlceId,
                    //dersKonusuId = x.DersKonusuId,
                    ozgecmis = x.Ozgecmis,
                    telefonNo = x.TelefonNo
                }).ToList();
            }
        }
    }
}
