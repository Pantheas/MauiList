using CodeMonkeys.DependencyInjection;
using CodeMonkeys.Navigation;

using MauiList.Infrastructure.Interfaces;
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
            container.RegisterType<IListsService, ListsService>();
        }
    }
}
