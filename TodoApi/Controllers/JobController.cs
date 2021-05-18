using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Data;
using TodoApi.Dto;
using AutoMapper;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : Controller
    {
        private readonly IJobRepo _repo;
        private readonly IMapper _mapper;

        public JobController(IJobRepo repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
 
        }

        // GET: api/values
        [HttpGet("{id}", Name = "GetJobById")]
        public async Task<ActionResult<Job>> GetJobById(int id)
        {
            var job =  await _repo.GetJobById(id);
            if (job == null) {
                return NotFound();
            }

            return Ok(_mapper.Map<JobReadDto>(job));
        }

        // GET api/values/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> GetAllJobs()
        {
            var result = await _repo.GetAllJobs();
            return Ok(_mapper.Map<IEnumerable<JobReadDto>>(result));
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Job>> CreateJob([FromBody] JobCreateDto jobCreateDto)
        {
            var job = _mapper.Map<Job>(jobCreateDto);

            _repo.CreateJob(job);

            await _repo.SaveChanges();

            var messageDto = _mapper.Map<JobReadDto>(job);
            return CreatedAtRoute(nameof(GetJobById), new { Id = messageDto.Id }, messageDto);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public  async Task<ActionResult> UpdateJob(int id, [FromBody] JobUpdateDto jobUpdateDto)
        {
            var jobRepo = await _repo.GetJobById(id);

            if (jobRepo == null)
            {
                return NotFound();
            }

            //userRepo = _mapper.Map<User>(userUpdateDto);
            _mapper.Map(jobUpdateDto, jobRepo);
            _repo.UpdateJob(jobRepo);

            await _repo.SaveChanges();

            return NoContent();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var jobRepo = _repo.GetJobById(id);

            if (jobRepo == null)
            {
                return NotFound();
            }

            _repo.DeleteJob(jobRepo.Result);
             await _repo.SaveChanges();

            return NoContent();
        }
    }
}
