namespace BlazorFluxArchitecture.Stores.CounterStore
{
    public class CounterState
    {
        public int Count { get; set; }

        public CounterState(int count)
        {
            Count = count;
        }
    }



    public class CounterStore
    {
        private CounterState _state;

        public CounterStore()
        {
            _state = new CounterState(0);
        }

        public CounterState GetState()
        {
            return _state;
        }

        public void IncrementCount()
        {
            var count = _state.Count;
            count++;
            _state = new CounterState(count);
            BroadcastStateChange();
        }

        public void DecrementCount()
        {
            var count = _state.Count;
            count--;
            _state = new CounterState(count);
            BroadcastStateChange();
        }

        #region Observer Pattern (listeners)
        private Action _listeners;

        public void AddStateChangeListeners(Action listener)
        {
            _listeners += listener;
        }

        public void RemoveStateChangeListeners(Action listener)
        {
            _listeners -= listener;
        }

        public void BroadcastStateChange()
        {
            _listeners.Invoke();
        }
        #endregion  
    }
}
