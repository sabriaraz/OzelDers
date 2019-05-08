using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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
        IHttpContextAccessor httpContextAccessor;
        public DerslerController(IHttpContextAccessor _httpContextAccessor,OzelDersContext _db, List<int> _egitmenIdList, EgitmenRepository _eRep, AraTabloRepository _araRep)
        {
            httpContextAccessor = _httpContextAccessor;
            eRep = _eRep;
            db = _db;
            araRep = _araRep;
            egitmenIdList = _egitmenIdList;
        }

        [Authorize, HttpGet]
        public IActionResult ListAll()
        {
            List<EgitmenDTO> egitmenList = eRep.Doldur().ToList();
            return Json(egitmenList);

        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult ListForID(int Id)
        {
            List<int> egitmenIdList = araRep.egitmenIdList(Id);
            List<EgitmenDTO> egitmenList = eRep.Doldur(egitmenIdList).ToList();
            return Json(egitmenList);
        }

    }
}