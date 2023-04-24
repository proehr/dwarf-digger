using UnityEngine;

namespace Common.Logic.Variables
{
    [CreateAssetMenu(fileName = "NewIntVariable", menuName = "General_Logic/Variables/IntVariable")]
    public class IntVariable : AbstractVariable<int>
    {
        public void Add(int value)
        {
            runtimeValue += value;
            if(onValueChanged != null) onValueChanged.Raise();
        }

        public void Add(IntVariable value)
        {
            runtimeValue += value.runtimeValue;
            if(onValueChanged != null) onValueChanged.Raise();
        }
    }
}
