using System;
using System.Collections.Generic;
using System.Text;
using AutoAppo_AdrianC.Models;

namespace AutoAppo_AdrianC
{
    public static class GlobalObjects
    {
        public static string MimeType = "application/json";
        public static string ContentType = "Content-Type";

        //agregar usuario global (igual que en progra 5)
        public static UserDTO LocalUser = new UserDTO();

    }
}