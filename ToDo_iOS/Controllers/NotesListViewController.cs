using Foundation;
using System;
using UIKit;
using ToDo_iOS.Views;
using ToDo_iOS.Models;
using System.Collections.Generic;

namespace ToDo_iOS
{
    public partial class NotesListViewController : UIViewController
    {
        List<Note> _notes;
        public List<Note> Notes
        {
            get => _notes;
            set => _notes = value;
        }

        public NotesListViewController(IntPtr handle) : base(handle)
        {
            Notes = new List<Note>();
            Notes.Add(new Note(Guid.NewGuid().ToString(),
                                                "1. Lorem ipsum dolor sit amet",
                                                Status.InProgress,
                                                DateTime.Now,
                                                DateTime.Now));
            Notes.Add(new Note(Guid.NewGuid().ToString(),
                                                "2. Lorem ipsum dolor sit amet",
                                                Status.InProgress,
                                                DateTime.Now,
                                                DateTime.Now));
            Notes.Add(new Note(Guid.NewGuid().ToString(),
                                                "3. Lorem ipsum dolor sit amet",
                                                Status.InProgress,
                                                DateTime.Now,
                                                DateTime.Now));
            Notes.Add(new Note(Guid.NewGuid().ToString(),
                                                "4. Lorem ipsum dolor sit amet",
                                                Status.InProgress,
                                                DateTime.Now,
                                                DateTime.Now));
            Notes.Add(new Note(Guid.NewGuid().ToString(),
                                                "5. Lorem ipsum dolor sit amet",
                                                Status.InProgress,
                                                DateTime.Now,
                                                DateTime.Now));
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.PrepareNotesListTableView();
            this.PrepareAddRightBarButton();
        }

        // Private methods

        void PrepareNotesListTableView()
        {
            this.NotesListTableView.RegisterNibForCellReuse(NoteTableViewCell.Nib, NoteTableViewCell.Key);
            this.NotesListTableView.Source = new NotesListDataSource(this);
            this.NotesListTableView.RowHeight = UITableView.AutomaticDimension;
            this.NotesListTableView.EstimatedRowHeight = 500;
        }

        void PrepareAddRightBarButton()
        {
            var addRightBarButton = new UIBarButtonItem(UIBarButtonSystemItem.Add, (sender, e) =>
            {
                this.PushToNewNoteViewController(null);
            });
            this.NavigationItem.RightBarButtonItem = addRightBarButton;
        }

        void HandleNewNoteAdded(Note note)
        {
            int editedIndex = this.Notes.FindIndex(x => x == note);
            bool isNewNote = editedIndex == -1;
            if (isNewNote)
            {
                this.Notes.Insert(0, note);
                NSIndexPath[] indexPaths = { NSIndexPath.FromRowSection(0, 0) };
                this.NotesListTableView.InsertRows(indexPaths, UITableViewRowAnimation.Automatic);
            }
            else
            {
                this.Notes[editedIndex] = note;
                NSIndexPath[] indexPaths = { NSIndexPath.FromRowSection(editedIndex, 0) };
                this.NotesListTableView.ReloadRows(indexPaths, UITableViewRowAnimation.Automatic);
            }
        }

        public void PushToNewNoteViewController(Note note)
        {
            var mainStoaryboard = UIStoryboard.FromName("Main", null);
            NewNoteViewController newNoteViewController = (NewNoteViewController)mainStoaryboard.InstantiateViewController("NewNoteViewController");
            newNoteViewController.NoteAddedHandler = this.HandleNewNoteAdded;
            newNoteViewController.Note = note;
            this.NavigationController.ShowViewController(newNoteViewController, null);
        }

        public void HandleStatusButtonTapped(Note note, NSIndexPath indexPath)
        {
            Console.WriteLine("index: " + indexPath.Row.ToString() + " - content: " + note.Content);
            note.Status = note.Status == Status.InProgress ? Status.Completed : Status.InProgress;
            NSIndexPath[] indexPaths = { indexPath };
            this.NotesListTableView.ReloadRows(indexPaths, UITableViewRowAnimation.Automatic);
        }
    }

    public delegate void NewNoteHandler(Note note);

    class NotesListDataSource : UITableViewSource
    {
        NotesListViewController notesListViewController;

        public NotesListDataSource(NotesListViewController notesListViewController)
        {
            this.notesListViewController = notesListViewController;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            NoteTableViewCell cell = (NoteTableViewCell)tableView.DequeueReusableCell(NoteTableViewCell.Key, indexPath);
            var note = notesListViewController.Notes[indexPath.Row];
            cell.Render(note.Content, note.Status);
            cell.StatusButtonTapped = delegate
            {
                notesListViewController.HandleStatusButtonTapped(note, indexPath);
            };
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return this.notesListViewController.Notes.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            tableView.DeselectRow(indexPath, true);
            Note note = notesListViewController.Notes[indexPath.Row];
            notesListViewController.PushToNewNoteViewController(note);
        }
    }
}