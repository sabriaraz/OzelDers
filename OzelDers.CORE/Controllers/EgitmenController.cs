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
    public class EgitmenController : Controller
    {
        EgitmenRepository egiRep;
        IMapper map;
        public EgitmenController(EgitmenRepository _egiRep, IMapper _map)
        {
            map = _map;
            egiRep = _egiRep;
        }
        public IActionResult Liste()
        {
            ICollection<EgitmenDTO> elist = egiRep.Doldur();
            return Json(elist);
        }
        [HttpPost]
        public async Task<JsonResult> Ekle([FromBody]EgitmenDTO egiDTO)
        {
            Egitmen egi = new Egitmen();
            egi = map.Map(egiDTO, egi);
            egi.Id = 0;
            egiRep.Add(egi);
            await egiRep.Commit();
            return Json(egiDTO);
        }
        [HttpPost]
        public async Task<JsonResult> Guncelle([FromBody]EgitmenDTO egiDTO)
        {
            Egitmen egi = new Egitmen();
            egi = map.Map(egiDTO, egi);
            egiRep.Update(egi);
            await egiRep.Commit();
            return Json(egiDTO);
        }
        [HttpPost]
        public async Task<JsonResult> Sil([FromBody]EgitmenDTO egiDTO)
        {
            Egitmen egi = new Egitmen();
            egi = map.Map(egiDTO, egi);
            egiRep.Delete(egi);
            await egiRep.Commit();
            return Json(egiDTO);
        }
    }
}