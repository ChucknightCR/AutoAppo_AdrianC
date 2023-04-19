using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using AutoAppo_AdrianC.Models;
using System.Linq;
using System.Collections.ObjectModel;

namespace AutoAppo_AdrianC.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        //VM gestiona los cambios que ocurren entre M y V. 


        public UserRole MyUserRole { get; set; }
        public UserStatus MyUserStatus { get; set; }
        public User MyUser { get; set; }
        public UserDTO MyUserDTO { get; set; }

        public Appointment MyAppointment { get; set; }

        //Tiene que ver con la recuperación de contraseña
        public Email MyEmail { get; set; }
        public RecoveryCode MyRecoveryCode { get; set; }    



        public UserViewModel()
        {
            MyUser = new User();
            MyUserRole = new UserRole();
            MyUserStatus = new UserStatus();
            MyUserDTO = new UserDTO();
            MyEmail = new Email();
            MyRecoveryCode = new RecoveryCode();
            MyAppointment = new Appointment();

        }


        public async Task<UserDTO> GetUserData(string pEmail)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                UserDTO user = new UserDTO();

                user = await MyUserDTO.GetUserData(pEmail);

                if (user == null)
                {
                    return null;
                }
                else
                {
                    return user;
                }

            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally
            {
                IsBusy = false;
            }

        }

        public async Task<ObservableCollection<Appointment>> GetAppoList(int pUserId)
        {

            //TODO: 


            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                ObservableCollection<Appointment> list = new ObservableCollection<Appointment>();
                MyAppointment.UserId = pUserId;
                list= await MyAppointment.GetAppointmentListByUser();

                if (list == null)
                {
                    return null;
                }
                else
                {
                    return list;
                }

            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally
            {
                IsBusy = false;
            }

        }



        //funcionalidades principales del VM
        public async Task<bool> UserAccessValidation(string pEmail, string pPassword)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUser.Email = pEmail;
                MyUser.LoginPassword = pPassword;

                bool R = await MyUser.ValidateLogin();

                return R;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }

        }


        //Carga la lista de roles de usuario
        public async Task<List<UserRole>> GetUserRoles()
        {
            try
            {
                List<UserRole> roles = new List<UserRole>();

                roles = await MyUserRole.GetAllUserRoleList();

                if (roles == null)
                {
                    return null;
                }
                else
                {
                    return roles;
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> AddUser(string pEmail,
                                        string pName,
                                        string pPassword,
                                        string pIDNumber,
                                        string pPhoneNumber,
                                        string pAddress,
                                        int pUserRole,
                                        int pUserStatus = 3)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUser.Email = pEmail;
                MyUser.LoginPassword = pPassword;
                MyUser.Name = pName;
                MyUser.PhoneNumber = pPhoneNumber;
                MyUser.Address = pAddress;
                MyUser.CardId = pIDNumber;

                MyUser.UserRoleId = pUserRole;
                MyUser.UserStatusId = pUserStatus;

                bool R = await MyUser.AddUser();

                return R;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }


        }

        public async Task<bool> AddRecoveryCode(string pEmail)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyRecoveryCode.Email = pEmail;

                string RecoveryCode = "ABC123";

                //Tarea: Generar un codigo aleatorio de 6 digitos entre letras mayusculas y numeros
                //Ejemplos: QWE456, OPI654, etc

                string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var random = new Random();
                var randomCode = new string(Enumerable.Repeat(Chars , 6).Select(s => s[random.Next(s.Length)]).ToArray());
                Console.Write(randomCode);



                MyRecoveryCode.RecoveryCode1 = RecoveryCode;
                MyRecoveryCode.RecoveryCodeId = 0;

                bool R = await MyRecoveryCode.AddRecoveryCode();

                //Una vezz que se haya guardado correctamente el rec code, se envía el email

                if (R)
                {
                    MyEmail.SendTo = pEmail;
                    MyEmail.Subject = "AutoAPPO Password Recovery Code";

                    MyEmail.Message = string.Format("Your recovery code for AutoAPPO is: {0}", RecoveryCode);

                    R = MyEmail.SendEmail();

                }

                return R;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }


        }

        public async Task<bool> RecoveryCodeValidation(string pEmail, string pRecoveryCode)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyRecoveryCode.Email = pEmail;
                MyRecoveryCode.RecoveryCode1 = pRecoveryCode;


                bool R = await MyRecoveryCode.ValidateRecoveryCode();

                return R;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }

        }


    }
}
