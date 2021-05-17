using System;
using AutoMapper;
using TodoApi.Models;
using TodoApi.Dto;

namespace TodoApi.MappingProfile
{
    public class TodoMapping : Profile
    {
        public TodoMapping()
        {
            CreateMap<UserCreateDto,User > ();
            CreateMap<User, UserReadDto>();
            CreateMap<User, UserUpdateDto>();
            CreateMap<UserUpdateDto, User>();

            CreateMap<JobUpdateDto, Job>();
            CreateMap<Job, JobUpdateDto>();
            CreateMap<JobCreateDto, Job>();
            CreateMap<Job, JobReadDto>();
        }
    }
}
