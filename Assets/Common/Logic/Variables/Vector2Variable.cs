﻿using UnityEngine;

namespace Common.Logic.Variables
{
    [CreateAssetMenu(fileName = "NewVector2Variable", menuName = "General_Logic/Variables/Vector2Variable")]
    public class Vector2Variable : AbstractVariable<Vector2>
    {
        public void Add(Vector2 value)
        {
            runtimeValue += value;
            if(onValueChanged != null) onValueChanged.Raise();
        }

        public void Add(Vector2Variable value)
        {
            runtimeValue += value.runtimeValue;
            if(onValueChanged != null) onValueChanged.Raise();
        }
    }
}