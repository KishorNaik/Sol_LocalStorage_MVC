using Hanssens.Net;
using Newtonsoft.Json;
using Sol_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.Persitance
{
    public static class Data
    {
        public static UserModel GetOrSet(LocalStorage localStorage, string key, UserModel userModel)
        {
            if (!localStorage.Exists(key))
            {
                localStorage.Store<UserModel>(key, userModel);
            }
            else
            {
                userModel = localStorage.Get<UserModel>(key);
            }

            return userModel;
        }
    }
}