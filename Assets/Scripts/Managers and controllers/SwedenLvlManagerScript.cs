using UnityEngine;

public class SwedenLvlManagerScript : MonoBehaviour
{
    //left target after explosion
    public Transform warriorLeftTargetAE;
    public PatrolScript warriorScript;

    public void OnExplosion()
    {
        warriorScript.leftTarget = warriorLeftTargetAE;
        if (warriorScript.transform.position.x <= warriorLeftTargetAE.position.x && warriorScript.transform.localScale.x == 1)
            warriorScript.ChangeTarget();
    }
}