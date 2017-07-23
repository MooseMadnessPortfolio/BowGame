using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(LineRenderer), typeof(KozakScript))]
public class InputHandlerScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public float dragLineMaxSize;

    private LineRenderer dragLine;
    private Vector3 dragStartPos;
    private KozakScript kozak;

    private void Awake()
    {
        dragLine = GetComponent<LineRenderer>();
        kozak = GetComponent<KozakScript>();
    }

    private void SetDragLine(Vector3 start, Vector3 end)
    {
        start.z = -1;
        end.z = -1;
        dragLine.SetPosition(0, start);
        dragLine.SetPosition(1, end);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragLine.enabled = true;
        SetDragLine(dragStartPos, dragStartPos);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 tensionV = Camera.main.ScreenToWorldPoint(Input.mousePosition) - dragStartPos;
        Vector3 currTension = kozak.SetTension(tensionV);
        SetDragLine(dragStartPos, dragStartPos + (currTension / kozak.maxTension) * dragLineMaxSize);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        kozak.Fire();
        dragLine.enabled = false;
    }
}