using UnityEngine;

public class DestroyWithRelativeAnimScript : DestroyWithAnimScript
{
    public override void StartDestroy()
    {
        animController.applyRootMotion = false;
        GameObject animParent = new GameObject("animParent");
        animParent.transform.position = transform.position;
        animParent.transform.localScale = transform.localScale;
        animParent.transform.SetParent(transform.parent);
        transform.SetParent(animParent.transform);
        base.StartDestroy();
    }
}