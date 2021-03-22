using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour
{
    Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void OnMouseDown()
    {
        gameObject.layer = 2;
    }

    private void OnMouseUp()
    {
        gameObject.layer = 0;
    }

    private void OnMouseDrag()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100)) {
            transform.position = hit.point;
        }
    }
}
