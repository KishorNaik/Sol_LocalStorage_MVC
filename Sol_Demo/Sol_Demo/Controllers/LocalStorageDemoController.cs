using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hanssens.Net;
using Microsoft.AspNetCore.Mvc;
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

            Users = Data.GetOrSet(localStorage, "mykey", new UserModel()
            {
                FirstName = "Kishor",
                LastName = "Naik"
            });

            return View(Users);
        }

        public IActionResult Index1()
        {
            Users = Data.GetOrSet(localStorage, "mykey", null);

            return View(Users);
        }
    }
}