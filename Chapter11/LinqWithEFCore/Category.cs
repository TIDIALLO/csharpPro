using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // DbContext, DbSet<T>
using System.ComponentModel.DataAnnotations;

namespace Packt.Shared;

    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; } = null!;

        public string? Description { get; set; }
    }
