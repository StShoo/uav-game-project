using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    public float forwardSpeed = 25f, accelerationSpeed = 5f, flightDirectionSpeed = 30f, rotationSpeed = 20f;
    private float activeForwardSpeed, activeAcceleration, activeFlightDirection, activeRotationSpeed;
    private float forwardAcceleration = 2.5f, changeDirectionAcceleration = 2f, rotationAcceleration = 2f;
    
    void FixedUpdate()
    {
        CalculateActiveForwardSpeed();
        CalculateActiveDirection();
        CalculateActiveRotationSpeed();
        
        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        
        transform.Rotate(activeFlightDirection * Time.deltaTime,0,activeRotationSpeed * Time.deltaTime,
            Space.Self);
    }

    private void CalculateAcceleration()
    {
        activeAcceleration = Mathf.Lerp(activeAcceleration, Input.GetAxisRaw("Acceleration") * accelerationSpeed,
            forwardAcceleration * Time.deltaTime);
    }
    
    private void CalculateActiveForwardSpeed()
    {
        CalculateAcceleration();
        
        activeForwardSpeed = activeAcceleration + forwardSpeed;
    }

    private void CalculateActiveDirection()
    {
        activeFlightDirection = Mathf.Lerp(activeFlightDirection, Input.GetAxisRaw("Vertical") * flightDirectionSpeed,
            changeDirectionAcceleration * Time.deltaTime);
    }

    private void CalculateActiveRotationSpeed()
    {
        activeRotationSpeed = Mathf.Lerp(activeRotationSpeed, Input.GetAxis("Horizontal") * rotationSpeed,
            rotationAcceleration * Time.deltaTime);
    }
}
