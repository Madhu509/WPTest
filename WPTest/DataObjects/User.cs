using WPTest.Extensions;

namespace WPTest.Models
{
    public class User
    {

        public string Login;
        public string FirstName;
        public string LastName;
        public string Password;
        public string ConfirmedPassword;

        public User(
            string login = null,
            string firstName = null,
            string lastName = null,
            string password = null,
            string confirmedPassword = null)
        {
            Login = login ?? TestData.Login();
            FirstName = firstName ?? TestData.Name();
            LastName = lastName ?? TestData.Name();
            Password = password ?? TestData.Password();
            ConfirmedPassword = confirmedPassword ?? password;
        }
    };
}