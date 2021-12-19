using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IAgent, IHittable
{
    [field: SerializeField]
    public int Health { get; set; }

    private bool dead = false;

    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }

    [field: SerializeField]
    public UnityEvent OnDie { get; set; }

    public void GetHit(int damage, GameObject damageDealer)
    {
        if (dead == false)
        {
            Health -= damage;
            OnGetHit?.Invoke();
            if (Health <= 0)
            {
                StartCoroutine(DeathCoroutine());
                OnDie?.Invoke();
                dead = true;
            }
        }

    }

    IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(1.35f);
        Destroy(gameObject);
    }
}
