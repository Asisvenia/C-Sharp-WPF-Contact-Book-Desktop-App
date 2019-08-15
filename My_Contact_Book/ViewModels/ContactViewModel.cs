using Microsoft.Win32;
using My_Contact_Book.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace My_Contact_Book.ViewModels
{
    public class ContactViewModel : ObservableObject
    {
        /// Button commands
        public ICommand BrowseCommand { get; private set; }
        public ICommand UpdateFavouritesCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand CancelEditingCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        private BookViewModel BookVM;

        public ContactViewModel(BookViewModel _bookVM)
        {
            BookVM = _bookVM;
            BrowseCommand = new RelayCommand(GetImagePath);
            UpdateFavouritesCommand = new RelayCommand(UpdateFavourites);
            EditCommand = new RelayCommand(Edit, CanEdit);
            CancelEditingCommand = new RelayCommand(CancelEditing);
            SaveCommand = new RelayCommand(SaveSelectedContact);
            DeleteCommand = new RelayCommand(DeleteSelectedContact, CanEdit);
        }

        private Contact _selectedContact;
        public Contact SelectedContact
        {
            get
            {
                return _selectedContact;
            }
            set
            {
                OnPropertyChanged(ref _selectedContact, value);
            }
        }
        public Contact LastSelectedContact { get; set; }

        private int _lastSelectedValue;
        public int LastSelectedValue
        {
            get
            {
                return _lastSelectedValue;
            }
            set
            {
                OnPropertyChanged(ref _lastSelectedValue, value);
            }
        }
        private bool _isEditMode;
        public bool IsEditMode
        {
            get { return _isEditMode; }
            set
            {
                OnPropertyChanged(ref _isEditMode, value);
                OnPropertyChanged("IsDisplayMode");
            }
        }
        public bool IsDisplayMode
        {
            get
            {
                if (_isEditMode == true)
                    return false;
                else
                    return true;
            }
        }
        private bool CanEdit()
        {
            if (SelectedContact != null)
                return true;

            return false;
        }
        private void Edit()
        {
            LastSelectedContact = BookVM.GetLastItemValues(LastSelectedValue);
            IsEditMode = true;
        }
        private void GetImagePath()
        {
            OpenFileDialog openFileD = new OpenFileDialog();
            openFileD.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            string rootPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location); /// gets the WPF root path
            openFileD.InitialDirectory = rootPath + @"\Resources";
            if (openFileD.ShowDialog() == true)
            {
                SelectedContact.ImagePath = openFileD.FileName;
            }
        }
        private void UpdateFavourites()
        {
            BookVM.UpdateFavourites(SelectedContact);
        }
        private void SaveSelectedContact()
        {
            IsEditMode = false;
            SelectedContact = BookVM.GetLastSelectedItem(LastSelectedValue); /// updates the selected contact by using its last index
        }
        private void CancelEditing()
        {
            BookVM.ReplaceContactDataWithOld(SelectedContact, LastSelectedContact);
            SelectedContact = LastSelectedContact;
            IsEditMode = false;
        }
        private void DeleteSelectedContact()
        {
            BookVM.DeleteContactFromCollection(SelectedContact);
        }
    }
}
