using ENTITIES.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Entity.Concrete
{
    [Table("Articles")]
    public class Article:BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string ArticlePicture { get; set; }

        [Required]
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        public string GetContentSummary()
        {
            int limit = 300;
            string summary = string.Empty;

            if (Content.Length >= limit)
            {
                summary = string.Format("{0}...", Content.Substring(0, limit));
            }
            else
                summary = Content;

            return summary;
        }

        //[ForeignKey("Author")]
        public int AuthorId { get; set; }

        //[Required]
        public User Author { get; set; }

    }
}
