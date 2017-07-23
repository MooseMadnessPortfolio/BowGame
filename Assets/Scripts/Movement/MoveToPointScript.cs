using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MoveScript))]
public class MoveToPointScript : MonoBehaviour
{
    public Transform point;
    public UnityEvent onArrive;

    private MoveScript moveScript;

    private void Start()
    {
        moveScript = GetComponent<MoveScript>();
        moveScript.StartMove(point.transform.position, onArrive.Invoke);
    }
}
