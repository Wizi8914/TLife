using System.Collections;
using UnityEngine;
using System.Linq;
using UnityEditor;


[RequireComponent(typeof(PolygonCollider2D))]
public class MovableObject : MonoBehaviour
{
    public bool isMovable = true;

    public GameObject[] snapList;
    public string snapPositionName;

    public GameObject leftSprite;
    public GameObject leftSpritePosition;
    private Vector2 leftSpritePositionOriginalPos;

    private Vector3 offset;
    private Vector3 originalPos;
    
    private float snapDistance = 1f;
    private float moveToOriginSpeed = 100f;
    private bool isMovingToOrigin = false;
    
    public GameObject fusionObject; // Fusion object to instantiate when the object is snapped

    private void Start()
    {
        originalPos = transform.position;
        if (leftSprite != null)
        {
            leftSpritePositionOriginalPos = leftSpritePosition.transform.position;
        }
    }

    private void OnMouseDown()
    {
        //Security checks
        if (snapList.Length == 0)
        {
            Debug.LogError("No snapList set for " + gameObject.name);
            return;
        }

        if (snapPositionName == null)
        {
            Debug.LogError("No snapPositionName set for " + gameObject.name);
            return;
        }

        if (fusionObject == null)
        {
            Debug.LogError("No fusionObject set for " + gameObject.name);
            return;
        }

        if (!isMovable || isMovingToOrigin) return;
        offset = gameObject.transform.position - MouseWorldPos2D();
    }

    private void OnMouseUp()
    {
        if (!isMovable || isMovingToOrigin) return;

        var indexedList = snapList.Select((element, index) => new { Index = index, Element = element }); // Index the snapList

        GameObject verifiedSnap; // Create a temporary variable to store the snap for a better flexibility

        //check if the object is near the snap
        foreach (var snap in indexedList)
        {
            verifiedSnap = snap.Element;

            // Verify if the snap is a clone of a prefab
            if (verifiedSnap.scene.name == null)
            {
                if (GameObject.Find($"S{verifiedSnap.name}") != null)
                {
                    verifiedSnap = GameObject.Find($"S{verifiedSnap.name}");
                }

                if (GameObject.Find($"{verifiedSnap.name}(Clone)") != null)
                {
                    verifiedSnap = GameObject.Find($"{verifiedSnap.name}(Clone)");
                }
            }

            if (Vector3.Distance(transform.position, verifiedSnap.transform.position) < snapDistance)
            {
               
                // Instantiate the fusion object
                GameObject go = Instantiate(fusionObject, GameObject.Find(snapPositionName).transform.position, Quaternion.identity);
                
                if (leftSprite != null)
                {
                    Debug.Log("leftSprite");
                    Instantiate(leftSprite, leftSpritePositionOriginalPos, Quaternion.identity);
                }
      
                // Destroy the object and the snap
                Destroy(verifiedSnap);
                Destroy(gameObject);
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
