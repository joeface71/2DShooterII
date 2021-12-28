using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IAgent, IHittable
{
    [SerializeField]
    private int maxHealth;

    private int health;

    public int Health
    {
        get => health;
        set
        {
            health = Mathf.Clamp(value, 0, maxHealth);
            UiHealth.UpdateUI(health);
        }
    }

    private bool dead = false;

    [field: SerializeField]
    public UIHealth UiHealth { get; set; }

    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }

    [field: SerializeField]
    public UnityEvent OnDie { get; set; }

    private void Start()
    {
        Health = maxHealth;
        UiHealth.Initialize(Health);
    }

    public void GetHit(int damage, GameObject damageDealer)
    {
        if (dead == false)
        {
            Health -= damage;
            OnGetHit?.Invoke();
            if (Health <= 0)
            {
                OnDie?.Invoke();
                dead = true;
            }
        }
    }
}
