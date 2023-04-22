﻿using AutoMapper;
using WalletAppBackend.Models.Api;
using WalletAppBackend.Models.Database;

namespace WalletAppBackend.Configurations.Services
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Transaction, TransactionApi>()
                .ForMember(dest => dest.EncodedIconData,
                           source => source.MapFrom(entity => entity.Icon.Data))
                .ForMember(dest => dest.AuthorizedUserName,
                           source => source.MapFrom(entity => $"{entity.AuthorizedUser.FirstName} {entity.AuthorizedUser.LastName}"))
                .ForMember(dest => dest.Status,
                           source => source.MapFrom(entity => entity.Status.Title))
                .ForMember(dest => dest.Type,
                           source => source.MapFrom(entity => entity.Type.Title));

            CreateMap<CreateTransactionApi, Transaction>();
        }
    }
}
