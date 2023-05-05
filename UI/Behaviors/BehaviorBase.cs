namespace MauiList.UI.Behaviors
{
    public class BehaviorBase<T> :
        Behavior<T>

        where T : BindableObject
    {
        public T AssociatedObject { get; set; }


        protected override void OnAttachedTo(
            T bindable)
        {
            base.OnAttachedTo(
                bindable);


            AssociatedObject = bindable;
        }
    }
}
