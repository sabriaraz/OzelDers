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
    public class IlceController : Controller
    {
        IlceRepository ilceRep;
        IMapper map;
        public IlceController(IlceRepository _ilceRep, IMapper _map)
        {
            map = _map;
            ilceRep = _ilceRep;
        }
        public IActionResult Liste()
        {
            ICollection<IlceDTO> ilcelist = ilceRep.Doldur();
            return Json(ilcelist);
        }
        [HttpPost]
        public async Task<JsonResult> Ekle([FromBody]IlceDTO ilceDTO)
        {
            Ilce ilce = new Ilce(); 
            ilce = map.Map(ilceDTO, ilce);
            ilce.Id = 0;
            ilceRep.Add(ilce);
            await ilceRep.Commit();
            return Json(ilceDTO);
        }
        [HttpPost]
        public async Task<JsonResult> Guncelle([FromBody]IlceDTO ilceDTO)
        {
            Ilce ilce = new Ilce();
            ilce = map.Map(ilceDTO, ilce);
            ilceRep.Update(ilce);
            await ilceRep.Commit();
            return Json(ilceDTO);
        }
        [HttpPost]
        public async Task<JsonResult> Sil([FromBody]IlceDTO ilceDTO)
        {
            Ilce ilce = new Ilce();
            ilce = map.Map(ilceDTO, ilce);
            ilceRep.Delete(ilce);
            await ilceRep.Commit();
            return Json(ilceDTO);
        }
    }
}