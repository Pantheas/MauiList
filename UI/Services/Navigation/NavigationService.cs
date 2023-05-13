using CodeMonkeys.MVVM;
using MauiList.Infrastructure.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiList.UI.Services.Navigation
{
    public class NavigationService :
        INavigationService
    {
        private static readonly IList<NavigationMap> _registrations =
            new List<NavigationMap>();


        public async Task ShowAsync<TViewModel>()
            where TViewModel : IViewModel
        {
            throw new NotImplementedException();
        }


        internal void Register(
            NavigationMap registration)
        {
            if (registration?.ViewModel == null ||
                registration?.View == null)
            {
                throw new InvalidOperationException();
            }


            if (_registrations.Any(
                map => map.ViewModel == registration.ViewModel))
            {
                var map = _registrations.First(
                    map => map.ViewModel == registration.ViewModel);

                map.View = registration.View;
                map.TargetControl = registration.TargetControl;
            }
            else
            {
                _registrations.Add(
                    registration);
            }
        }
    }
}
