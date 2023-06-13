using System;

namespace Common.Logic.Variables
{
    [Serializable]
    public class FloatReference : AbstractReference<float>
    {
        public FloatReference(float value) : base(value)
        {
        }
    }
}
