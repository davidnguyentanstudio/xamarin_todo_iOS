using System;
using UIKit;
namespace ToDo_iOS.Models
{
    public enum Status
    {
        InProgress = 0,
        Completed
    }

	public static class StatusExtension
	{
        public static UIImage GetImage(this Status status)
		{
			switch (status)
			{
				case Status.Completed:
                    return UIImage.FromBundle("CheckIcon");
				default:
					return null;
			}
		}
	}
}
