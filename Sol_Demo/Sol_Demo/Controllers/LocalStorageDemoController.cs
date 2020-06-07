using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hanssens.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sol_Demo.Models;
using Sol_Demo.Persitance;

namespace Sol_Demo.Controllers
{
    // https://github.com/hanssens/localstorage

    public class LocalStorageDemoController : Controller
    {
        #region Declaration

        private readonly LocalStorage localStorage = null;

        #endregion Declaration

        #region Constructor

        public LocalStorageDemoController(LocalStorage localStorage)
        {
            this.localStorage = localStorage;
        }

        #endregion Constructor

        #region Property

        [BindProperty]
        public UserModel Users { get; set; }

        #endregion Property

        public IActionResult Index()
        {
            localStorage.Clear();

            Users = new UserModel()
            {
                FirstName = "Kishor",
                LastName = "Naik"
            };

            Data.GetOrSet(localStorage, "mykey", JsonConvert.SerializeObject(Users));

            return View(Users);
        }

        public IActionResult Index1()
        {
            var userModelJson = Data.GetOrSet(localStorage, "mykey");

            Users = JsonConvert.DeserializeObject<UserModel>(userModelJson);

            return View(Users);
        }
    }
}