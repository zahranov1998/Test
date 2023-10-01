using Sample.DAL;

public class ContactBusiness
{
    private ContactDAL _contactDAL;

    private List<Contact> _contacts;


    public ContactBusiness(string path)
    {
        _contactDAL = new ContactDAL(path);

     //   _contacts = _contactDAL.Contacts;
    }

    public ContactBusiness()
    {
        _contactDAL = new ContactDAL();

      //  _contacts = _contactDAL.Contacts;
    }

    public void AddContact(Contact contact)
    {

        _contactDAL.Insert(contact);

        Console.WriteLine("Contact Added Successfully");
    }

    public void DeleteContact(int id)
    {
        _contactDAL.Delete(id);

        Console.WriteLine("Contact Deleted Successfully");
    }

    public void ShowContacts()
    {
        _contactDAL.Select();
    }

    public void UpdateContact(int id, Contact contact)
    {
        var contacts = _contactDAL.Contacts;

        var contact1 = contacts[id];

        if (contact.FirstName != "")
            contact1.FirstName = contact.FirstName;

        if (contact.LastName != "")
            contact1.LastName = contact.LastName;

        if (contact.PhoneNumber != "")
            contact1.PhoneNumber = contact.PhoneNumber;

        _contactDAL.Update(id, contact1);

        Console.WriteLine("Contact Updated Successfully");
    }

    public bool ContactExist(int id)
    {
        return _contactDAL.Contacts[id] != null;
    }
}