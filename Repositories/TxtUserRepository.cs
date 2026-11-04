using Entities;
using System.Text.Json;

namespace Repositories
{
    public class TxtUserRepository:IUserRepository
    {
        public User AddUser(User user)
        {
            string path = "../Repositories/DataUsers.txt";
            int numberOfUsers = System.IO.File.ReadLines(path).Count();
            user.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(path, userJson + Environment.NewLine);
            return user;
        }

        public User GetUser(LogInUser logInUser)
        {
            string path = "../Repositories/DataUsers.txt";
            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Email == logInUser.Email && user.Password == logInUser.Password)
                        return user;
                }
            }
            return null;
        }

        public void UpdateUser(int id, User updateUserDetails)
        {
            string path = "../Repositories/DataUsers.txt";
            string textToReplace = string.Empty;
            using (StreamReader reader =
            System.IO.File.OpenText(path))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(path);
                text = text.Replace(textToReplace,
                JsonSerializer.Serialize(updateUserDetails));
                System.IO.File.WriteAllText(path, text);
            }
        }
    }
}
