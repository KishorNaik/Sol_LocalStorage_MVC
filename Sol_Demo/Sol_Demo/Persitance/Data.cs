using Hanssens.Net;
using Newtonsoft.Json;
using Sol_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Sol_Demo.Persitance
{
    public static class Data
    {
        public static string GetOrSet(LocalStorage localStorage, string key, string value=null)
        {
            string data = null;
            if (!localStorage.Exists(key))
            {
               

                localStorage.Store<String>(key, value);
                data = value;
            }
            else
            {
                data = localStorage.Get<String>(key);
            }

            return data;
        }
    }
}