using System;
using AutoMapper;
using TodoApi.Models;
using TodoApi.Dto;
using System.Collections.Generic;
using System.Linq;
using TodoApi.ViewModels;

namespace TodoApi.MappingProfile
{
    public class TodoMapping : Profile
    {
        public TodoMapping()
        {
            CreateMap<UserCreateDto,User > ();

            CreateMap<User, UserReadDto>();

            CreateMap<User, UserHasJobVm>().ForMember(dto => dto.jobs, t => t.MapFrom(h => h.user_Has_jobs.Select(s => s.job)));

            CreateMap<User, UserUpdateDto>();

            CreateMap<UserUpdateDto, User>();
                                    
            CreateMap<JobUpdateDto, Job>();
            CreateMap<Job, JobUpdateDto>();
            CreateMap<JobCreateDto, Job>();
            CreateMap<Job, JobReadDto>();

            CreateMap<Job, JobHasUserVm>().ForMember(dto => dto.owners, t => t.MapFrom(h => h.user_Has_jobs.Select(u => u.user)));

        }
    }
}
