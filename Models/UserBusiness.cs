  public class UserBusiness
    {
        public List<User> Users {get; set;}

        public UserBusiness()
        {
            Users = new List<User>();
        }

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public void DeleteUser(int id)
        {
            Users.Remove(Users[id]);
        }

        public void ShowUsers()
        {
            foreach(User user in Users)
            {
                System.Console.WriteLine(user.FirstName);
                System.Console.WriteLine(user.LastName);
                System.Console.WriteLine(user.PhoneNumber);
            }
        }

        public void UpdateUser(int id , User user)
        {
           Users[id] = user ;
        }
    }