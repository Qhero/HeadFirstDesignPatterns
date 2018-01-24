
namespace ObserverPattern.Interfaces
{
    public interface ISubject
    {
        /// <summary>
        /// Register an Observer Type to the Subject to get notification.
        /// </summary>
        /// <param name="o">Observer</param>
        void RegisterObserver(IObserver o);

        /// <summary>
        /// Remove an Observer Type from the Subject to not receive notification anymore.
        /// </summary>
        /// <param name="o">Observer</param>
        void RemoveObserver(IObserver o);

        /// <summary>
        /// Notify all registered observers of new update.
        /// </summary>
        void NotifyObservers();
    }
}
