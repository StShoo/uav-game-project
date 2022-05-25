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
    public AudioSource rocketShootSound;
    public AudioSource explosionSound;

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
            StartCoroutine(WaitBeforeExplode(hit));
        }
    }

    private void Kill(GameObject target)
    {
        Destroy(target);
    }

    private IEnumerator WaitBeforeExplode(RaycastHit hit)
    {
        rocketShootSound.Play();
        yield return new WaitForSeconds(1);
        if (hit.transform.CompareTag("Enemy"))
        {
            Kill(hit.transform.gameObject);
        }
        explosionSound.Play();
    }
}
