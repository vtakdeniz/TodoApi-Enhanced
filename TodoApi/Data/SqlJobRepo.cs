using System;
using System.Collections.Generic;
using TodoApi.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Data
{
    public class SqlJobRepo : IJobRepo
    {
        private readonly TodoApiContext _context;

        public SqlJobRepo(TodoApiContext context)
        {
            _context = context;
        }

        public void CreateJob(Job job)
        {
            if (job == null)
            {
                throw new ArgumentNullException();
            }

            _context.jobs.Add(job);
        }

        public void DeleteJob(Job job)
        {
            if (job == null)
            {
                throw new ArgumentNullException(nameof(job));
            }

            _context.jobs.Remove(job);
        }

        public async Task<IEnumerable<Job>> GetAllJobs()
        {
            return await _context.jobs.ToListAsync();
        }

        public async Task<Job> GetJobById(int id)
        {
            var job =  await _context.jobs.FindAsync(id);
            return job;
        }

        public async Task<bool> SaveChanges()
        {
            return  await _context.SaveChangesAsync() >= 0;
        }

        public void UpdateJob(Job job)
        {
            //NOTHING
        }
    }
}
