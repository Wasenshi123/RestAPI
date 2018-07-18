using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Wasenshi.CreditCard.BLL;
using Wasenshi.CreditCard.BLL.Interfaces;
using Wasenshi.CreditCard.DAL;
using Wasenshi.CreditCard.DAL.Interfaces;
using Wasenshi.CreditCard.WebAPI.Common;

namespace Wasenshi.CreditCard.WebAPI
{
    public class WindsorConfig : IHttpControllerActivator
    {
        public static IWindsorContainer Container { get; set; }

        public WindsorConfig()
        {
            Container = new WindsorContainer();
            Container.Install(new ComponentInstaller());
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var controller = (IHttpController) Container.Resolve(controllerType);
            request.RegisterForDispose(new Release(() => Container.Release(controller)));

            return controller;
        }

        /// <summary>
        ///     Class Release for releasing controller in windsor container when request is disposed.
        /// </summary>
        private sealed class Release : IDisposable
        {
            /// <summary>
            ///     The release action.
            /// </summary>
            private readonly Action _release;

            /// <summary>
            ///     Initializes a new instance of the <see cref="Release" /> class.
            /// </summary>
            /// <param name="release">The release action.</param>
            public Release(Action release)
            {
                _release = release;
            }

            /// <summary>
            ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                _release();
            }
        }
    }

    internal class ComponentInstaller : IWindsorInstaller
    {

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes
                    .FromThisAssembly()
                    .BasedOn<ApiController>()
                    .LifestylePerWebRequest(),
                Component.For<ILogger>()
                    .ImplementedBy<Logger>()
                    .LifestylePerWebRequest(),
                Component.For<ICreditCardBll>()
                    .ImplementedBy<CreditCardBll>()
                    .LifestylePerWebRequest(),
                Component.For<ICreditCardRepository>()
                    .ImplementedBy<CreditCardRepository>()
                    .LifestylePerWebRequest()
            );

        }
    }
}