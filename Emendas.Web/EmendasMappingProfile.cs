using AutoMapper;
using Emendas.Web.ViewModels;
using EmendasModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emendas.Web
{
    public class EmendasMappingProfile:Profile
    {
        public EmendasMappingProfile()
        {
            CreateMap<Parlamentar, ParlamentarViewModel>()
                .ForMember(v=>v.ParlamentarId,ex=>ex.MapFrom(m=>m.Id)).ReverseMap();

            CreateMap<Emenda, EmendaViewModel>().ReverseMap();

            CreateMap<EmendaEmpenho, EmendaEmpenhoViewModel>().ReverseMap();

        }
    }
}
