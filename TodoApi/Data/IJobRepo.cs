using System;
using System.Collections.Generic;
using TodoApi.Models;
using System.Threading.Tasks;

namespace TodoApi.Data
{
    public interface IJobRepo
    {
        bool SaveChanges();
        IEnumerable<Job> GetAllJobs();
        Job GetJobById(int id);
        void CreateJob(Job job);
        void DeleteJob(Job job);
        void UpdateJob(Job job);

    }
}
