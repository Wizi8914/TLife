using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public GameObject blue;
    public GameObject blueLight;

    private bool clicked;

    private void OnMouseDown()
    {
        if (!clicked)
        {
            GameObject go = Instantiate(blueLight, blue.transform.position, Quaternion.identity);
            Destroy(blue);
            clicked = true;
        }
    }
}
