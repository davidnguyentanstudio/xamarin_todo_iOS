using System;
using UIKit;
namespace ToDo_iOS.Models
{
    public enum Tag
    {
        Red = 0,
        Yellow,
        Green,
        Unknown
    }

    public static class TagExtension
    {
        public static UIColor GetColor(this Tag tag)
        {
            switch (tag)
            {
                case Tag.Red:
                    return UIColor.Red;
                case Tag.Yellow:
                    return UIColor.Yellow;
                case Tag.Green:
                    return UIColor.Green;
                default:
                    return UIColor.LightGray;
            }
        }
    }
}
