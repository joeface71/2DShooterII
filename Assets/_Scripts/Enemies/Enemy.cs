using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class Enemy : MonoBehaviour, IHittable, IAgent
{
    [field: SerializeField]
    public EnemyDataSO EnemyData { get; set; }

    [field: SerializeField]
    public int Health { get; private set; } = 2;

    [field: SerializeField]
    public EnemyAttack EnemyAttack { get; set; }

    private bool dead = false;

    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }

    [field: SerializeField]
    public UnityEvent OnDie { get; set; }

    private void Awake()
    {
        if (EnemyAttack == null)
        {
            EnemyAttack = GetComponent<EnemyAttack>();
        }
    }

    private void Start()
    {
        Health = EnemyData.MaxHealth;
    }

    public void GetHit(int damage, GameObject damageDealer)
    {
        if (dead == false)
        {
            Health--;
            OnGetHit?.Invoke();
            if (Health <= 0)
            {
                StartCoroutine(WaitToDie());
                dead = true;
                OnDie?.Invoke();
            }

        }
    }

    IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(.55f);
        Destroy(gameObject);
    }

    public void PerformAttack()
    {
        if (dead == false)
        {
            EnemyAttack.Attack(EnemyData.Damage);
        }
    }

}
