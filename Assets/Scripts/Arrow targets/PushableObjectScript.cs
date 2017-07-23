using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PushableObjectScript : ArrowTargetScript
{
    public float pushForce;

    protected Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected override void InteractWithArrow(ArrowScript arrow)
    { 
        Vector2 arrowVelocityDir = arrow.GetVelocity().normalized;
        rb.AddForce(arrowVelocityDir * pushForce, ForceMode2D.Impulse);
        base.InteractWithArrow(arrow);
    }
}