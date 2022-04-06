using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFireBehaviour : MonoBehaviour
{
    private string _ownerTag;
    [SerializeField]
    private float _damage;
    [SerializeField]
    private BulletProjectileBehaviour _gun;
    [SerializeField]
    private float _bulletCooldown;
    [SerializeField]
    private bool _destroyOnHit;
    private float _bulletTimer;
    [SerializeField]
    private int _ammo = 0;
    [SerializeField]
    private bool _infiniteAmmo = true;

    public string OwnerTag
    {
        get { return _ownerTag; }
        set { _ownerTag = value; }
    }

    public bool CheckHasAmmo()
    {
        if (_infiniteAmmo) return true;

        return _ammo > 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!CheckHasAmmo()) return;

        _bulletTimer += Time.deltaTime;

        if (_bulletTimer >= _bulletCooldown)
        {
            _gun.Fire();
            _bulletTimer = 0;

            if (!_infiniteAmmo)
                _ammo--;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == OwnerTag)
            return;

        HealthBehaviour otherHealth = other.GetComponent<HealthBehaviour>();

        if (!otherHealth)
            return;

        otherHealth.TakeDamge(_damage);

        if (_destroyOnHit)
            Destroy(gameObject);
    }
}
