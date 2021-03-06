﻿using UnityEngine;

namespace CodeUtils
{
    [System.Serializable]
    public class FloatReference
    {
        public bool useConstant = true;
        public float constantValue;
        public FloatVariable floatVariable;

        public float Value
        {
            get
            {
                return useConstant ? constantValue : floatVariable.Value;
            }

            set
            {
                if (useConstant)
                    constantValue = value;
                else
                    floatVariable.Value = value;
            }
        }
    }
}