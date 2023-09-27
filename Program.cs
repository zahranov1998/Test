using System.Text.Json;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {

            string f = AppDomain.CurrentDomain.BaseDirectory;

            var path = f + "Files\\Data.json";

            var contactBusiness = new ContactBusiness();

            StreamReader sr = new StreamReader(path);

            var z = sr.ReadToEnd();

            sr.Dispose();

            List<Contact> contacts = new List<Contact>();


            Contact contact = new Contact();

            if (string.IsNullOrEmpty(z) == false)
            {
                contacts = JsonSerializer.Deserialize<List<Contact>>(z);
            }

            contactBusiness.Contacts = contacts;

            var opt = new JsonSerializerOptions() { WriteIndented = true };

            var strJson = JsonSerializer.Serialize<List<Contact>>(contactBusiness.Contacts, opt);

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

                        Console.WriteLine("Enter FirstName");
                        contact.FirstName = Console.ReadLine();

                        Console.WriteLine("Enter LastName");
                        contact.LastName = Console.ReadLine();

                        Console.WriteLine("Enter PhoneNumber");
                        contact.PhoneNumber = Console.ReadLine();

                        contacts.Add(contact);

                        strJson = JsonSerializer.Serialize<IList<Contact>>(contacts, opt);


                        StreamWriter streamWriter = new StreamWriter(path, false);

                        streamWriter.WriteLine(strJson);

                        streamWriter.Dispose();

                        Console.WriteLine("Contact Added Successfully");

                        break;

                    case 2:

                        sr = new StreamReader(path);

                        z = sr.ReadToEnd();

                        sr.Dispose();

                        Console.WriteLine(z);

                        break;

                    case 3:

                        sr = new StreamReader(path);

                        z = sr.ReadToEnd();

                        sr.Dispose();

                        if (string.IsNullOrEmpty(z) == false)
                        {
                            contacts = JsonSerializer.Deserialize<List<Contact>>(z);
                        }

                        Console.WriteLine("Enter ContactId");

                        var uId = Convert.ToInt32(Console.ReadLine());

                        try
                        {
                            contacts.Remove(contacts[uId]);

                            strJson = JsonSerializer.Serialize<IList<Contact>>(contacts, opt);

                            streamWriter = new StreamWriter(path, false);

                            streamWriter.WriteLine(strJson);

                            streamWriter.Dispose();

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

                            if (value != "")
                                contacts[uId].FirstName = value;


                            Console.WriteLine("Enter LastName");

                            value = Console.ReadLine();

                            if (value != "")
                                contacts[uId].LastName = value;

                            Console.WriteLine("Enter PhoneNumber");

                            value = Console.ReadLine();

                            if (value != "")
                                contacts[uId].PhoneNumber = value;

                            strJson = JsonSerializer.Serialize<IList<Contact>>(contacts, opt);

                            streamWriter = new StreamWriter(path, false);

                            streamWriter.WriteLine(strJson);

                            streamWriter.Dispose();

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