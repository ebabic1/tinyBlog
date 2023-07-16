using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace tinyBlog.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        [EnumDataType(typeof(PostType))]    
        public PostType PostType { get; set; } 
        public string? FeaturedImageUrl { get; set; }   
        public string? UrlHandle { get; set; }
        public string Author { get; set; }  
        public string Title { get; set; }  
        public Boolean Visible { get; set; }
        public long Views { get; set; } = 0;
        public DateTime PublishDate { get; set; }
        public List<Tag> Tags { get; set; } = new();
		public List<PostTag> PostTags { get; set; } = new();
	}
}
