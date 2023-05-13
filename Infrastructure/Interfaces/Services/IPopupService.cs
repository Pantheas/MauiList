namespace MauiList.Infrastructure.Interfaces.Services
{
    public interface IPopupService
    {
        Task ShowAlertAsync(
            string title,
            string message,
            string cancel);

        Task<string> ShowActionSheetAsync(
            string title,
            string cancel,
            string[] options);

        Task<string> ShowPromptAsync(
            string title,
            string message,
            string accept,
            string cancel);
    }
}
