namespace EventBus
{
    public class CallbackWithPriority
    {
        /// add priority to callbacks
        /// the higher the Priority, the earlier the event will be called

        public readonly int Priority;
        public readonly object Callback;

        public CallbackWithPriority(int priority, object callback)
        {
            Priority = priority;
            Callback = callback;
        }
    }
}
