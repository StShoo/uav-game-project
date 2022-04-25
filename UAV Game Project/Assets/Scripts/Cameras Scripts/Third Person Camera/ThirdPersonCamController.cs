using UnityEngine;

public class ThirdPersonCamController : MonoBehaviour
{
    public Transform thirdPersonCam;
    
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(thirdPersonCam.position, desiredPosition, smoothSpeed);
        
        thirdPersonCam.position = smoothedPosition; 
        
        thirdPersonCam.rotation = transform.rotation;
    }
}
