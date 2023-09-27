  public class ContactBusiness
    {
        public List<Contact> Contacts {get; set;}

        public ContactBusiness()
        {
            Contacts = new List<Contact>();
        }

        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
        }

        public void DeleteContact(int id)
        {
            Contacts.Remove(Contacts[id]);
        }

        public void ShowContact()
        {
            foreach(Contact contact in Contacts)
            {
                Console.WriteLine(contact.FirstName);
                Console.WriteLine(contact.LastName);
                Console.WriteLine(contact.PhoneNumber);
            }
        }

        public void UpdateContact(int id , Contact contact)
        {
           Contacts[id] = contact ;
        }
    }