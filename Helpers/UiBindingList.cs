using System.ComponentModel;
using System.Threading;

namespace XBLMarketplace_For_PC.Helpers
{
    /// <summary>
    /// A BindingList whose change events reach bound controls on the UI thread it was created on.
    /// JasonNS ThreadedBindingList marshals with Control.Invoke even when already on the UI thread, and Invoke
    /// from the UI thread first runs every queued callback. Download progress events queued behind each other then
    /// ran nested inside one another until the stack overflowed, so this only marshals from other threads.
    /// </summary>
    public class UiBindingList<T> : BindingList<T>
    {
        private readonly SynchronizationContext _ui = SynchronizationContext.Current;
        private readonly Thread _uiThread = Thread.CurrentThread;

        private bool OnUiThread => _ui == null || Thread.CurrentThread == _uiThread;

        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (OnUiThread) base.OnListChanged(e);
            else _ui.Send(_ => base.OnListChanged(e), null);
        }

        protected override void OnAddingNew(AddingNewEventArgs e)
        {
            if (OnUiThread) base.OnAddingNew(e);
            else _ui.Send(_ => base.OnAddingNew(e), null);
        }
    }
}
