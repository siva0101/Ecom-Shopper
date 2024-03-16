using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom_Shopper.Domain.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        
        public string ProductName { get; set; }
       
        public string ProductCategory { get; set; }

        public string ProductImage { get; set; }

        public string ImageFilePath { get; set; }
     
        public double ProductNewPrice { get; set; }
        
        public double ProductOldPrice { get; set; }
        [NotMapped]
        public List<IFormFile> files { get; set; } = new List<IFormFile>();

    }
}
