using System.ComponentModel.DataAnnotations;

namespace tinyBlog.Models
{
    public enum PostType
    {
        [Display(Name = "ShortPost")]
        SHORT,
        [Display(Name = "LongPost")]
        LONG
    }
}
