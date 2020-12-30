using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab3.BLL.Interfaces;
using Lab3.BLL.Services;
using Ninject.Modules;

namespace Lab4.WebAPI.DI
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>().InSingletonScope();
            Bind<ICardService>().To<CardService>().InSingletonScope();
        }
    }
}