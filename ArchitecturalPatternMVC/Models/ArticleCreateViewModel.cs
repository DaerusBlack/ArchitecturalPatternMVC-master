using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ArchitecturalPatternMVC.Models
{
    public class ArticleCreateViewModel
    {
        [Required(ErrorMessage ="Boş bırakma!!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Boş bırakma!!")]
        public string Content { get; set; }

        [Display(Name = "Article Picture ")]
        public IFormFile ArticlePicture { get; set; }
    }
}
