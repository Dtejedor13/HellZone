using UnityEngine;
using UnityEngine.AI;

public class UnitNavMesh : MonoBehaviour
{
    private Vector3? movePosition;
    private NavMeshAgent agent;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    public void SetMovePosition(Vector3? destination)
    {
        movePosition = destination;
    }

    private void FixedUpdate()
    {
        if(movePosition != null)
            agent.destination = (Vector3)movePosition;
    }
}
