using System.Text.RegularExpressions;
using Authenticator.DTO;

namespace Authenticator.Common
{
    public static class Validation
    {
        public static bool ValidateIdsAndName(AddUsersDto userDto)
        {
            //if ((userDto.Name.IsNullOrEmpty() || userDto.Name == "string") || !ValidateNumbers(userDto.Mobile))
            //    return true;
            //else if (!ValidateEnum(typeof(RolEnum), userDto.Role_id) ||
            //    !ValidateEnum(typeof(TypeIdentificationEnum), userDto.Type_identification_id) ||
            //    !ValidateEnum(typeof(AccessGroupEnum), userDto.Access_group_id) ||
            //    !ValidateEnum(typeof(BussinesEnum), userDto.Busines_id))
            //    return true;
            //else
            return false;
        }


        public static bool ValidateIdentificationAndEmail(AddUsersDto userDto)
        {
            //if (!ValidateNumbers(userDto.Identification) || userDto.Identification.IsNullOrEmpty() || userDto.Email.IsNullOrEmpty())
            //    return true;
            //else if (!ValidateEnum(typeof(RolEnum), userDto.Role_id) ||
            //    !ValidateEnum(typeof(TypeIdentificationEnum), userDto.Type_identification_id) ||
            //    !ValidateEnum(typeof(AccessGroupEnum), userDto.Access_group_id) ||
            //    !ValidateEnum(typeof(BussinesEnum), userDto.Busines_id))
            //    return true;
            //else
            return false;
        }

        private static bool ValidateEnum(Type enumerable, int value)
        {
            if (System.Enum.IsDefined(enumerable, value))
                return true;
            else
                return false;
        }

        private static bool ValidateNumbers(string input)
        {
            // Patrón de expresión regular que verifica que solo haya números
            string pattern = "^[0-9]+$";

            // Verificar si la cadena de entrada coincide con el patrón
            return Regex.IsMatch(input, pattern);
        }
    }
}

