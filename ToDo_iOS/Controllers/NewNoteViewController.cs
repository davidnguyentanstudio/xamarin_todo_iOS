using Foundation;
using System;
using UIKit;
using ToDo_iOS.Models;

namespace ToDo_iOS
{
    public partial class NewNoteViewController : UIViewController
    {
        Note _note;
        public Note Note
        {
            get => _note;
            set => _note = value;
        }

        UIBarButtonItem _saveRightBarButton;
        public UIBarButtonItem SaveRightBarButton
        {
            get => _saveRightBarButton;
            set => _saveRightBarButton = value;
        }

        NewNoteHandler _noteAddedHandler;
        public NewNoteHandler NoteAddedHandler { get => _noteAddedHandler; set => _noteAddedHandler = value; }

        public NewNoteViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.PrepareSaveRightBarButton(this.Note);
            this.PrepareNoteTextField(this.Note);
        }

        // Private methods

        void PrepareNoteTextField(Note note)
        {
            string noteContent = note == null ? "" : note.Content;
            this.NoteTextField.Text = noteContent;
            this.NoteTextField.BecomeFirstResponder();
            this.NoteTextField.AddTarget(this.HandleNoteTextFieldTextChanged, UIControlEvent.EditingChanged);
        }

        void PrepareSaveRightBarButton(Note note)
        {
            this.SaveRightBarButton = new UIBarButtonItem(UIBarButtonSystemItem.Save, (sender, e) =>
            {
                Note editedNote = this.GetNote(this.NoteTextField.Text, this.Note);
                if (this.NoteAddedHandler != null)
                {
                    this.NoteAddedHandler(editedNote);
                }
                this.NavigationController.PopViewController(true);
            });
            this.NavigationItem.RightBarButtonItem = this.SaveRightBarButton;


            string noteContent = note == null ? String.Empty : note.Content;
            bool isEmptyNote = noteContent.Equals(String.Empty);
            this.SaveRightBarButton.Enabled = !isEmptyNote;
        }

        Note GetNote(string noteContent, Note currentNote)
        {
            Note note = currentNote ?? new Note(Guid.NewGuid().ToString(),
                                                noteContent,
                                                Status.InProgress,
                                                DateTime.Now,
                                                DateTime.Now);
            note.Content = noteContent;
            note.UpdatedAt = DateTime.Now;

            return note;
        }

        void HandleNoteTextFieldTextChanged(object sender, EventArgs e)
        {
            bool isEmptyNote = this.NoteTextField.Text.Equals(String.Empty);
            this.SaveRightBarButton.Enabled = !isEmptyNote;
        }
    }
}