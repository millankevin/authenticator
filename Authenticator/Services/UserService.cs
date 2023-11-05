using Authenticator.Common;
using Authenticator.Data;
using Authenticator.DTO;
using Authenticator.Logs;
using Authenticator.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Authenticator.Services
{
    public class UserService : IUserService
    {
        private readonly DataBaseContext _context;
        public UserService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<Result> BuscarUsuariosPorEmailAsync(string? email)
        {
            if (email == null)
                return new Result() { StatusResult = 404, StatusMessage = $"Debes ingresar un usuario valido" };

            var isValidEmail = ExpressionRegularEmail(email);

            if (isValidEmail)
            {
                //try
                //{
                //    var querable = _context.Users.DefaultIfEmpty().Include(rol => rol.Roles)
                //                                     .Where(x => x.Email.ToLower().Equals(email.ToLower()));

                //    if (querable.Count() < 1)
                //        return new Result() { StatusResult = 404, StatusMessage = $"El email ingresado {email} no se encuentra como usuario en nuestra base de datos" };

                //    var users = await querable.Select(userDto => new GetUsersDto()
                //    {
                //        Id = userDto.Id,
                //        Type_identification_id = userDto.Type_identification_id,
                //        Identification = userDto.Identification,
                //        Name = userDto.Name,
                //        Mobile = userDto.Mobile,
                //        Email = userDto.Email,
                //        Start_date = userDto.Start_date,
                //        End_date = userDto.End_date,
                //        Access_group_id = userDto.Access_group_id,
                //        Busines_id = userDto.Busines_id,
                //        Role_id = userDto.Role_id,
                //        User_status_id = userDto.User_status_id

                //    }).ToListAsync();

                //    LogResquest.GenerateGetUserPorEmailFile();
                //    return new Result() { StatusResult = 200, StatusMessage = "Ok", Data = users };
                //}
                //catch (Exception e)
                //{
                //    LogResquest.GenerateErrorFile(e.Message);
                //    throw e;
                //}  
                return new Result() { StatusResult = 201, StatusMessage = $"El email ingresado {email} no es valido" };//ELIMINAR
            }
            else
                return new Result() { StatusResult = 201, StatusMessage = $"El email ingresado {email} no es valido" };
        }
        public async Task<Result> BuscarUsuariosPorRolesAsync(string? Userrol)
        {
            if (Userrol == null)
                return new Result() { StatusResult = 404, StatusMessage = $"Debes ingresar un rol valido" };

            //var querable = _context.Users.Where(x => x.Roles.Name.ToLower().Equals(Userrol.ToLower()));

            //if (querable.Count() < 1)
            //    return new Result() { StatusResult = 404, StatusMessage = $"No existe usuarios con el rol {Userrol} en nuestra base de datos" };
            try
            {
                //var roles = await querable.Select(resp => new GetUsersDto()
                //{
                //    Id = resp.Id,
                //    Type_identification_id = resp.Type_identification_id,
                //    Identification = resp.Identification,
                //    Name = resp.Name,
                //    Mobile = resp.Mobile,
                //    Email = resp.Email,
                //    Start_date = resp.Start_date,
                //    End_date = resp.End_date,
                //    Access_group_id = resp.Access_group_id,
                //    Busines_id = resp.Busines_id,
                //    Role_id = resp.Role_id,
                //    User_status_id = resp.User_status_id

                //}).ToListAsync();
                //LogResquest.GenerateGetUserPorRoleFile();
                //return new Result() { StatusResult = 200, StatusMessage = "Ok", Data = roles };
                return new Result() { StatusResult = 200, StatusMessage = "Ok", Data = ""};      //ELIMINAR
            }
            catch (Exception e)
            {
                LogResquest.GenerateErrorFile(e.Message);
                throw e;
            }

        }
        public async Task<Result> CrearUsuariosAsync(AddUsersDto userDto)
        {
            if (Validation.ValidateIdsAndName(userDto))
                return new Result() { StatusResult = 404, StatusMessage = $"Ingrese los datos solicitados de manera correcta" };

            else if (Validation.ValidateIdentificationAndEmail(userDto))
                return new Result() { StatusResult = 404, StatusMessage = $"Ingrese los datos solicitados de manera correcta" };

            var isValidEmail = ExpressionRegularEmail(userDto.Email);

            if (isValidEmail)
            {
                //var querable = await _context.Users.DefaultIfEmpty().Where(x => x.Email.ToLower().Equals(userDto.Email.ToLower())).FirstOrDefaultAsync();
                var querable = "";//ELIMINAR

                if (querable == null)
                {
                    try
                    {
                        DateTime date = DateTime.Now;

                        //Users userCreated = new Users
                        //{
                        //    Type_identification_id = userDto.Type_identification_id,
                        //    Identification = userDto.Identification,
                        //    Name = userDto.Name,
                        //    Mobile = userDto.Mobile,
                        //    Email = userDto.Email,
                        //    Start_date = userDto.Start_date,
                        //    End_date = userDto.End_date,
                        //    Access_group_id = userDto.Access_group_id,
                        //    Busines_id = userDto.Busines_id,
                        //    Modified = date,
                        //    Created = date,
                        //    Password_expiration_date = date.AddDays(-1),
                        //    Role_id = userDto.Role_id,
                        //    User_status_id = (int)StateEnum.Active,
                        //};

                        //_context.Users.Add(userCreated);
                        await _context.SaveChangesAsync();
                        LogResquest.GenerateCreatedUserFile();
                        //return new Result() { StatusResult = 201, StatusMessage = $"usuario {userCreated.Email} se creado exitosamente" };
                        return new Result() { StatusResult = 201, StatusMessage = $"usuario  se creado exitosamente" };//ELIMINAR
                    }
                    catch (Exception e)
                    {
                        LogResquest.GenerateErrorFile(e.Message);
                        throw e;
                    }
                }
                else
                    return new Result { StatusResult = 404, StatusMessage = $"El usuarios {userDto.Email} ya existe en la base de datos" };
            }
            else
                return new Result() { StatusResult = 201, StatusMessage = $"El email ingresado {userDto.Email} no es valido" };
        }
        public async Task<Result> ActualizarUsuariosAsync(EditUsersDto userDto)
        {
            if (Validation.ValidateIdsAndName(userDto))
                return new Result() { StatusResult = 404, StatusMessage = $"Ingrese los datos solicitados de manera correcta" };

            else if (Validation.ValidateIdentificationAndEmail(userDto))
                return new Result() { StatusResult = 404, StatusMessage = $"Ingrese los datos solicitados de manera correcta" };

            var isValidEmail = ExpressionRegularEmail(userDto.Email);

            if (isValidEmail)
            {
                //var querable = await _context.Users.DefaultIfEmpty().Where(x => x.Id.Equals(userDto.Id) && x.Email.ToLower().Equals(userDto.Email.ToLower())).FirstOrDefaultAsync();
                var querable = "";//ELIMINAR

                if (querable != null)
                {
                    try
                    {
                        DateTime date = DateTime.Now;

                        //querable.Type_identification_id = userDto.Type_identification_id;
                        //querable.Identification = userDto.Identification;
                        //querable.Name = userDto.Name;
                        //querable.Mobile = userDto.Mobile;
                        //querable.Email = userDto.Email;
                        //querable.Start_date = userDto.Start_date;
                        //querable.End_date = userDto.End_date;
                        //querable.Access_group_id = userDto.Access_group_id;
                        //querable.Busines_id = userDto.Busines_id;
                        //querable.Modified = date;
                        //querable.Role_id = userDto.Role_id;

                        //_context.Users.Update(querable);
                        await _context.SaveChangesAsync();
                        LogResquest.GenerateUpdateUserFile();
                        //return new Result { StatusResult = 200, StatusMessage = $"El usuario {querable.Email} fue actualizado correctamente" };
                        return new Result { StatusResult = 200, StatusMessage = $"El usuario  fue actualizado correctamente" };//ELIMINAR
                    }
                    catch (Exception e)
                    {
                        LogResquest.GenerateErrorFile(e.Message);
                        throw e;
                    }
                }
                else
                    return new Result { StatusResult = 404, StatusMessage = $"El usuario {userDto.Email} o identificador {userDto.Id}  no existe en nuestra base de datos" };
            }
            else
                return new Result() { StatusResult = 201, StatusMessage = $"El email ingresado {userDto.Email} no es valido" };

        }
        public async Task<Result> ArchivarUsuariosAsync(string email)
        {
            if (email == null)
                return new Result() { StatusResult = 404, StatusMessage = $"Debes ingresar un usuario valido" };


            var isValidEmail = ExpressionRegularEmail(email);

            if (isValidEmail)
            {
                try
                {
                    //var querable = _context.Users.DefaultIfEmpty().Where(c => c.Email.ToLower().Equals(email.ToLower())).FirstOrDefault();
                    var querable = "";//ELIMINAr

                    if (querable != null)
                    {
                        //if (querable.User_status_id.Equals(2))
                        //    return new Result { StatusResult = 404, StatusMessage = $"El usuario {email} ya se encuentra inactivado en nuestra base de datos." };

                        //querable.User_status_id = (int)StateEnum.Inactive;

                        //_context.Users.Update(querable);
                        await _context.SaveChangesAsync();
                        LogResquest.GenerateInactivateUserFile();
                    }
                    else
                        return new Result { StatusResult = 404, StatusMessage = $"El email ingresado {email} no existe en nuestra base de datos" };

                    return new Result { StatusResult = 200, StatusMessage = $"El usuario {email} se ha desabilitado correctamente. " };

                }
                catch (Exception e)
                {
                    LogResquest.GenerateErrorFile(e.Message);
                    throw e;
                }
            }
            else
                return new Result { StatusResult = 404, StatusMessage = $"El usuarios ingresado {email} no es valido" };
        }
        public async Task<Result> BuscarRolesAsync()
        {
            try
            {
                var querable = await _context.Roles.DefaultIfEmpty().ToListAsync();

                if (querable.Count() < 1)
                    return new Result() { StatusResult = 404, StatusMessage = $"No existen roles en nuestra base de datos" };

                //var roles = querable.Select(resp => new GetRolesDto()
                //{
                //    Id = resp.Id,
                //    Name = resp.Name,
                //    Prefix = resp.Prefix,
                //    Created = resp.Created.Date,
                //    Modified = resp.Modified.Date,
                //});

                LogResquest.GenerateRolesFile();

                //return new Result() { StatusResult = 200, StatusMessage = "Ok", Data = roles };
                return new Result() { StatusResult = 200, StatusMessage = "Ok", Data = "" };//ELIMINAR

            }
            catch (Exception e)
            {
                LogResquest.GenerateErrorFile(e.Message);
                throw e;
            }
        }
        public bool ExpressionRegularEmail(string email)
        {
            return Regex.IsMatch(email,
                              @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                              RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
    }
}
