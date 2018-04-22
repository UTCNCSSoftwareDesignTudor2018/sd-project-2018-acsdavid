using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BikePortal.Business.Entity;
using BikePortalWebApp.Models;

namespace BikePortalWebApp.Mappers
{
    public class BikePortalMapper
    {
        private static readonly MapperConfiguration Configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Bike, BikeDto>();
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Comment, CommentDto>();
                cfg.CreateMap<CommentFormDto, Comment>()
                    .ForMember(
                        c => c.Date,
                        cfdto => cfdto.MapFrom(_ => DateTime.Now)
                    );
            });

        public static  IMapper Create()
        {
            return Configuration.CreateMapper();
        }
    }
}