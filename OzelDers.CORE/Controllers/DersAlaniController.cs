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
    public class DersAlaniController : Controller
    {
        DersAlaniRepository daRep;
        IMapper map;
        public DersAlaniController(DersAlaniRepository _daRep, IMapper _map)
        {
            map = _map;
            daRep = _daRep;
        }
        public IActionResult Liste()
        {
            ICollection<DersAlaniDTO> daList = daRep.Doldur();
            return Json(daList);
        }
        [HttpPost]
        public async Task<JsonResult> Ekle([FromBody]DersAlaniDTO daDTO)
        {
            DersAlani da = new DersAlani();
            da = map.Map(daDTO, da);
            da.Id = 0;
            daRep.Add(da);
            await daRep.Commit();
            return Json(da);
        }
        [HttpPost]
        public async Task<JsonResult> Guncelle([FromBody]DersAlaniDTO daDTO)
        {
            DersAlani da = new DersAlani();
            da = map.Map(daDTO, da);
            daRep.Update(da);
            await daRep.Commit();
            return Json(daDTO);
        }
        [HttpPost]
        public async Task<JsonResult> Sil([FromBody]DersAlaniDTO daDTO)
        {
            DersAlani da = new DersAlani();
            da = map.Map(daDTO, da);
            daRep.Delete(da);
            await daRep.Commit();
            return Json(daDTO);
        }
    }
}