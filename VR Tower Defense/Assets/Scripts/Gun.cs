//Attach this script to the firePoint

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
                StartCoroutine("Shoot");
            }
        }
        else if(fireMode.Equals(FireMode.Auto))
        {
            if(Input.GetButton("R1"))
            {
                StartCoroutine("Shoot");
            }
        }
    }

    //can override this for different shoot types
    public virtual IEnumerator Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);
        yield return null;
    }
}
