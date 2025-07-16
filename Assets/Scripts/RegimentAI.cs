using System;
using UnityEngine;

namespace Level
{
    abstract class RegimentAI
    {
        public RegimentAI()
        {

        }

        public virtual Field TurnProcessing(RegimentInfo info, RegimentView view)
        {
            return null;
        }

        public virtual void OnDeath()
        {

        }
    }
}
