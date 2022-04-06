using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBehaviour : MovementBehaviour
{
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _damage;

    public Transform Target
    {
        get { return _target; }
        set { _target = value; }
    }

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    // Update is called once per frame
    public override void Update()
    {
        Vector3 direction = _target.position - transform.position;
        Velocity = direction.normalized * Speed;
        GetComponent<Rigidbody>().velocity = transform.forward;

        base.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == _target)
        {
            //Increment the enemycount 
            PlayerHealthBehaviour targetHealth = other.GetComponent<PlayerHealthBehaviour>();
            if (targetHealth)
                targetHealth.TakeDamge(_damage);
            //destorys this enemy
            Destroy(gameObject);
        }
    }

    //destorys enemy on clicks
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
