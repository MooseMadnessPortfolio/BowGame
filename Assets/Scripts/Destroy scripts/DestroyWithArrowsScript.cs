public class DestroyWithArrowsScript : DestroyWithAnimScript
{
    public override void StartDestroy()
    {
        ArrowScript[] arrows = GetComponentsInChildren<ArrowScript>();
        foreach(ArrowScript arrow in arrows)
        {
            arrow.DestroyArrow();
        }
        base.StartDestroy();
    }
}