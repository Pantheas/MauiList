using MauiList.Infrastructure.Interfaces.Services;

namespace MauiList.UI.Services
{
    public class PopupService :
        IPopupService
    {
        public async Task ShowAlertAsync(
            string title,
            string message,
            string cancel)
        {
            var mainPage = Application.Current.MainPage;
            
            await mainPage.DisplayAlert(
                title,
                message,
                cancel);
        }


        public async Task<string> ShowActionSheetAsync(
            string title,
            string cancel,
            string[] options)
        {
            var mainPage = Application.Current.MainPage;


            return await mainPage.DisplayActionSheet(
                title,
                cancel,
                destruction: null,
                options);
        }

        public async Task<string> ShowPromptAsync(
            string title,
            string message,
            string accept,
            string cancel)
        {
            var mainPage = Application.Current.MainPage;


            return await mainPage.DisplayPromptAsync(
                title,
                message,
                accept,
                cancel);
        }
    }
}
