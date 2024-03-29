﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidley.Dtos;
using Vidley.Models;

namespace Vidley.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDtos>();
            Mapper.CreateMap<CustomerDtos, Customer>();
            Mapper.CreateMap<MemberShipType, MemberSHipTypeDto>();
        }
    }
}