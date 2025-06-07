using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherScript : Regiment
{
    public override string Description { get => description; set => description = value; }

    void Awake()
    {
        isEnable = true;
        Description = "chilly guy with bow \n CHICKEN JOCKEY";
    }

    public override void Attack(int damage)
    {
        
    }

    public override void OnDeath()
    {
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
