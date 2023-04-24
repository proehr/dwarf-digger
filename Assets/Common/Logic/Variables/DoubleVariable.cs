using UnityEngine;

namespace Common.Logic.Variables
{
    [CreateAssetMenu(fileName = "NewDoubleVariable", menuName = "General_Logic/Variables/DoubleVariable")]
    public class DoubleVariable : AbstractVariable<double>
    {
        public void Add(double value)
        {
            runtimeValue += value;
            if(onValueChanged != null) onValueChanged.Raise();
        }

        public void Add(DoubleVariable value)
        {
            runtimeValue += value.runtimeValue;
            if(onValueChanged != null) onValueChanged.Raise();
        }
    }
}
