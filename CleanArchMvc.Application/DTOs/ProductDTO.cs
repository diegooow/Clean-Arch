using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entity;

namespace CleanArchMvc.Application.DTOs
{
    public class ProductDTO
    {
        [Required(ErrorMessage = "The name is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; private set; }
        [Required(ErrorMessage = "The name is required")]
        public string Description { get; private set; }
        [Required(ErrorMessage = "The name is required")]
        public decimal Price { get; private set; }
        [Required(ErrorMessage = "The name is required")]
        public int Stock { get; private set; }
        [Required(ErrorMessage = "The name is required")]
        public string Image { get; private set; }
        [Required(ErrorMessage = "The name is required")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "The name is required")]
        public Category Category { get; set; }
    }
}