using Lab3.BLL.Interfaces;
using Lab3.BLL.Services;
using Ninject;
using Ninject.Extensions.ChildKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace Lab4.WebAPI.DI
{
    public class NinjectResolver : NinjectScope, IDependencyResolver
    {
        private IKernel kernel;

        public NinjectResolver(IKernel kernel)
           : base(kernel)
        {
            this.kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectScope(kernel);
        }

    }
}