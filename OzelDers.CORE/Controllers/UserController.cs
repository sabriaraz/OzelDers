using System;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using OzelDers.CORE.Services;
using OzelDers.CORE.Helpers;
using static OzelDers.DTO.DTOs;
using static OzelDers.ENT.Entities;
using OzelDers.DAL;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OzelDers.CORE.Models;

namespace OzelDers.CORE.Controllers
{
    //  [Authorize]
    //[ApiController]
    //[Route("[controller]")]
    public class UserController : ControllerBase
    {
        OzelDersContext db;
        private IEgitmenService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        public UserController(IEgitmenService userService, IMapper mapper, IOptions<AppSettings> appSettings, OzelDersContext _db)
        {
            db = _db;
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        [HttpGet]
        [Authorize]
        public IActionResult TEST()
        {
            List<EgitmenDTO> eList = db.Set<Egitmen>().Select(x => new EgitmenDTO
            {
                ad = x.Ad,
                soyadAd = x.SoyadAd,
                eMail = x.eMail,
                ilceAd = x.Ilce.Ad,
                ilceId = x.IlceId,
                ozgecmis = x.Ozgecmis,
                AraTablo = x.AraTablo.ToList(),
                password = x.PasswordHash.ToString(),
                telefonNo = x.TelefonNo,
            }).ToList();
            return Ok(eList);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]EgitmenDTO userDto)
        {
            var user = _userService.Authenticate(userDto.eMail, userDto.password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Id = user.Id,
                Username = user.Ad + user.SoyadAd,
                FirstName = user.Ad,
                LastName = user.SoyadAd,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register([FromBody]EgitmenDTO userDto)
        {
            // map dto to entity
            Egitmen user = new Egitmen();
            user = _mapper.Map<Egitmen>(userDto);
            user.IlceId = 1;


            // save 
            _userService.Create(user, userDto.password);
            return Ok(user);


        }
    }
}