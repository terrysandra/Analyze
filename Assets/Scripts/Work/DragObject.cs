using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour
{
    public float speed = 10f;
    private void OnMouseDrag()
    {
        if (EventSystem.current.IsPointerOverGameObject()) { return; }
        float x = Input.GetAxis("Mouse Y");
        float y = Input.GetAxis("Mouse X");
        transform.Rotate(x * speed, -y * speed, 0, Space.World);
    }
}
