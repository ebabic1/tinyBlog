﻿using System.ComponentModel.DataAnnotations;

namespace tinyBlog.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }   
        public string Name  { get; set; }   

    }
}
