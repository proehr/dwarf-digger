using Common.Logic.Event;
using UnityEngine;

namespace Common.Logic.Variables
{
    public abstract class AbstractVariable<T> : ScriptableObject
    {
        [SerializeField] protected T runtimeValue;
        [SerializeField] private T storedValue;
        [SerializeField] protected ActionEvent onValueChanged;

        private void OnEnable()
        {
            Restore();
        }

        public void Restore()
        {
            if (storedValue.Equals(runtimeValue)) return;
            runtimeValue = storedValue;
            
            if (onValueChanged == null) return;
            onValueChanged.Raise();
        }

        public T Get() => runtimeValue;

        public void Set(T value)
        {
            if (value.Equals(runtimeValue)) return;
            
            runtimeValue = value;
            if(onValueChanged != null) onValueChanged.Raise();
        }

        public ActionEvent GetChangedEvent()
        {
            return onValueChanged;
        }

        public void Copy(AbstractVariable<T> other) => runtimeValue = other.runtimeValue;

        public override string ToString()
        {
            return runtimeValue.ToString();
        }
    }
}
