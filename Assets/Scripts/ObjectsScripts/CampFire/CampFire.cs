using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    public int damage;
    public float cooltime;

    List<IDamagable> things = new List<IDamagable>();

    private void Start()
    {
        InvokeRepeating("FireDamage", 0, cooltime);
    }

    private void FireDamage()
    {
        for(int i = 0; i < things.Count; i++)
        {
            things[i].PhysicalDamaged(damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IDamagable damagable))
        {
            things.Add(damagable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out IDamagable damagable))
        {
            things.Remove(damagable);
        }
    }
}
