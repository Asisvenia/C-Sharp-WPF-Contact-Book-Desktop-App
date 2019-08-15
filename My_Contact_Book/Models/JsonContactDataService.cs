using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Contact_Book.Models
{
    public class JsonContactDataService
    {
        private readonly string dataPath = @"Resources\SavedData\contactData.json";

        public IEnumerable<Contact> GetData()
        {
            if (!File.Exists(dataPath))
            {
                File.Create(dataPath).Close();
            }
            var serializedContacts = File.ReadAllText(dataPath);
            var deserializedContacts = JsonConvert.DeserializeObject<IEnumerable<Contact>>(serializedContacts);

            if (deserializedContacts == null)
                return new List<Contact>();

            return deserializedContacts;
        }

        public void SaveData(IEnumerable<Contact> contacts)
        {
            var serializedContacts = JsonConvert.SerializeObject(contacts);
            File.WriteAllText(dataPath, serializedContacts);
        }

    }
}
