using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage = 1f;
    public float range = 100f;

    public Camera firstPersonCam;
    private GameObject target;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootRocket();
        }
    }

    private void ShootRocket()
    {
        RaycastHit hit;
        if (Physics.Raycast(firstPersonCam.transform.position, firstPersonCam.transform.forward, out hit))
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                Debug.Log(hit.transform.tag + "!!!!");
            }
            Debug.Log(hit.transform.tag);
        }
    }

    private void Kill(GameObject target)
    {
        Destroy(target);
    }
}
