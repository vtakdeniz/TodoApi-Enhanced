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

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserJobController : Controller
    {
        TodoApiContext _context;
        private readonly IMapper _mapper;

        public UserJobController(TodoApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<UserReadDto>> AddJobToUser([FromBody] AddJobToUserDto addJobToUserDto)
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

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> AddJobToUser(int id) { 

            User userFromRepo = await _context.users.Include(u => u.user_Has_jobs).ThenInclude(s => s.job).FirstOrDefaultAsync(u => u.Id == id);
            return Ok(User);

        }

    }
}
