using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DateService.Models;
using DateService.Services;

namespace DateService.Logic
{
    public class UserLogic
    {
        private IDateService _dateService;

        public UserLogic(IDateService dateService)
        {
            _dateService = dateService;
        }

        public User Create(string name)
        {
            if (_dateService.Now < new DateTime(2017, 9, 1))
            {
                throw new Exception("Rejestracja użytkowników jest zamknięta do 1 września 2017.");
            }

            User user = new User();

            user.Name = name;

            //dodanie użytkownika
            
            return user;
        }

        public User Update(User user)
        {
            user.UpdatedDate = _dateService.Now;

            //zapis użytkownika

            return user;
        }
    }
}