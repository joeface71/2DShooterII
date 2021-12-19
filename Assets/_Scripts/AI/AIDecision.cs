using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIDecision : MonoBehaviour
{
    protected AIActionData aIActionData;
    protected AIMovementData aIMovementData;
    protected EnemyAIBrain enemyBrain;

    private void Awake()
    {
        aIActionData = transform.root.GetComponentInChildren<AIActionData>();
        aIMovementData = transform.root.GetComponentInChildren<AIMovementData>();
        enemyBrain = transform.root.GetComponent<EnemyAIBrain>();
    }

    public abstract bool MakeADecision();
}
