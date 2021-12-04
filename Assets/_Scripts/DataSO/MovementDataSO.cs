using UnityEngine;

[CreateAssetMenu(fileName = "MovementDataSO", menuName = "Agent/MovementData", order = 0)]
public class MovementDataSO : ScriptableObject
{
    [Range(1, 10)]
    public float maxSpeed = 5;

    [Range(0.1f, 100)]
    public float acceleration = 50, deceleration = 50;
}