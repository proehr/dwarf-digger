using UnityEngine;

namespace Common.Logic.Variables
{
    [CreateAssetMenu(fileName = "NewFloatVariable", menuName = "General_Logic/Variables/Float Variable")]
    public class FloatVariable : AbstractVariable<float>
    {
        public void Add(float value)
        {
            runtimeValue += value;
            if(onValueChanged != null) onValueChanged.Raise();
        }

        public void Add(FloatVariable value)
        {
            runtimeValue += value.runtimeValue;
            if(onValueChanged != null) onValueChanged.Raise();
        }
    }
}
