using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JustBlog.Core.Entities
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tag name must be required")]
        [StringLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Url slug name must be required")]
        [StringLength(255)]
        public string UrlSlug { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public ICollection<PostTagMap> PostTagMaps { get; set; }
    }
}
