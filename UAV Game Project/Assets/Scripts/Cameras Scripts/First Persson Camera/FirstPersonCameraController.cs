using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCameraController : MonoBehaviour
{
    public float lookRoteSpeed = 30f;
    public float xMaxRotation = 75f;
    public float xMinRotation = 10f;
    
    private Vector2 lookInput, screenCentre, mouseDistance;
    
    
    void Awake()
    {
        screenCentre.x = Screen.width * .5f;
        screenCentre.y = Screen.height * .5f;

        Cursor.lockState = CursorLockMode.Confined;
        
    }

    
    void FixedUpdate()
    {
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, .5f);

        mouseDistance.x = (lookInput.x - screenCentre.x) / screenCentre.y;
        mouseDistance.y = (lookInput.y - screenCentre.y) / screenCentre.y;

        Quaternion currentRotation = transform.rotation;

        if (currentRotation.eulerAngles.x > xMaxRotation)
        {
            if (mouseDistance.y < 0)
            {
                RotateWithoutX();

            }
            else
            {
                FreeRotate();
            }

        }else if (currentRotation.eulerAngles.x < xMinRotation)
        {
            if (mouseDistance.y > 0)
            {
                RotateWithoutX();
            }
            else
            {
                FreeRotate();
            }
        }
        else
        {
            FreeRotate();
        }
        
        Quaternion newRotation = transform.rotation;
        newRotation.eulerAngles = new Vector3(newRotation.eulerAngles.x, newRotation.eulerAngles.y, 0);
        transform.rotation = newRotation;
    }

    private void FreeRotate()
    {
        transform.Rotate(-mouseDistance.y * lookRoteSpeed * Time.deltaTime,
            mouseDistance.x * lookRoteSpeed * Time.deltaTime, 0,Space.Self);
    }

    private void RotateWithoutX()
    {
        transform.Rotate(0,
            mouseDistance.x * lookRoteSpeed * Time.deltaTime, 0,Space.Self);
    }
}
