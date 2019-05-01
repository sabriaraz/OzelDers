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

            List<AraTablo> araTablo = db.Set<AraTablo>().Where(x => x.DersKonusuId == 1).ToList();
            List<int> elist = new List<int>();
            foreach (var item in araTablo)
            {
                elist.Add(item.EgitmenId);
            }

            List<Egitmen> egitmenList = db.Set<Egitmen>().ToList();
            return Json(egitmenList);
        }
    }
}