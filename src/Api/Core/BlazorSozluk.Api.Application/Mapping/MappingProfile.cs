﻿using AutoMapper;
using BlazorSozluk.Api.Domain.Models;
using BlazorSozluk.Common.ViewModels.Queries;
using BlazorSozluk.Common.ViewModels.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, LoginUserViewModel>().ReverseMap();
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<Entry, CreateEntryCommand>().ReverseMap();
            CreateMap<EntryComment, CreateEntryCommentCommand>().ReverseMap();
            CreateMap<Entry, GetEntriesViewModel>().ForMember(x=>x.CommentCount,y=>y.MapFrom(z=>z.EntryComments.Count)).ReverseMap();

        }
    }
}
