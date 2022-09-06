using System.Collections.Generic;

namespace Sat.Recruitment.Model.DTOs
{
    public class UserTypeDTO
    {
        public UserTypeDTO()
        {
            Users = new List<UserDTO>();
        } 
            
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserDTO> Users { get; set; }
    }
}