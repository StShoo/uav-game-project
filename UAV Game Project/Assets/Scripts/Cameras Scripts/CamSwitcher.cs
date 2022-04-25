using UnityEngine;

public class CamSwitcher : MonoBehaviour
{
    public GameObject thirdPersonCam;
    public GameObject firstPersonCam;
    
    private bool isThirdPersonCamActive;

    void Start()
    {
        ActivateThirdPersonCamera();
    }

    void Update()
    {
        if (Input.GetButtonDown("CameraSwitch"))
        {
            if (isThirdPersonCamActive)
            {
                ActivateFirstPersonCamera();
            }
            else
            {
                ActivateThirdPersonCamera();
            }
        }
    }

    private void ActivateThirdPersonCamera()
    {
        thirdPersonCam.SetActive(true);
        firstPersonCam.SetActive(false);

        isThirdPersonCamActive = true;
    }
    
    private void ActivateFirstPersonCamera()
    {
        firstPersonCam.SetActive(true);
        thirdPersonCam.SetActive(false);

        isThirdPersonCamActive = false;
    }
}