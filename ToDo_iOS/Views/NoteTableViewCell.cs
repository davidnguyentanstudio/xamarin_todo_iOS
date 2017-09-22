using System;

using Foundation;
using UIKit;
using ToDo_iOS.Models;

namespace ToDo_iOS.Views
{
    public partial class NoteTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("NoteTableViewCell");
        public static readonly UINib Nib;
        public Action StatusButtonTapped { get; set; }

        static NoteTableViewCell()
        {
            Nib = UINib.FromName("NoteTableViewCell", NSBundle.MainBundle);
        }

        protected NoteTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            this.StatusButton.SetTitle(String.Empty, UIControlState.Normal);
            this.StatusButton.ClipsToBounds = true;
            this.StatusButton.Layer.CornerRadius = this.StatusButton.Frame.Width / 2;
            this.StatusButton.Layer.BorderColor = UIColor.LightGray.CGColor;
            this.StatusButton.Layer.BorderWidth = 2;
            this.StatusButton.TouchUpInside += delegate
            {
                if (this.StatusButtonTapped == null) {
                    return;
                }
                this.StatusButtonTapped();
            };
        }

        public void Render(string content, Status status)
        {
            this.StatusButton.SetImage(status.GetImage(), UIControlState.Normal);

            bool isCompletedNote = status.Equals(Status.Completed);
            var contentStringAttributes = new UIStringAttributes
            {
                StrikethroughStyle = isCompletedNote ? NSUnderlineStyle.Single : NSUnderlineStyle.None
            };
            this.ContentLabel.AttributedText = new NSAttributedString(content, contentStringAttributes);
        }
    }
}
