﻿using AutoMapper;
using Web.App.Database.DbSet;
using Web.App.Entity.Dto;
using Web.App.Entity.Response;

namespace Web.App.Database.Mapping.Profile
{
    public class ReservationMappingProfile : AutoMapper.Profile
    {
        public ReservationMappingProfile()
        {
            CreateMap<Reservation, GetReservationResponse>()
                .ForMember(dest => dest.ReservationId, opt => opt.MapFrom(source => source.Id));

            CreateMap<CreateReservationCommandDto, Reservation>();

            CreateMap<Reservation, CreateReservationCommandResponse>()
                .ForMember(dest => dest.ReservationId, opt => opt.MapFrom(source => source.Id));
        }
    }
}
