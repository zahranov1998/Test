﻿namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
             var contactBusiness = new ContactBusiness();

            Contact contact = new Contact();

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

                        contactBusiness.AddContact(contact);

                        break;

                   case 2:

                        contactBusiness.ShowContact();

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
                            contact.FirstName = Console.ReadLine();

                            Console.WriteLine("Enter LastName");
                            contact.LastName = Console.ReadLine();

                            Console.WriteLine("Enter PhoneNumber");
                            contact.PhoneNumber = Console.ReadLine();

                            contactBusiness.UpdateContact(uId , contact);

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