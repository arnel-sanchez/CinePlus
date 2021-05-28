﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class RegisterModelRequest
    {
        [Required]
        [DataType(DataType.Text)]
        public string role { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string lastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string userName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
