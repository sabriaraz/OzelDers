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
        List<int> egitmenIdList;

        public DerslerController(OzelDersContext _db, List<int> _egitmenIdList)
        {
            db = _db;
            egitmenIdList = _egitmenIdList;

        }
        int dersKonusuId = 1;

        public IActionResult Liste(int Id)
        {
            List<AraTablo> araTablo = db.Set<AraTablo>().Where(x => x.DersKonusuId == dersKonusuId).ToList();

            foreach (var item in araTablo)
            {
                egitmenIdList.Add(item.EgitmenId);
            }

            List<EgitmenDTO> egitmenList = db.Set<Egitmen>().Where(x => egitmenIdList.Contains(x.Id)).Select(x => new EgitmenDTO
            {
                id = x.Id,
                ad = x.Ad,
                telefonNo = x.TelefonNo,
                ozgecmis = x.Ozgecmis,
                ilceAd = x.Ilce.Ad,
                ilceId = x.IlceId,
                AraTablo = x.AraTablo.ToList()

            }).ToList();
            
            return Json(egitmenList);
        }
    }
}