using System;
using AutoMapper;
using TodoApi.Models;
using TodoApi.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Data;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.MappingProfile
{
    public class TodoMapping : Profile
    {
        public TodoMapping()
        {
            CreateMap<UserCreateDto,User > ();

            CreateMap<User, UserReadDto>().ForMember(dto => dto.jobs, t => t.MapFrom(h => h.user_Has_jobs.Select(s => s.job)));


            CreateMap<User, UserUpdateDto>();

            CreateMap<UserUpdateDto, User>();
                                    
            CreateMap<JobUpdateDto, Job>();
            CreateMap<Job, JobUpdateDto>();
            CreateMap<JobCreateDto, Job>();
            
            CreateMap<Job, JobReadDto>().ForMember(dto => dto.owners, t => t.MapFrom(h=>h.user_Has_jobs.Select(u => u.user)));

        }
    }
}
