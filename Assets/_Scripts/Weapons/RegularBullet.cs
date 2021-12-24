using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RegularBullet : Bullet
{
    protected Rigidbody2D rigidbody2d;
    private bool isDead = false;

    public override BulletDataSO BulletData
    {
        get => base.BulletData;
        set
        {
            base.BulletData = value;
            rigidbody2d = GetComponent<Rigidbody2D>();
            rigidbody2d.drag = BulletData.Friction;
        }
    }

    private void FixedUpdate()
    {
        if (rigidbody2d != null && BulletData != null)
        {
            rigidbody2d.MovePosition(transform.position + BulletData.BulletSpeed * transform.right * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (isDead)
        {
            return;
        }
        isDead = true;
        var hittable = other.GetComponent<IHittable>();
        hittable?.GetHit(BulletData.Damage, gameObject);

        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            HitObstacle(other);
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            HitEnemy(other);
        }

        Destroy(gameObject);
    }

    private void HitEnemy(Collider2D other)
    {
        Vector2 randomOffset = Random.insideUnitCircle * 0.5f;
        Instantiate(BulletData.ImpactEnemyPrefab, other.transform.position + (Vector3)randomOffset, Quaternion.identity);
    }

    private void HitObstacle(Collider2D other)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
        if (hit.collider != null) // cant check if a struct is null
        {
            Instantiate(BulletData.ImpactObstaclePrefab, hit.point, Quaternion.identity);
        }
    }

}
