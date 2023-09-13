using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private MainManager Manager;

    private void Start()
    {
        Manager = GameObject.Find("MainManager").GetComponent<MainManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        if(Manager != null)
        {
            Manager.GameOver();
        } else
        {
            Debug.Log("Deathzone no manager reference");
        }
        
    }
}
