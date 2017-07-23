using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(MoveScript))]
public class PatrolScript : MonoBehaviour
{
    public Transform leftTarget;
    public Transform rightTarget;
    
    private int rotateTriggerHash;
    private Animator animController;
    private MoveScript moveScript;

    private void Start()
    {
        animController = GetComponent<Animator>();
        moveScript = GetComponent<MoveScript>();
        rotateTriggerHash = Animator.StringToHash("Rotate");
        SelectNextTarget();
    }

    private void SelectNextTarget()
    {
        if (transform.localScale.x == -1)
            moveScript.StartMove(rightTarget.transform.position, ChangeTarget);
        else
            moveScript.StartMove(leftTarget.transform.position, ChangeTarget);
    }

    public void ChangeTarget()
    {
        moveScript.StopMove();
        animController.SetTrigger(rotateTriggerHash);
    }

    public void OnRotationEnd()
    {
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
        SelectNextTarget();
    }
}
