namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactBusiness contactBusiness;

            Contact contact = new Contact();

            var exit = "";

            Console.WriteLine("For Creating New File Press 1 Else Press Any Keys");

            var s = Console.ReadLine();

            if (s == "1")
            {
                Console.WriteLine("Enter Your File Name");

                var path = Directory.GetCurrentDirectory() + $"\\{Console.ReadLine()}.txt";

                contactBusiness = new ContactBusiness(path);
            }
            else
            {
                contactBusiness = new ContactBusiness();
            }

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

                        contactBusiness.AddContact(contact);

                        break;

                    case 2:

                        contactBusiness.ShowContacts();

                        break;

                    case 3:

                        Console.WriteLine("Enter ContactId");

                        try
                        {
                            var uId = Convert.ToInt32(Console.ReadLine());

                            if (contactBusiness.ContactExist(uId) == false)
                                throw new Exception();

                            contactBusiness.DeleteContact(uId);
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
                            var uId = Convert.ToInt32(Console.ReadLine());

                            if (contactBusiness.ContactExist(uId) == false)
                                throw new Exception();


                            Console.WriteLine("Enter FirstName");
                            contact.FirstName = Console.ReadLine();

                            Console.WriteLine("Enter LastName");
                            contact.LastName = Console.ReadLine();

                            Console.WriteLine("Enter PhoneNumber");
                            contact.PhoneNumber = Console.ReadLine();

                            contactBusiness.UpdateContact(uId, contact);
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