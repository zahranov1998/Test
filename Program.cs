using System.Security.Cryptography.X509Certificates;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            User u1 = new User { FirstName = "Zahra", LastName = "Mohammadi", PhoneNumber = "12345678" };
            User u2 = new User { FirstName = "Elham", LastName = "aaaaa", PhoneNumber = "12345678" };
            User u3 = new User { FirstName = "Ali", LastName = "Milani", PhoneNumber = "12345678" };

            var userBusiness = new UserBusiness();

            userBusiness.AddUser(u1);

            userBusiness.AddUser(u2);

            userBusiness.AddUser(u3);

            //userBusiness.ShowUsers();

            var exit = "";

            while (exit.ToLower() != "e")
            {

                System.Console.WriteLine("Select The Oparation : \n 1.Add User \n 2.Show Users \n 3.Delete User \n 4.Update User");

                var a = Convert.ToInt32(Console.ReadLine());

              
                switch (a)
                {
                    case 1:

                        User user = new User();

                        System.Console.WriteLine("Enter FirstName");
                        user.FirstName = Console.ReadLine();

                        System.Console.WriteLine("Enter LastName");
                        user.LastName = Console.ReadLine();

                        System.Console.WriteLine("Enter PhoneNumber");
                        user.PhoneNumber = Console.ReadLine();

                        userBusiness.AddUser(user);

                        System.Console.WriteLine("User Added Successfully");

                        break;

                    case 2:

                        foreach (User item in userBusiness.Users)
                        {
                            System.Console.WriteLine(item.FirstName);
                            System.Console.WriteLine(item.LastName);
                            System.Console.WriteLine(item.PhoneNumber);
                        }

                        break;

                    case 3:

                        System.Console.WriteLine("Enter UserId");

                        var uId = Convert.ToInt32(Console.ReadLine());

                        try
                        {
                            userBusiness.DeleteUser(uId);

                            System.Console.WriteLine("User Deleted Successfully");
                        }
                        catch
                        {
                            System.Console.WriteLine("Error ! Couldn't Delete");
                        }

                        break;

                    case 4:

                        System.Console.WriteLine("Enter UserId");

                        uId = Convert.ToInt32(Console.ReadLine());

                        try
                        {
                            System.Console.WriteLine("Enter FirstName");
                            var value = Console.ReadLine();
                            if(value != "")
                            userBusiness.Users[uId].FirstName = value;


                            System.Console.WriteLine("Enter LastName");
                            value = Console.ReadLine();
                            if(value != "")
                            userBusiness.Users[uId].FirstName = value;

                            System.Console.WriteLine("Enter PhoneNumber");
                            value = Console.ReadLine();
                            if(value != "")
                            userBusiness.Users[uId].FirstName = value;

                            System.Console.WriteLine("User Updated Successfully");

                        }
                        catch
                        {
                            System.Console.WriteLine("Error! Couldn't Update");
                        }

                        break;
                }

                System.Console.WriteLine("For Exit Press 'E'");

                exit = Console.ReadLine();
            }
        }
    }
}