using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class ClickableObject : MonoBehaviour
{
    public Sprite newSprite;

    [SerializeField]
    private bool clicked = false;

    private void OnMouseDown()
    {
        if (clicked) return;

        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        
        clicked = true;
    }
}
