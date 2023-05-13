using CodeMonkeys.DependencyInjection;
using CodeMonkeys.Navigation;
using MauiList.Infrastructure.Interfaces.Services;
using MauiList.Infrastructure.Services.DAL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiList.Infrastructure
{
    public static class Bootstrap
    {
        public static void ConfigureContainer(
            IDependencyRegister container)
        {
            container.RegisterType<IListsRepository, LocalListsRepository>();
            container.RegisterType<IListsService, ListsService>();
        }
    }
}
