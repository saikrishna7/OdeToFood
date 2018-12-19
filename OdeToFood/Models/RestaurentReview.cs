using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public class RestaurentReview
    {        
        public int Id { get; set; }

        [Range(1, 10)]
        [Required]
        public int Rating { get; set; }

        [Required]
        [StringLength(2014)]
        public string Body { get; set; }

        [Display(Name ="User Name")]
        [DisplayFormat(NullDisplayText ="Anonymous")]
        public int RestaurentId { get; set; }
        public string ReviewerName { get; set; }
    }
}