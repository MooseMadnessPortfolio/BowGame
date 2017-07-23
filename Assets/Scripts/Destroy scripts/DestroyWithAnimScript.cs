using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DestroyWithAnimScript : DestroyAction
{
    protected Animator animController;

    private void Awake()
    {
        animController = GetComponent<Animator>();
    }

    public override void StartDestroy()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Collider2D coll = GetComponent<Collider2D>();
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
        }
        if (coll != null)
            coll.enabled = false;
        animController.SetTrigger("Dead");
    }
}