// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ToDo_iOS
{
    [Register ("NewNoteViewController")]
    partial class NewNoteViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField NoteTextField { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (NoteTextField != null) {
                NoteTextField.Dispose ();
                NoteTextField = null;
            }
        }
    }
}