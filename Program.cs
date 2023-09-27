using System.Security.Cryptography.X509Certificates;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Contact u1 = new Contact { FirstName = "Zahra", LastName = "Mohammadi", PhoneNumber = "12345678" };
            Contact u2 = new Contact { FirstName = "Elham", LastName = "aaaaa", PhoneNumber = "12345678" };
            Contact u3 = new Contact { FirstName = "Ali", LastName = "Milani", PhoneNumber = "12345678" };

            var contactBusiness = new ContactBusiness();

            contactBusiness.AddContact(u1);

            contactBusiness.AddContact(u2);

            contactBusiness.AddContact(u3);

            var exit = "";

            while (exit.ToLower() != "e")
            {

                Console.WriteLine("Select The Oparation : \n 1.Add Contact \n 2.Show Contacts \n 3.Delete Contact \n 4.Update Contact");

                var a = 0;
                try
                {
                    a = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid data!");
                    return;
                }

                switch (a)
                {
                    case 1:

                        Contact contact = new Contact();

                        Console.WriteLine("Enter FirstName");
                        contact.FirstName = Console.ReadLine();

                        Console.WriteLine("Enter LastName");
                        contact.LastName = Console.ReadLine();

                        Console.WriteLine("Enter PhoneNumber");
                        contact.PhoneNumber = Console.ReadLine();

                        contactBusiness.AddContact(contact);

                        Console.WriteLine("Contact Added Successfully");

                        break;

                    case 2:

                        foreach (Contact item in contactBusiness.Contacts)
                        {
                            Console.WriteLine(item.FirstName);
                            Console.WriteLine(item.LastName);
                            Console.WriteLine(item.PhoneNumber);
                            Console.WriteLine("");
                        }

                        break;

                    case 3:

                        Console.WriteLine("Enter ContactId");

                        var uId = Convert.ToInt32(Console.ReadLine());

                        try
                        {
                            contactBusiness.DeleteContact(uId);

                            Console.WriteLine("Contact Deleted Successfully");
                        }
                        catch
                        {
                            Console.WriteLine("Error ! Couldn't Delete");
                        }

                        break;

                    case 4:

                        Console.WriteLine("Enter ContactId");

                        try
                        {
                            uId = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter FirstName");

                            var value = Console.ReadLine();

                            if(value != "")
                            contactBusiness.Contacts[uId].FirstName = value;


                            Console.WriteLine("Enter LastName");

                            value = Console.ReadLine();

                            if(value != "")
                            contactBusiness.Contacts[uId].LastName = value;

                            Console.WriteLine("Enter PhoneNumber");

                            value = Console.ReadLine();

                            if(value != "")
                            contactBusiness.Contacts[uId].PhoneNumber = value;

                            Console.WriteLine("Contact Updated Successfully");
                        }
                        catch
                        {
                            Console.WriteLine("Error! Couldn't Update");
                        }

                        break;

                    default:

                        Console.WriteLine("Invalid Operation");

                        break;
                }

                Console.WriteLine("For Exit Press 'E'");

                exit = Console.ReadLine();
            }
        }
    }
}