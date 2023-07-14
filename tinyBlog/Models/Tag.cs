using System.ComponentModel.DataAnnotations;

namespace tinyBlog.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }   
        public string Name  { get; set; }   
        public List<Post> Posts { get; set; } = new();
		public List<PostTag> PostTags { get; } = new();
	}
}
