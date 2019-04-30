using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OzelDers.DAL;
using static OzelDers.BL.Repository;
using static OzelDers.DTO.DTOs;
using static OzelDers.ENT.Entities;

namespace OzelDers.CORE.Controllers
{
    public class IlController : Controller
    {
        IlRepository ilRep;
        public IlController(IlRepository _ilrep)
        {
            ilRep = _ilrep;
        }
        public IActionResult Liste()
        {
            ICollection<IlDTO> ilist = ilRep.Doldur();
            return Json(ilist);
        }
        [HttpPost]
        public async Task<JsonResult> Ekle([FromBody]IlDTO ilDTO)
        {
            Il il = new Il();
            il.Ad = ilDTO.ad;
            ilRep.Add(il);
            await ilRep.Commit();
            return Json(il);
        }
        [HttpPost]
        public async Task<JsonResult> Guncelle([FromBody]IlDTO ilDTO)
        {
            Il il = new Il();
            il.Id = ilDTO.id;
            il.Ad = ilDTO.ad;
            ilRep.Update(il);
            await ilRep.Commit();
            return Json(ilDTO);
        }
        [HttpPost]
        public async Task<JsonResult> Sil([FromBody]IlDTO ilDTO)
        {
            Il il = new Il();
            il.Id = ilDTO.id;
            il.Ad = ilDTO.ad;
            ilRep.Delete(il);
            await ilRep.Commit();
            return Json(ilDTO);
        }
    }
}