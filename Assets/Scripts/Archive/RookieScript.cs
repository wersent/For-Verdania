using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RookieScript : Regiment
{
    public override string Description { get => description; set => description = value; }

    private void Awake()
    {
        isEnable = true;
        Description = "chilly guy with sword and shield \n FLINT AND STEEL";
    }

    public override void Attack(int damage)
    {
        
    }

    public override void OnDeath()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
