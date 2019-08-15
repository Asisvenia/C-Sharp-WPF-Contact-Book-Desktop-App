using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Contact_Book.Models
{
    public class Contact : ObservableObject
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { OnPropertyChanged(ref _name, value); }
        }

        private string _imagePath;
        public string ImagePath
        {
            get { return _imagePath; }
            set { OnPropertyChanged(ref _imagePath, value); }
        }

        private string[] _phoneNumbers;
        public string[] PhoneNumbers
        {
            get { return _phoneNumbers; }
            set { OnPropertyChanged(ref _phoneNumbers, value); }
        }
        private int underscoreIndex;
        private int underscoreNumber = 0;
        private string _mail;
        public string Mail
        {
            get
            {
                /// Fixes C# language requirement for the underscore typing. Before this logic, you needed to type 2 underscore
                /// to create only 1 underscore.
                if(_mail != null) {
                    foreach (char c in _mail)
                    {
                        if (c == '_')
                            underscoreNumber++;
                    }
                    if (underscoreNumber == 1)
                    {
                        underscoreIndex = _mail.IndexOf('_');
                        string firstPart = _mail.Substring(0, underscoreIndex);
                        string secondPart = _mail.Substring(underscoreIndex);
                        _mail = firstPart + "_" + secondPart;
                    }
                }
                underscoreNumber = 0;
                return _mail;
            }
            set { OnPropertyChanged(ref _mail, value); }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set { OnPropertyChanged(ref _address, value); }
        }

        private bool _isFavourite;
        public bool IsFavourite
        {
            get { return _isFavourite; }
            set { OnPropertyChanged(ref _isFavourite, value); }
        }
    }
}
