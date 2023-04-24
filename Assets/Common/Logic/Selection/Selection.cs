using Common.Logic.Event;
using UnityEngine;

namespace Common.Logic.Selection
{
    public abstract class Selection<T> : ScriptableObject
    {
        public T selection;
        
        [SerializeField] private ActionEvent onSelectionChanged;
        
        public void Restore()
        {
            selection = default;
            if(onSelectionChanged != null) onSelectionChanged.Raise();
        }
        
        public T Get()
        {
            return selection;
        }
        
        
        
        public void Set(T value)
        {
            if (value == null)
            {
                selection = default(T);
                return;
            }
            
            if (value.Equals(selection)) return;
            
            selection = value;
            if(onSelectionChanged != null) onSelectionChanged.Raise();
        }
    }
}
