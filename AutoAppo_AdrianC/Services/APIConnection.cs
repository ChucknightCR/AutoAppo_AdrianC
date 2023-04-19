using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAppo_AdrianC.Services
{
    public static class APIConnection
    {
        //En esta clase definimos el prefijo de consumo de las rutas de los controladores del API
        //normalmente los API trabajan con una versión de pruebas y otra en producción.

        //Además, acá vamos a escribir la info del API KEY, necesitamos podernos validar 

        public static string ProductionURLPrefix = "http://192.168.8.103:45455/api/";
        public static string TestingURLPrefix = "http://192.168.8.103:45455/api/";

        public static string ApiKeyName = "P6ApiKey";
        public static string ApiKeyValue = "ASDASDASD";



    }
}
