using MaraphonApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace MaraphonApp.Controllers
{
    public class UserController
    {
        Core context = new Core();
        /// <summary>
        /// Добавление пользователя
        /// </summary>
        /// <param name="email">почта</param>
        /// <param name="firstName">имя</param>
        /// <param name="lastName">фамилия</param>
        /// <param name="role">роль</param>
        /// <param name="gender">роль</param>
        /// <param name="password">пароль</param>
        /// <returns>bool</returns>
        public bool SaveRunnerData(string email, string firstName, string lastName, string role, string gender, string password)
        {
            users newUser = new users()
            {
                user_email = email,
                user_firstname = firstName,
                user_lastname = lastName,
                user_othername = role,
                gender_code = gender,
                user_password = password
            };
            context.obj.users.Add(newUser);
            if (context.obj.SaveChanges() > 0)
                return true;
            else
                return false;

        }
    }
}
