using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Data;
using TodoApi.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoApi.ViewModels;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserJobController : Controller
    {
        TodoApiContext _context;
        private readonly IMapper _mapper;
        private readonly IJobRepo _jobRepo;

        public UserJobController(TodoApiContext context, IMapper mapper, IJobRepo jobRepo)
        {
            _context = context;
            _mapper = mapper;
            _jobRepo = jobRepo;
        }

        [HttpPost]
        public async Task<ActionResult<UserReadDto>> AddJobToUserById([FromBody] AddJobToUserDto addJobToUserDto)
        {
            User userFromRepo = await _context.users.Include(u => u.user_Has_jobs).ThenInclude(s => s.job).FirstOrDefaultAsync(u => u.Id == addJobToUserDto.UserId);
            if (userFromRepo == null) {
                return NotFound();
            }

            Job jobFromRepo = await _context.jobs.FirstOrDefaultAsync(j => j.Id == addJobToUserDto.JobId);

            if (jobFromRepo == null) {
                return NotFound();
            }

            User_Has_Job relationFromRepo = await _context.user_Has_jobs.FirstOrDefaultAsync(r => r.JobId == addJobToUserDto.JobId && r.UserId == addJobToUserDto.UserId);

            if (relationFromRepo!=null) {
                return BadRequest();
            }

            User_Has_Job user_Has_Job = new User_Has_Job { user = userFromRepo , job=jobFromRepo};

            await _context.user_Has_jobs.AddAsync(user_Has_Job);
            await _context.SaveChangesAsync();

            var userMessage = _mapper.Map<UserReadDto>(userFromRepo);
            return Ok(userMessage);
        }




        [HttpPost("{id}")]
        public async Task<ActionResult<UserReadDto>> AddJobToUserByObject(int id , [FromBody] JobCreateDto jobCreateDto)
        {
            User userFromRepo = await _context.users.Include(u => u.user_Has_jobs).ThenInclude(s => s.job).FirstOrDefaultAsync(u => u.Id == id);
            if (userFromRepo == null)
            {
                return NotFound();
            }
            if (jobCreateDto==null) {
                return BadRequest();
            }

            Job mappedJob = _mapper.Map<Job>(jobCreateDto);
            await _context.jobs.AddAsync(mappedJob);

            User_Has_Job relation = new User_Has_Job { user = userFromRepo, job=mappedJob};
            await _context.user_Has_jobs.AddAsync(relation);

            await _context.SaveChangesAsync();

            var userMessage = _mapper.Map<UserHasJobVm>(userFromRepo);
            return Ok(userMessage);
        }





        [HttpGet("GetJobs/{id}")]
        public async Task<ActionResult<List<JobReadDto>>> GetJobsOfUser(int id) {

            User userFromRepo = await _context.users.Include(u => u.user_Has_jobs).ThenInclude(s => s.job).FirstOrDefaultAsync(u => u.Id == id);
            if (userFromRepo == null)
            {
                return NotFound();
            }

            UserHasJobVm userReadDto = _mapper.Map<UserHasJobVm>(userFromRepo);

            return Ok(_mapper.Map<IEnumerable<JobReadDto>>(userReadDto.jobs));

        }


        [HttpGet("GetOwners/{id}")]
        public async Task<ActionResult<List<JobReadDto>>> GetOwnerOfJobs(int id)
        {

            Job jobFromRepo= await _context.jobs.Include(u => u.user_Has_jobs).ThenInclude(s => s.user).FirstOrDefaultAsync(u => u.Id == id);
            if (jobFromRepo == null)
            {
                return NotFound();
            }

            JobHasUserVm jobReadDto= _mapper.Map<JobHasUserVm>(jobFromRepo);

            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(jobReadDto.owners));

        }
    }
}
