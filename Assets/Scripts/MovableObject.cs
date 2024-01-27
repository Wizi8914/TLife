using System.Collections;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.U2D.Animation;

public class MovableObject : MonoBehaviour
{
    public bool isMovable;

    public GameObject[] snapList;

    private Vector3 offset;
    private Vector3 originalPos;
    
    private float snapDistance = 1f;
    private float moveToOriginSpeed = 100f;
    private bool isMovingToOrigin = false;
    
    public GameObject fusionObject; // Fusion object to instantiate when the object is snapped

    private void Start()
    {
        originalPos = transform.position;
    }

    private void OnMouseDown()
    {
        if (!isMovable || isMovingToOrigin) return;
        offset = gameObject.transform.position - MouseWorldPos2D();
    }

    private void OnMouseUp()
    {
        if (!isMovable || isMovingToOrigin) return;
        

        //check if the object is near the snap
        foreach (var snap in snapList)
        {
            if (Vector3.Distance(transform.position, snap.transform.position) < snapDistance)
            {
                // Destroy the object and the snap
                Destroy(gameObject);
                Destroy(snap);

                // Instantiate the fusion object
                Instantiate(fusionObject, snap.transform.position, snap.transform.rotation);
                return;
            }
        }
        
        StartCoroutine(MoveToOriginalPosition());

    }

    private void OnMouseDrag()
    {
        if (!isMovable || isMovingToOrigin) return;
        transform.position = MouseWorldPos2D() + offset;
    }

    private Vector3 MouseWorldPos2D()
    {
        var mouseScreenPos = Input.mousePosition; // Mouse position in screen coordinates
        mouseScreenPos.z = Camera.main.ScreenToWorldPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }


    private IEnumerator MoveToOriginalPosition()
    {
        isMovingToOrigin = true;

        while (transform.position != originalPos)
        {
            float step = moveToOriginSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, originalPos, step);
            yield return null;
        }
        isMovingToOrigin = false;

        transform.position = originalPos; // Verify if the object is exactly at originalPos
    }
}
