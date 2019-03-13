﻿//Attach this script to the firePoint

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FireMode
{
    Semi, Auto
}

public class Gun : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float range;
    public float fireRate;
    private float fireCountdown = 0f;
    public FireMode fireMode = FireMode.Semi;

    // Start is called before the first frame update
    //void Start()
    //{
    //}

    // Update is called once per frame
    void Update()
    {
        if(fireMode.Equals(FireMode.Semi))
        {
            if (Input.GetButtonDown("R1"))
            {
                if (fireCountdown <= 0f)
                {
                    StartCoroutine("Shoot");
                    fireCountdown = 1f / fireRate;
                }
            }
        }
        else if(fireMode.Equals(FireMode.Auto))
        {
            if(Input.GetButton("R1"))
            {
                StartCoroutine("Shoot");
            }
        }

        fireCountdown -= Time.deltaTime;
    }

    //can override this for different shoot types
    public virtual IEnumerator Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);
        yield return null;
    }
}
