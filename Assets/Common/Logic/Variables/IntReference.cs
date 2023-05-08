using System;

namespace Common.Logic.Variables
{
    [Serializable]
    public class IntReference : AbstractReference<int>
    {
        public IntReference(int value) : base(value)
        {
        }
    }
}
