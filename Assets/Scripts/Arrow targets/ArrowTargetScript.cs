using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class ArrowTargetScript : MonoBehaviour
{
    public bool isArrowDestroyer;
    public bool isForbiddenTarget;

    protected virtual void OnTriggerEnter2D(Collider2D coll)
    {
        CheckCollision(coll);
    }

    protected virtual void OnCollisionEnter2D(Collision2D coll)
    {
        CheckCollision(coll.collider);
    }

    private void CheckCollision(Collider2D coll)
    {
        ArrowScript arrow = coll.GetComponent<ArrowScript>();
        if(arrow != null && arrow.isShooting)
            InteractWithArrow(arrow);
    }

    protected virtual void InteractWithArrow(ArrowScript arrow)
    {
        if (isForbiddenTarget)
            GameMangerScript.instance.OnLoseArrow();
        if (isArrowDestroyer)
            arrow.DestroyArrow();
        else
            arrow.Stop();
    }
}
