using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MovableMonster : Monster
{
    [SerializeField]
    private float speed = 2.0F;
    private Vector3 direction;

    private SpriteRenderer sprite;

    protected override void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    protected override void Start()
    {
        direction = transform.right;
    }

    protected override void Update()
    {
        Move();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Unit unit = collision.GetComponent<Unit>();
        if (unit && unit is Character)
        {
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.3F)
            {
                ReciveDamage();
            }
            else
            {
                unit.ReciveDamage();
            }
        }
    }

    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + (transform.up * 0.5F) + (transform.right * direction.x * 0.5F), 0.08F);
        
        if (colliders.Length > 0 && colliders.All(x => !x.GetComponent<Character>()))
        {
            direction *= -1.0F;
        }

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
}
