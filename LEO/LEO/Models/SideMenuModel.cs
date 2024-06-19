using System;
namespace LEO.Models
{
	public class SideMenuModel
	{
		public int Id { get; set; }

		public string Title { get; set; }

        public Type TargetType { get; set; }

		public Action Action { get; set; }
    }
}