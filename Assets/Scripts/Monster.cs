using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Unit
{
    protected virtual void Awake() { }
    protected virtual void Start() { }
    protected virtual void Update() { }
    
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet)
        {
            ReciveDamage();
        }

        Unit unit = collision.GetComponent<Unit>();
        if (unit && unit is Character)
        {
            unit.ReciveDamage();
        }
    }
}
