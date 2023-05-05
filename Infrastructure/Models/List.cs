using CodeMonkeys.MVVM.Models;

namespace MauiList.Infrastructure.Models
{
    public class List :
        ModelBase
    {
        public Guid ID
        {
            get => GetValue(Guid.NewGuid());
            private set => SetValue(value);
        }


        public string Name
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public IEnumerable<ListEntry> Entries
        {
            get => GetValue<IEnumerable<ListEntry>>();
            set => SetValue(value);
        }


        public DateTime CreationDate
        {
            get => GetValue(DateTime.Now);
            set => SetValue(value);
        }
    }
}
