using System;
using UnityEngine;

namespace Common.Logic.Event
{
    [CreateAssetMenu(fileName = "new ActionEvent", menuName = "General_Logic/Action Event")]
    public class ActionEvent : ScriptableObject
    {
        private Action listeners;
    
        public void Raise()
        {
            this.listeners?.Invoke();
        }

        public void RegisterListener(Action listener)
        {
            this.listeners += listener;
        }

        public void UnregisterListener(Action listener)
        {
            this.listeners -= listener;
        }
    }
}