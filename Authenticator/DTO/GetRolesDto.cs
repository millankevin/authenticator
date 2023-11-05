using System.ComponentModel.DataAnnotations;

namespace Authenticator.DTO
{
    public class GetRolesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        [DataType(DataType.Date)]
        public DateTime Modified { get; set; }
    }
}
