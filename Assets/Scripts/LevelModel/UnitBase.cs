using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.LevelModel
{
    public abstract class UnitBase
    {
        public string Name { get; private set; }
        public int Vitality { get; private set; }
        public AttackType Ability { get; private set; }
    }
}

public enum AttackType
{
    RangeAttack,
    Heal,

}
