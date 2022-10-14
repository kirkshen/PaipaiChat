using System;

namespace paipaichat.Models
{
	public class NonRefungibleEntry
	{
		public int Id { get; set; } // TEST use random generated
        public string Title { get; set; } //TEST use fix string
		public string CreatorUserName { set ; get; } //TEST use generated string
		public string CreatorAvatarUrl { set; get; } //TEST use generated url link
		public double Price { set; get; } // TEST use fix value
		public int Collected { set; get; }//TEST use fix value
		public string PreviewUrl { set; get; }//TEST use fixed url links
    }
}

