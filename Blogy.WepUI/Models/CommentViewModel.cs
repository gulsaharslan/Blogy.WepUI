namespace Blogy.WepUI.Models
{
	public class CommentViewModel
	{
	
		public int AppUserId { get; set; }
		public string Content { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
		public int ArticleId { get; set; }
	
	}
}
