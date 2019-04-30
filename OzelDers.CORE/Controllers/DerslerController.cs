using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OzelDers.DAL;
using static OzelDers.DTO.DTOs;
using static OzelDers.ENT.Entities;

namespace OzelDers.CORE.Controllers
{
    public class DerslerController : Controller
    {
        OzelDersContext db;
        public DerslerController(OzelDersContext _db)
        {
            db = _db;

        }
        public IActionResult Liste()
        {
            //List<derslerDTO> dList = db.Set<Egitmen>().Select(x => new derslerDTO {
            //        egitmenId = x.Id,
            //        EgitmenAd = x.Ad,
            //        AraTablo = x.AraTablo.ToList(),

            //}).ToList();
            List<Egitmen> dList = db.Set<Egitmen>().ToList();

            return Json(dList);
        }
    }
}