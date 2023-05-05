using CodeMonkeys.MVVM.Models;

namespace MauiList.Infrastructure.Models
{
    public class ListEntry :
        ModelBase
    {
        public Guid ID
        {
            get => GetValue(Guid.NewGuid());
            private set => SetValue(value);
        }

        public string Content
        {
            get => GetValue<string>();
            set => SetValue(value);
        }


        public bool IsChecked
        {
            get => GetValue<bool>();
            set => SetValue(value);
        }


        public DateTime CreationDate
        {
            get => GetValue(DateTime.Now);
            set => SetValue(value);
        }
    }
}
