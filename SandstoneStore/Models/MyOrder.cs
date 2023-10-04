using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SandstoneStore.Models
{
    public class MyOrder
    {
        [BindNever]
        public int Id { get; set; }
        [BindNever]
        public ICollection<CartLine> CartLines { get; set; } = new List<CartLine>();
        [Required(ErrorMessage = "This field is required. Please enter your name and last name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required. Please enter your address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "This field is required. Please enter your City")]
        public string City { get; set; }
        [Required(ErrorMessage = "This field is required. Please enter your postal code")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "This field is required. Please enter your Country")]
        public string Country { get; set; }


    }
}
