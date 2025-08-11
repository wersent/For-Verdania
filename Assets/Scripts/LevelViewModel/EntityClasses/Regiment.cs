using System;
using Model;
using UnityEngine;

namespace LevelViewModel
{
    class Regiment
    {
<<<<<<< HEAD:Assets/Scripts/LevelViewModel/EntityClasses/Regiment.cs
        private GameObject _regimentView;
        private EntitySide _side;
        public event Action<ReigmentMove> OnRegimentMove;
=======
        private RegimentSide _side;
        public event Action<RegimentMove> OnRegimentMove;
>>>>>>> main:Assets/Scripts/EntityClasses/Regiment.cs

        public EntitySide Side
        {
            get => _side;
            private set => _side = value;
        }

        public Regiment(EntitySide side, GameObject regimentView)
        {

        }
    }

<<<<<<< HEAD:Assets/Scripts/LevelViewModel/EntityClasses/Regiment.cs
    enum ReigmentMove
=======
    enum RegimentSide
    {
        Player,
        Enemy
    }
    enum RegimentMove
>>>>>>> main:Assets/Scripts/EntityClasses/Regiment.cs
    {
        Idle,
        Moving,
        Attacking,
        Dead
    }
    public enum EntitySide
    {
        Player,
        Enemy
    }
}