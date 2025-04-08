using Ingresso.Domain.Entities;

namespace Ingresso.Application.DTOs.UserDTOs
{
    public class UserDTO
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string PhoneDdd { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Address? Address { get; set; }
        public bool ReceiveNotification { get; set; }
        public bool? UserValid { get; set; } 

    }
}
