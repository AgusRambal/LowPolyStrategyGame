using System.Collections.Generic;
using UnityEngine;

public class MarineRotation : MonoBehaviour 
{
    public List<Transform> transformsList = new List<Transform>();
    public int ID;
    public List<bool> canCustomize = new List<bool>();

    private Transform marineTransform;
    private Vector3 lastMousePosition;
    
    private void Awake()
    {
        marineTransform = transform;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 mouseDelta = lastMousePosition - Input.mousePosition;
            
            mouseDelta.x = Mathf.Clamp(mouseDelta.x, -200, +200);

            float rotateSpeed = .2f;

            marineTransform.localEulerAngles += new Vector3(0f, mouseDelta.x, 0f) * rotateSpeed;

            float rotationXMin = -7f;
            float rotationXMax = +10f;
            float localEulerAnglesX = marineTransform.localEulerAngles.x;

            if (localEulerAnglesX > 180)
            {
                localEulerAnglesX -= 360f;
            }

            float rotationX = Mathf.Clamp(localEulerAnglesX, rotationXMin, rotationXMax);

            marineTransform.localEulerAngles = new Vector3(rotationX, marineTransform.localEulerAngles.y, marineTransform.localEulerAngles.z);
        }
        
        lastMousePosition = Input.mousePosition;
    }
}