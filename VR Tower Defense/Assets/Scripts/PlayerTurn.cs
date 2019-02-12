using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour {

    public float speed = 1f;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("RJH");
        float v = Input.GetAxis("RJV");

        transform.Rotate(0f, h * speed, 0f);
    }
}
