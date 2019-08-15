using My_Contact_Book.Models;
using My_Contact_Book.ViewModels;
using My_Contact_Book.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Contact_Book
{
    public class AppViewModel : ObservableObject
    {
        private object _currentView;
        public object CurrentView
        {
          get
            {
                return _currentView;
            }
          set
            {
                OnPropertyChanged(ref _currentView, value);
            }
        }
        private object _bookVM;
        public object BookVM
        {
            get
            {
                return _bookVM;
            }
            set
            {
                OnPropertyChanged(ref _bookVM, value);
            }
        }

        public AppViewModel()
        {
            BookVM = new BookViewModel();
            CurrentView = BookVM;
        }
    }
}
