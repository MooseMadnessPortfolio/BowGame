using UnityEngine;

public class KozakScript : MonoBehaviour
{
    public Transform handTransform;
    public Transform handMaxPos;
    public Transform arrowStartPos;
    public Transform bodyCenterTransform;

    public ArrowScript arrowPrefab;
    public float shootForce;

    public float maxAngle;
    public float minAngle;
    public float maxTension;

    private Vector3 handStartLocPos;
    private float handMoveDist;
    private Quaternion bodyStartRot;

    private ArrowScript currArrow;

    private void Start()
    {
        handStartLocPos = handTransform.localPosition;
        bodyStartRot = bodyCenterTransform.rotation;
        handMoveDist = (handMaxPos.transform.position - handTransform.position).magnitude;
        CreateArrow();
    }

    private void CreateArrow()
    {
        currArrow = (ArrowScript)Instantiate(arrowPrefab, arrowStartPos.position, arrowStartPos.rotation);
        currArrow.transform.SetParent(arrowStartPos.parent);
    }

    //return tension that had set after restrictions
    public Vector3 SetTension(Vector3 tensionV)
    {
        float currTension = Mathf.Clamp(tensionV.magnitude, 0, maxTension);
        float currHandDist = handMoveDist * (currTension / maxTension);
        handTransform.localPosition = handStartLocPos + Vector3.right * currHandDist;
        
        Quaternion targetRot = Quaternion.LookRotation(Vector3.forward, -Vector3.Cross(tensionV, Vector3.forward));
        float targetRotZAngle = targetRot.eulerAngles.z;
        bool inAngleLimit = (minAngle > maxAngle && (targetRotZAngle > minAngle || targetRotZAngle < maxAngle)) ||
                            (minAngle < maxAngle && targetRotZAngle > minAngle && targetRotZAngle < maxAngle); 
        if (inAngleLimit)
        {
            bodyCenterTransform.rotation = targetRot;
        }

        return tensionV.normalized * currTension;
    }

    public void Fire()
    {
        currArrow.transform.SetParent(null);
        float forcePercent = (handTransform.localPosition.x - handStartLocPos.x) / handMoveDist;
        currArrow.Shoot(-currArrow.transform.right * shootForce * forcePercent);
        CreateArrow();

        handTransform.localPosition = handStartLocPos;
        bodyCenterTransform.rotation = bodyStartRot;
    }
}