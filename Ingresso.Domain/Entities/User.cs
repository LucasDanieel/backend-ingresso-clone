
namespace Ingresso.Domain.Entities
{
    public class User
    {

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string CPF { get; private set; }
        public string PhoneDdd { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime? DateOfBirth { get; private set; }
        public Address? Address { get; private set; }
        public bool ReceiveNotification { get; private set; }
        public bool UserValid { get; private set; }


        public User()
        { }

        public User(Guid id, string name, string cpf, string phoneDdd, string phoneNumber, string email,
            string password, DateTime? dateOfBirth, Address address, bool receiveNotification, bool userValid)
        {
            Id = id;
            Name = name;
            CPF = cpf;
            PhoneDdd = phoneDdd;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            DateOfBirth = dateOfBirth;
            Address = address;
            ReceiveNotification = receiveNotification;
            UserValid = userValid;
        }

        public void HasingPassword(string? newPassword = null)
        {
            if (!string.IsNullOrEmpty(newPassword))
                Password = BCrypt.Net.BCrypt.HashPassword(newPassword, 12);
            else
                Password = BCrypt.Net.BCrypt.HashPassword(Password, 12);
        }

        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Password);
        }

        public void ChangeUserValid()
        {
            UserValid = true;
        }
    }
}
