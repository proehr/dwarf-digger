using System;
using UnityEngine;

namespace Common.Logic.Variables
{
    [Serializable]
    public abstract class AbstractReference<T>
    {
        [SerializeField] private T value;
        [SerializeField] private AbstractVariable<T> valueVariable;

        protected AbstractReference(T value)
        {
            this.value = value;
        }

        public void Set(T targetValue)
        {
            if (valueVariable != null)
            {
                valueVariable.Set(targetValue);
            }
            else
            {
                value = targetValue;
            }
        }

        protected T Value => valueVariable ? valueVariable.Get() : value;

        public static implicit operator T(AbstractReference<T> reference)
        {
            return reference.Value;
        }
    }
}