using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom_Shopper.App.Dto
{
    public class CreateProductDto
    {
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
