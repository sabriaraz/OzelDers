﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OzelDers.DAL;
using static OzelDers.BL.Repository;
using static OzelDers.DTO.DTOs;
using static OzelDers.ENT.Entities;

namespace OzelDers.CORE.Controllers
{
    public class DerslerController : Controller
    {
        OzelDersContext db;
        List<int> egitmenIdList;
        EgitmenRepository eRep;
        AraTabloRepository araRep;
        DersKonusuRepository dkRep;
        public DerslerController(OzelDersContext _db, List<int> _egitmenIdList, DersKonusuRepository _dkRep,EgitmenRepository _eRep, AraTabloRepository _araRep)
        {
            dkRep = _dkRep;
            eRep = _eRep;
            db = _db;
            araRep = _araRep;
            egitmenIdList = _egitmenIdList;

        }

        [HttpGet]
        public IActionResult ListAll()
        {
            List<EgitmenDTO> egitmenList = eRep.Doldur().ToList();
            return Json(egitmenList);
        }
        [HttpPost]
        public IActionResult ListForID(int Id)
        {
            List<int> egitmenIdList = araRep.egitmenIdList(Id);
            List<EgitmenDTO> egitmenList = eRep.Doldur(egitmenIdList).ToList();
            return Json(egitmenList);
        }
    }
}