﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class JobMetadata
    {
        public Guid JobId { get; set; }
        public Type JobType { get; }
        public string JobName { get; }
        public string CronExpression { get; }
        public JobMetadata(Guid Id, Type jobType, string jobName, string cronExpression)
        {
            JobId = Id;
            JobType = jobType;
            JobName = jobName;
            CronExpression = cronExpression;
        }
    }
}
