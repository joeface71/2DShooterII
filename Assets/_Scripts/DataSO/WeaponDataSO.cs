using System;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDataSO", menuName = "Weapons/WeaponData", order = 0)]
public class WeaponDataSO : ScriptableObject
{
    [field: SerializeField]
    public BulletDataSO BulletData { get; set; }

    [field: SerializeField]
    [field: Range(0, 100)]
    public int AmmoCapacity { get; set; } = 100;

    [field: SerializeField]
    public bool AutomaticFire { get; set; } = false;

    [field: SerializeField]
    [field: Range(0.1f, 2f)]
    public float WeaponDelay { get; set; } = 0.1f;

    [field: SerializeField]
    [field: Range(0, 10)]
    public float SpreadAngle { get; set; } = 5;

    [SerializeField]
    private bool multiBulletShot = false;

    [SerializeField]
    [Range(1, 10)]
    private int bulletCount = 1;

    internal int GetBulletCountToSpawn()
    {
        if (multiBulletShot == true)
        {
            return bulletCount;
        }
        return 1;
    }
}