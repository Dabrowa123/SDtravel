﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class ContactModels
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
       
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Comment is required")]
        public string Comment { get; set; }
    }
 }