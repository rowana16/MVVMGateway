﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMLearningData
{
    public class TrainingProduct
    {

        public int ProductId { get; set; }
        [Required(ErrorMessage="Product Name must be filled in.")]
        [Display(Description ="Product Name")]
        [StringLength(150, MinimumLength=4, ErrorMessage ="Product Name must be greater than {2} characters and less than {1} characters")]
        public string ProductName { get; set; }
        [Range(typeof(DateTime),"1/1/2000", "12/31/2020", ErrorMessage ="Introduction Date must be between {1} and {2}")]
        public DateTime  IntroductionDate { get; set; }
        public string Url { get; set; }
        [Range(1, 9999, ErrorMessage ="{0} must be between {1} and {2}")]
        public decimal Price { get; set; }
    }
}
