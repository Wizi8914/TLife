using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class ClickableObject : MonoBehaviour
{
    private Sprite startSprite;
    public Sprite newSprite;

    public GameObject[] objectsInside;
    private bool clicked = false;

    private void Start()
    {
        startSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
    }
    private void OnMouseDown()
    {
        if (clicked)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = startSprite;
            if (objectsInside.Length > 0)
            {
                foreach (var obj in objectsInside)
                {
                    obj.transform.SetLocalPositionAndRotation(new Vector3(obj.transform.position.x, obj.transform.position.y, -0.9f), obj.transform.rotation);
                }
            }
            clicked = false;
        } 
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
            if (objectsInside.Length > 0)
            {
                foreach (var obj in objectsInside)
                {
                    obj.transform.SetLocalPositionAndRotation(new Vector3(obj.transform.position.x, obj.transform.position.y, -1.2f), obj.transform.rotation);
                }
            }
            clicked = true;
        }
    }
}
