using My_Contact_Book.Models;
using My_Contact_Book.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;

namespace My_Contact_Book.ViewModels
{
    public class BookViewModel : ObservableObject
    {
        /// Data service
        JsonContactDataService dataService;

        private ObservableCollection<Contact> _currentContactData;
        public ObservableCollection<Contact> CurrentContactData
        {
            get { return _currentContactData; }
            set { OnPropertyChanged(ref _currentContactData, value); }
        }
        private ObservableCollection<Contact> _allContactData;
        public ObservableCollection<Contact> AllContactData
        {
            get { return _allContactData; }
            set { OnPropertyChanged(ref _allContactData, value); }
        }
        private ObservableCollection<Contact> _contactData;
        public ObservableCollection<Contact> ContactData
        {
            get { return _contactData; }
            set { OnPropertyChanged(ref _contactData, value); }
        }
        private ObservableCollection<Contact> _favContactData;
        public ObservableCollection<Contact> FavContactData
        {
            get { return _favContactData; }
            set { OnPropertyChanged(ref _favContactData, value); }
        }

       private DeletePopupWindow delPopWin;

        public Contact ItemNeedsToBeDeleted;

        /// Button commands
        public ICommand ContactsCommand { get; private set; }
        public ICommand FavouritesCommand { get; private set; }
        public ICommand DeleteApprove { get; private set; }
        public ICommand DeleteCancel { get; private set; }
        public ICommand AddCommand { get; private set; }

        public ContactViewModel ContactVM { get; set; }
        private int lastViewHolder = 1; /// 0 means = you're on "Favourites" section, 1 means you're on "Contacts" section

        public BookViewModel()
        {
            dataService = new JsonContactDataService();
            ContactVM = new ContactViewModel(this);
            AllContactData = dataService.GetData().ToObservableCollection();

            FavContactData = AllContactData.Where(x => x.IsFavourite == true).ToObservableCollection();
            ContactData = AllContactData.Where(x => x.IsFavourite == false).ToObservableCollection();
            CurrentContactData = ContactData;
            ContactsCommand = new RelayCommand(LoadContacts);
            FavouritesCommand = new RelayCommand(LoadFavourites);
            DeleteApprove = new RelayCommand(ApprovingDelete);
            DeleteCancel = new RelayCommand(QuitDeleting);
            AddCommand = new RelayCommand(AddNewContact);
        }
        private void LoadContacts()
        {
            ContactData = AllContactData.Where(x => x.IsFavourite == false).ToObservableCollection();
            CurrentContactData = ContactData;
            lastViewHolder = 1;
        }
        private void LoadFavourites()
        {
            FavContactData = AllContactData.Where(x => x.IsFavourite == true).ToObservableCollection();
            CurrentContactData = FavContactData;
            lastViewHolder = 0;
        }
        private void LoadLastLoadedSection()
        {
            if (lastViewHolder == 0)
                LoadFavourites();
            else
                LoadContacts();
        }
        public void UpdateFavourites(Contact selectedContact)
        {
            foreach (Contact item in AllContactData)
            {
                if (item == selectedContact)
                {
                    AllContactData.Remove(item);
                    AllContactData.Add(selectedContact);
                    LoadLastLoadedSection();

                    break;
                }
            }
            dataService.SaveData(AllContactData); /// saves data to the hard drive
        }
        public void ReplaceContactDataWithOld(Contact selectedContact, Contact lastContact)
        {
            int count = 0;
            foreach (Contact item in AllContactData)
            {
                if (item == selectedContact)
                {
                    AllContactData[count] = lastContact;

                    break;
                }
                count++;
            }
            LoadLastLoadedSection();
        }
        public Contact GetLastSelectedItem(int lastIndex)
        {
            dataService.SaveData(AllContactData); /// saves data to the hard drive
            return CurrentContactData[lastIndex];
        }
        public Contact GetLastItemValues(int selectedIndex)
        {
            Contact currentData = CurrentContactData[selectedIndex];
            return new Contact
            {
                Name = currentData.Name,
                ImagePath = currentData.ImagePath,
                PhoneNumbers = new string[2]
                {
                    currentData.PhoneNumbers[0],
                    currentData.PhoneNumbers[1]
                },
                Mail = currentData.Mail,
                Address = currentData.Address,
                IsFavourite = currentData.IsFavourite
            };
        }
        public void DeleteContactFromCollection(Contact selectedContact)
        {
            ItemNeedsToBeDeleted = selectedContact;

            delPopWin = new DeletePopupWindow();
            delPopWin.DataContext = this;
            delPopWin.Show();
        }
        private void ApprovingDelete()
        {
            AllContactData.Remove(ItemNeedsToBeDeleted);
            LoadLastLoadedSection();

            if (delPopWin != null)
                delPopWin.Close();

            dataService.SaveData(AllContactData); /// saves data to the hard drive
        }
        private void QuitDeleting()
        {
            if (delPopWin != null)
                delPopWin.Close();
        }
        private void AddNewContact()
        {
           Contact newContact = new Contact
            {
                Name = null,
                ImagePath = null,
                PhoneNumbers = new string[2]
                {
                    null,
                    null
                },
                Mail = null,
                Address = null,
                IsFavourite = false
            };
            AllContactData.Add(newContact);
            LoadLastLoadedSection();
            dataService.SaveData(AllContactData); /// saves data to the hard drive
        }
    }

    public static class LinqExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> _LinqResult)
        {
            return new ObservableCollection<T>(_LinqResult);
        }
    }
}
