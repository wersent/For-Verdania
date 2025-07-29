using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/*
public abstract class Regiment : MonoBehaviour
{
    public delegate void OnHpChanged(int hp);
    public event OnHpChanged OnHpChangedEvent;
    //OnHpChanged del;

    [SerializeField] protected int unitHp;
    [SerializeField] protected int dmg;
    [SerializeField] protected int amount;
    [SerializeField] protected string description;
    [SerializeField] protected Sprite icon;

    [SerializeField] protected int currentHp;
    [SerializeField] protected int currentDmg;
    [SerializeField] protected int currentAmount;
    [SerializeField] protected bool isEnable = false;

    public virtual int Hp { get => currentHp; set 
        {
            currentHp = unitHp * amount;
            OnHpChangedEvent?.Invoke(currentHp);
        }
    }
    public virtual int Dmg { get => currentDmg; set => currentDmg = dmg; }
    public virtual int Amount { get => currentAmount; set => currentAmount = amount; }
    public virtual string Description { get => description; set => description = "poor peasant"; }

    public Sprite GetIcon() { return icon; }

    //public string GetDescription() { return description; }

    public abstract void Attack(int damage);

    public abstract void OnDeath();
}
*/