using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace startup.Models
{
	[Table("view_Post_Menu")]
	public class View_Post_Menu
	{
		[Key]
		public long PostID { get; set; }
		public string? Title { get; set; }
		public string? Abstract { get; set; }
		public string? Contents { get; set; }
		public string? Images { get; set; }
		public string? Link { get; set; }
		public string? Author { get; set;}
		public DateTime CreatedDate { get; set; }
		public bool? IsActive { get; set; }
		public int PostOrder {  get; set; }
		public int MenuID { get; set; }
		public int Category { get; set; }
		public int Status { get; set; }
		public string? MenuName { get; set; }
	}
}