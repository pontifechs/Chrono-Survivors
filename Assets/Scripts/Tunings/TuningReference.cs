using System;
using UnityEngine;

namespace Tunings
{
    public class TuningReference : MonoBehaviour
    {
        [SerializeField] private ScriptableObject tuning;

        private void Awake()
        {
            if (!tuning)
            {
                throw new Exception("No tuning reference set on " + gameObject.name + "!!");
            }
        }

        public T Get<T>()
        {
            if (tuning is T casted)
            {
                return casted;
            }

            throw new Exception("Referenced tuning: " + tuning.name + " does not implement " + typeof(T).Name + "!!");
        }
    }
}