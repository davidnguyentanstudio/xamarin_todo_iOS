// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace ToDo_iOS.Views
{
    [Register ("NoteTableViewCell")]
    partial class NoteTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ContentLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        public UIKit.UIButton StatusButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ContentLabel != null) {
                ContentLabel.Dispose ();
                ContentLabel = null;
            }

            if (StatusButton != null) {
                StatusButton.Dispose ();
                StatusButton = null;
            }
        }
    }
}