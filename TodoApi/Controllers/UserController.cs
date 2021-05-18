using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Data;
using TodoApi.Dto;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepo _repo;
        private readonly IMapper _mapper;

        public UserController(IUserRepo repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        // GET: api/values
        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _repo.GetUserById(id);
            if (user == null) { return NotFound(); }

            return Ok(_mapper.Map<UserReadDto>(user));
        }

        // GET api/values/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var result = await _repo.GetAllUsers();
            return  Ok(_mapper.Map<IEnumerable<UserReadDto>>(result));
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] UserCreateDto userCreateDto)
        {
             var user =  _mapper.Map<User>(userCreateDto);
            
            _repo.CreateUser(user);

            await _repo.SaveChanges();

            var messageDto = _mapper.Map<UserReadDto>(user);
            return CreatedAtRoute(nameof(GetUserById), new { Id = messageDto.Id }, messageDto);
        }

        /*[HttpPost("addJob/{id}")]
        public async Task<ActionResult<User>> AddJob(int id, [FromBody] JobCreateDto jobCreateDto)
        {
            var job = _mapper.Map<Job>(jobCreateDto);

            _context.jobs.Add(job);

            User jobReceiver = await _repo.GetUserById(id);
            
            if (jobReceiver==null || job==null) {
                return NotFound();
            }

            var user_has_jobs = new User_Has_Job { user = jobReceiver , JobId=job.Id };
            _context.user_Has_jobs.Add(user_has_jobs);
            _context.SaveChanges();
            var messageDto = _mapper.Map<JobReadDto>(job);
            return CreatedAtRoute( new { Id = messageDto.Id }, messageDto);
        }*/
       

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] UserUpdateDto userUpdateDto)
        {
            User userRepo = await _repo.GetUserById(id);

            if (userRepo == null) {
                return NotFound();
            }
            
            //userRepo = _mapper.Map<User>(userUpdateDto);
            _mapper.Map(userUpdateDto, userRepo);
            _repo.UpdateUser(userRepo);

            await _repo.SaveChanges();

            return NoContent();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userRepo = _repo.GetUserById(id);

            if (userRepo == null) {
                return NotFound();
            }

            _repo.DeleteUser(userRepo.Result);
            await _repo.SaveChanges();

            return NoContent();
        }
    }
}
