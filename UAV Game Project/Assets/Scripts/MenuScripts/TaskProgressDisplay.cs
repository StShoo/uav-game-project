using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskProgressDisplay : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    private Shoot shoot;
    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        shoot = FindObjectOfType<Shoot>();
    }

    
    void Update()
    {
        textMeshPro.text = string.Format("{0} / 5", shoot.destroyedTanksCounter);
    }
}
