using System;

namespace Level
{
    abstract class RegimentAI
    {
        public RegimentAI()
        {

        }

        public virtual void Idle()
        {

        }

        public virtual object Attack()
        {
            return null;
        }

        public virtual object MovePosition()
        {
            return null;
        }

        public virtual void OnDeath()
        {

        }
    }
}
