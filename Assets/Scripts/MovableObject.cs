using System.Collections;
using UnityEngine;
using System.Linq;
using UnityEditor;


[RequireComponent(typeof(PolygonCollider2D))]
public class MovableObject : MonoBehaviour
{
    [Header("Movement")]
    public bool isMovable = true;
    public bool isLockOnSnap = false;
    private bool isLocked = false;
    public bool moveDirectionX = false;
    public bool moveDirectionY = false;
    public string snapPositionName;
    public GameObject[] snapableObjectList;
    private Vector2 mousePosTmp;

    [Header("Fusion")]
    public bool isFusionNeeded;
    public GameObject fusionObject; // Fusion object to instantiate when the object is snapped

    [Header("Add one more Prefab to spawn")]
    //Si sprite en plus à positionner après la fusion
    public GameObject prefabToSpawn;
    public GameObject prefabPosition;
    private Vector2 prefabPositionOriginalPos;

    private Vector3 offset;
    private Vector3 originalPos;

    private float snapDistance = 1f;
    private float moveToOriginSpeed = 100f;
    private bool isMovingToOrigin = false;
    

    private void Start()
    {
        originalPos = transform.position;
        if (prefabToSpawn != null)
        {
            prefabPositionOriginalPos = prefabPosition.transform.position;
        }
    }

    private void OnMouseDown()
    {
        if (isLocked) return;
        //Security checks
        if (snapableObjectList.Length == 0)
        {
            Debug.Log("No snapList set for " + gameObject.name);
        }

        if (snapPositionName == null)
        {
            Debug.Log("No snapPositionName set for " + gameObject.name);
        }

        if (!isMovable || isMovingToOrigin) return;
        offset = gameObject.transform.position - MouseWorldPos2D();
    }

    private void OnMouseUp()
    {
        if (!isLocked)
        {
            if (!isMovable || isMovingToOrigin) return;

            GameObject snapTmp;

            //check if the object is near the snap
            foreach (var snap in snapableObjectList)
            {
                snapTmp = snap;
                // Verify if the snap is a clone of a prefab
                if (snap.scene.name == null)
                {
                    if (GameObject.Find($"S{snap.name}") != null)
                    {
                        snapTmp = GameObject.Find($"S{snap.name}");
                    }

                    if (GameObject.Find($"{snap.name}(Clone)") != null)
                    {
                        snapTmp = GameObject.Find($"{snap.name}(Clone)");
                    }
                }

                if (Vector3.Distance(transform.position, snapTmp.transform.position) < snapDistance)
                {
                    if (isFusionNeeded)
                    {
                        if (fusionObject != null)
                        {
                            // Instantiate the fusion object
                            GameObject go = Instantiate(fusionObject, GameObject.Find(snapPositionName).transform.position, Quaternion.identity);
                        }
                        if (prefabToSpawn != null)
                        {
                            Instantiate(prefabToSpawn, prefabPositionOriginalPos, Quaternion.identity);
                        }
                        if (fusionObject != null)
                        {
                            // Destroy the object and the snap
                            Destroy(snapTmp);
                            Destroy(gameObject);
                        }

                        return;
                    }
                    else
                    {
                        gameObject.transform.SetPositionAndRotation(GameObject.Find(snapPositionName).transform.position, Quaternion.identity);
                        if (isLockOnSnap)
                        {
                            isLocked = true;
                        }
                        return;
                    }
                }
            }

            StartCoroutine(MoveToOriginalPosition());
        }
        else return;
    }

    private void OnMouseDrag()
    {
        if (isLocked) return;
        if (!isMovable || isMovingToOrigin) return;
        transform.position = MouseWorldPos2D() + offset;
    }

    private Vector3 MouseWorldPos2D()
    {
        var mouseScreenPos = Input.mousePosition; // Mouse position in screen coordinates
        mouseScreenPos.z = Camera.main.ScreenToWorldPoint(transform.position).z;
        if(moveDirectionX)
        {
            mousePosTmp = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            mousePosTmp = new Vector2(mousePosTmp.x, gameObject.transform.position.y);
            return mousePosTmp;

        } 
        else if(moveDirectionY)
        {
            mousePosTmp = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            mousePosTmp = new Vector2(gameObject.transform.position.x, mousePosTmp.y);
            return mousePosTmp;
        } 
        else
        {
            return Camera.main.ScreenToWorldPoint(mouseScreenPos);
        }
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
