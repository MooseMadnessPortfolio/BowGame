using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ArrowScript : MonoBehaviour
{
    public int damageAmount;
    public DestroyAction destroyAction;

    public bool isShooting { get; private set; } 

    private Rigidbody2D rb;
    private Collider2D coll;
    private bool isDestroyed = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        isShooting = false;
    }

    private void FixedUpdate()
    {
        if(isShooting && rb.velocity != Vector2.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, -Vector3.Cross(Vector3.forward, rb.velocity));
        }
    }

    public void Shoot(Vector3 forceV)
    {
        if (!isShooting)
        {
            rb.isKinematic = false;
            rb.AddForce(forceV, ForceMode2D.Impulse);
            isShooting = true;
        }
    }

    public void Stop()
    {
        if (isShooting)
        {
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            isShooting = false;
            coll.enabled = false;
        }
    }

    public Vector2 GetVelocity()
    {
        return rb.velocity;
    }

    public void DestroyArrow()
    {
        if (!isDestroyed)
        {
            isDestroyed = true;
            if (destroyAction != null)
            {
                Stop();
                destroyAction.StartDestroy();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
