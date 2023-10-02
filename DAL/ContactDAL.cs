using System.Text.Json;

namespace Sample.DAL
{
    public class ContactDAL
    {
        public List<Contact> Contacts { get; set; }

        private readonly string _path = Directory.GetCurrentDirectory() + "\\Data.txt";

        private StreamReader _streamReader;

        private StreamWriter _streamWriter;

        private string _data;

        public ContactDAL(string path)
        {
            _path = path;

            SetData();
        }

        public ContactDAL()
        {
            SetData();
        }

        public void SetData()
        {
            if (File.Exists(_path) == false)
            {
                File.Create(_path).Dispose();
            }

            StreamReader sr = new StreamReader(_path);

            Contacts = new List<Contact>();

            _data = sr.ReadToEnd();

            sr.Dispose();

            if (string.IsNullOrEmpty(_data) == false)
            {
                Contacts = JsonSerializer.Deserialize<List<Contact>>(_data);
            }
        }

        public void Insert(Contact contact)
        {
            Contacts.Add(contact);

            var strJson = JsonSerializer.Serialize<List<Contact>>(Contacts);

            StreamWriter streamWriter = new StreamWriter(_path, false);

            streamWriter.WriteLine(strJson);

            streamWriter.Dispose();
        }

        public void Update(int id, Contact contact)
        {
            var strJson = JsonSerializer.Serialize<List<Contact>>(Contacts);

            _streamWriter = new StreamWriter(_path, false);

            _streamWriter.WriteLine(strJson);

            _streamWriter.Dispose();
        }

        public void Delete(int id)
        {

            _streamReader = new StreamReader(_path);

            _data = _streamReader.ReadToEnd();

            _streamReader.Dispose();

            if (string.IsNullOrEmpty(_data) == false)
            {
                Contacts = JsonSerializer.Deserialize<List<Contact>>(_data);
            }

            Contacts.Remove(Contacts[id]);

            var strJson = JsonSerializer.Serialize<List<Contact>>(Contacts);

            _streamWriter = new StreamWriter(_path, false);

            _streamWriter.WriteLine(strJson);

            _streamWriter.Dispose();
        }

        public void Select()
        {
            _streamReader = new StreamReader(_path);

            _data = _streamReader.ReadToEnd();

            _streamReader.Dispose();

            Console.WriteLine(_data);
        }
    }
}