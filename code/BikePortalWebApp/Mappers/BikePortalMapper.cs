using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BikePortal.Business.Entity;
using BikePortalWebApp.Models;
using BikePortalWebApp.Models.BindingModel;
using BikePortalWebApp.Models.ViewModel;

namespace BikePortalWebApp.Mappers
{
    public class BikePortalMapper
    {
        private static readonly MapperConfiguration Configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Bike, BikeViewModel>();
                cfg.CreateMap<BikeBindingModel, Bike>()
                    .ForMember(
                        b => b.Comments,
                        bbm => bbm.MapFrom(_ => new List<Comment>())
                    );
                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<Comment, CommentViewModel>();
                cfg.CreateMap<CommentBindingModel, Comment>()
                    .ForMember(
                        c => c.Date,
                        cfdto => cfdto.MapFrom(_ => DateTime.Now)
                    );
                cfg.CreateMap<ShoppingCartItem, ShoppingCartItemViewModel>();

                cfg.CreateMap<Order, OrderViewModel>();
                cfg.CreateMap<OrderItem, OrderItemViewModel>();
            });

        public static IMapper Create()
        {
            return Configuration.CreateMapper();
        }
    }
}