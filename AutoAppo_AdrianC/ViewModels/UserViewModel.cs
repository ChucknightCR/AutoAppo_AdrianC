using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoAppo_AdrianC.Models;

namespace AutoAppo_AdrianC.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        //VM Gestiona los cambios que ocurren entre M(Models) y V(Views) 

        public UserRole MyUserRole { get; set; }
        public UserStatus MyUserStatus { get; set; }   
        
        public User MyUser { get; set; }

        public UserViewModel()
        {
            MyUser= new User();
            MyUserStatus= new UserStatus();
            MyUserRole= new UserRole(); 

            //TODO: Agregar instancia del DTO 
        }
        //Funcionalidades principales del VM
        public async Task<bool> UserAccessValidation(string pEmail, string pPassword)
        {
            if (IsBusy) return false;
            IsBusy= true;

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


    }
}
