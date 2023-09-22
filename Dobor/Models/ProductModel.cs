﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dobor.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        public string? Category { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ShortDesc { get; set; }
        public int? OldPrice { get; set; }
        public int? Price { get; set; }
        public string? PhotoPath { get; set; }
    }
}