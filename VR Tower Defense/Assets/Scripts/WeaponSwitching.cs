using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;

    void Start()
    {
        SelectWeapon();
    }
    
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;
        if(Input.GetButtonDown("Y") && !PauseMenu.paused)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }
        SelectWeapon();
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if(i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
                //weapon.gameObject.GetComponent<Gun>().fireCountdown = 0;
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
