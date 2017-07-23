using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JoinedObjectScript : ArrowTargetScript
{
    public bool canFallByArrow;

    private bool isFalled = false;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected override void InteractWithArrow(ArrowScript arrow)
    {
        if (!isArrowDestroyer)
            AttachArrow(arrow);

        if (!isFalled && canFallByArrow)
        {
            Fall();
            if (isArrowDestroyer)
                arrow.DestroyArrow();
        }
        else
            base.InteractWithArrow(arrow);
    }
    
    protected void AttachArrow(ArrowScript arrow)
    {
        arrow.Stop();
        arrow.transform.SetParent(transform);
    }

    public void Fall()
    {
        if (!isFalled)
        {
            isFalled = true;
            rb.isKinematic = false;
        }
    }
}
