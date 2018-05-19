using Bachelor.Core.Application.CreateGroup;
using Bachelor.Core.Application.Transactions;
using Bachelor.Core.Application.UserProfile;
using Bachelor.DataAccess.CreateGroup.Interfaces;
using Bachelor.DataAccess.Transactions;
using Bachelor.DataAccess.Transactions.Interfaces;
using Bachelor.DataAccess.UserProfile;
using Bachelor.DataAccess.UserProfile.Interfaces;
using Bachelor.DataAccess;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace Bachelors.API
{
    /// <summary>
    /// 
    /// </summary>
    public static class UnityConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            //Create group
            container.RegisterType<ICreateGroupApplication, CreateGroupApplication>();
            container.RegisterType<ICreateGroupDAL, CreateGroupDAL>();

            //User Profile
            container.RegisterType<IUserProfileApplication, UserProfileApplication>();
            container.RegisterType<IUserProfileDAL, UserProfileDAL>();

            //Transactions
            container.RegisterType<ITransactionsApplication, TransactionsApplication>();
            container.RegisterType<ITransactionsDAL, TransactionsDAL>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}