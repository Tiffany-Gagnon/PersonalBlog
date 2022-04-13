using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.Models
{
    public class Blog
    {
        public int Id { get; set; } /*primary key for each blog object*/
        public string AuthorId { get; set; } /*foriegn key for author (primary key for User Model)*/

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters.", MinimumLength = 2)] //(placeholders: 0 annotation name, 1 max, 2 min)
        public string Name { get; set; } /* name of blog*/

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at most {1} characters.", MinimumLength = 2)] //(placeholders: 0 annotation name, 1 max, 2 min)
        public string Description { get; set; } /* blog description*/

        [DataType(DataType.Date)]//will leave out time in the display of the datetime
        [Display(Name = "Created Date")]//display label
        public DateTime Created { get; set; } //date created

        [DataType(DataType.Date)]//will leave out time in the display of the datetime
        [Display(Name = "Updated Date")]//display label
        public DateTime? Update { get; set; } //date updated (? means this can be a null value)

        [Display(Name = "Blog Image")]
        public byte[] ImageData { get; set; } //byte stream of a physical file

        [Display(Name = "Image Type")]
        public string ContentType { get; set; }//type of image (jpeg, png, etc.)

        [NotMapped]//excludes property from database mapping
        public IFormFile Image { get; set; }//physical file of image user selects
    }
}
