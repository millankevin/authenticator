using System.ComponentModel.DataAnnotations;

namespace Authenticator.DTO
{
    public class AddUsersDto
    {
        public int Type_identification_id { get; set; }
        public string Identification { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime Start_date { get; set; }
        [DataType(DataType.Date)]
        public DateTime End_date { get; set; }
        public int Access_group_id { get; set; }
        public int Busines_id { get; set; }
        public int Role_id { get; set; }
    }
}
