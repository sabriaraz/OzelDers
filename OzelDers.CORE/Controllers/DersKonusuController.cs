using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using static OzelDers.BL.Repository;
using static OzelDers.DTO.DTOs;
using static OzelDers.ENT.Entities;

namespace OzelDers.CORE.Controllers
{
    public class DersKonusuController : Controller
    {
        DersKonusuRepository dkRep;
        IMapper map;
        public DersKonusuController(DersKonusuRepository _dkRep, IMapper _map)
        {
            map = _map;
            dkRep = _dkRep;
        }
        public IActionResult Liste()
        {
            ICollection<DersKonusuDTO> dkList = dkRep.Doldur();
            return Json(dkList);
        }
        [HttpPost]
        public async Task<JsonResult> Ekle([FromBody]DersKonusuDTO dkDTO)
        {
            DersKonusu dk = new DersKonusu();
            dk = map.Map(dkDTO, dk);
            dk.Id = 0;
            dkRep.Add(dk);
            await dkRep.Commit();
            return Json(dk);
        }
        [HttpPost]
        public async Task<JsonResult> Guncelle([FromBody]DersKonusuDTO dkDTO)
        {
            DersKonusu dk = new DersKonusu();
            dk = map.Map(dkDTO, dk);
            dkRep.Update(dk);
            await dkRep.Commit();
            return Json(dkDTO);
        }
        [HttpPost]
        public async Task<JsonResult> Sil([FromBody]DersKonusuDTO dkDTO)
        {
            DersKonusu dk = new DersKonusu();
            dk = map.Map(dkDTO, dk);
            dkRep.Delete(dk);
            await dkRep.Commit();
            return Json(dkDTO);
        }
    }
}