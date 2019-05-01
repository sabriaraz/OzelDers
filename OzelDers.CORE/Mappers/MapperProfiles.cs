using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OzelDers.DTO.DTOs;
using static OzelDers.ENT.Entities;

namespace OzelDers.CORE.Mappers
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            // Il Mapper
            CreateMap<Il, IlDTO>().ForMember(des => des.id, opt => opt.MapFrom(src => src.Id)).ForMember(des => des.ad, opt => opt.MapFrom(src => src.Ad));
            CreateMap<IlDTO, Il>().ForMember(des => des.Id, opt => opt.MapFrom(src => src.id)).ForMember(des => des.Ad, opt => opt.MapFrom(src => src.ad));
            //Ilce Mapper 
            CreateMap<Ilce, IlceDTO>().ForMember(des => des.id, opt => opt.MapFrom(src => src.Id)).ForMember(des => des.ad, opt => opt.MapFrom(src => src.Ad)).ForMember(des => des.ilId, opt => opt.MapFrom(src => src.IlId));
            CreateMap<IlceDTO, Ilce>().ForMember(des => des.Id, opt => opt.MapFrom(src => src.id)).ForMember(des => des.Ad, opt => opt.MapFrom(src => src.ad)).ForMember(des => des.IlId, opt => opt.MapFrom(src => src.ilId));
            // DersAlani Mapper
            CreateMap<DersAlani, DersAlaniDTO>().ForMember(des => des.id, opt => opt.MapFrom(src => src.Id)).ForMember(des => des.ad, opt => opt.MapFrom(src => src.Ad));
            CreateMap<IlceDTO, Ilce>().ForMember(des => des.Id, opt => opt.MapFrom(src => src.id)).ForMember(des => des.Ad, opt => opt.MapFrom(src => src.ad));
            // DersKonusu Mapper
            CreateMap<DersKonusu, DersKonusuDTO>().ForMember(des => des.id, opt => opt.MapFrom(src => src.Id)).ForMember(des => des.ad, opt => opt.MapFrom(src => src.Ad)).ForMember(des => des.dersAlaniId,opt=>opt.MapFrom(src=>src.DersAlaniId));
            CreateMap<DersKonusuDTO, DersKonusu>().ForMember(des => des.Id, opt => opt.MapFrom(src => src.id)).ForMember(des => des.Ad, opt => opt.MapFrom(src => src.ad)).ForMember(des => des.DersAlaniId, opt => opt.MapFrom(src => src.dersAlaniId));
            // Egitmen Mapper
            CreateMap<Egitmen, EgitmenDTO>().ForMember(des => des.id, opt => opt.MapFrom(src => src.Id)).ForMember(des => des.ad, opt => opt.MapFrom(src => src.Ad)).ForMember(des => des.ilceId, opt => opt.MapFrom(src => src.IlceId)).ForMember(des => des.ozgecmis, opt => opt.MapFrom(src => src.Ozgecmis)).ForMember(des => des.telefonNo, opt => opt.MapFrom(src => src.TelefonNo));
            CreateMap<EgitmenDTO, Egitmen>().ForMember(des => des.Id, opt => opt.MapFrom(src => src.id)).ForMember(des => des.Ad, opt => opt.MapFrom(src => src.ad)).ForMember(des => des.IlceId, opt => opt.MapFrom(src => src.ilceId)).ForMember(des => des.Ozgecmis, opt => opt.MapFrom(src => src.ozgecmis)).ForMember(des => des.TelefonNo, opt => opt.MapFrom(src => src.telefonNo));
        }
    }
}
