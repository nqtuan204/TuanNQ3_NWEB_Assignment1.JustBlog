using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JustBlog.Core.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Url slug name must be required")]
        [StringLength(255, ErrorMessage = "Url slug must be shorter than 255 characters")]
        public string UrlSlug { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
