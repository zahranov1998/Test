  using System.Text.Json;
  
  public class ContactBusiness
    {
        public List<Contact> Contacts {get; set;}

        private readonly string _path = "Resources\\Data.txt";

        private StreamReader _streamReader ;

        private StreamWriter _streamWriter;

        private string _data;


        public ContactBusiness()
        {           

            StreamReader sr = new StreamReader(_path);

            Contacts = new List<Contact>();

            _data = sr.ReadToEnd();

            sr.Dispose();

             if (string.IsNullOrEmpty(_data) == false)
            {
                Contacts = JsonSerializer.Deserialize<List<Contact>>(_data);
            }
        }

        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);

            var strJson = JsonSerializer.Serialize<List<Contact>>(Contacts);

            StreamWriter streamWriter = new StreamWriter(_path, false);
 
            streamWriter.WriteLine(strJson);

            streamWriter.Dispose();

            Console.WriteLine("Contact Added Successfully");

        }

        public void DeleteContact(int id)
        {
            _streamReader = new StreamReader(_path);

            _data = _streamReader.ReadToEnd();

            _streamReader.Dispose();

            if (string.IsNullOrEmpty(_data) == false)
            {
                Contacts = JsonSerializer.Deserialize<List<Contact>>(_data);
            }

            Contacts.Remove(Contacts[id]);

            var strJson = JsonSerializer.Serialize<IList<Contact>>(Contacts);

            _streamWriter = new StreamWriter(_path, false);

            _streamWriter.WriteLine(strJson);

            _streamWriter.Dispose();
        }

        public void ShowContact()
        {
             _streamReader = new StreamReader(_path);

             _data = _streamReader.ReadToEnd();

             _streamReader.Dispose();

             Console.WriteLine(_data);
        }

        public void UpdateContact(int id , Contact contact)
        {

            if(contact.FirstName != "")
                 Contacts[id].FirstName = contact.FirstName;

            if(contact.LastName != "")
                 Contacts[id].LastName = contact.LastName;

            if(contact.PhoneNumber != "")
                 Contacts[id].PhoneNumber = contact.LastName;

            var strJson = JsonSerializer.Serialize<IList<Contact>>(Contacts);

            _streamWriter = new StreamWriter(_path, false);

            _streamWriter.WriteLine(strJson);

            _streamWriter.Dispose();
        }
    }