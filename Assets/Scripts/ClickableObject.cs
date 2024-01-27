using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class ClickableObject : MonoBehaviour
{
    private Sprite startSprite;
    public Sprite newSprite;

    [SerializeField]
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
            clicked = false;
        } 
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
            clicked = true;
        }

    }
}
