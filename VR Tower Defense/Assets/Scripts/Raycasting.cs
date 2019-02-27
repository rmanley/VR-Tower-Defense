using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{

    public static RaycastHit hit;
    bool first;
    Collider node;

    // Start is called before the first frame update
    void Start()
    {
        first = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
        {
            if (Shop.shopOpen)
            {
                if (hit.collider.name.Contains("Node"))
                {
                    if (first) node = hit.collider;
                    first = false;
                    if (node.name != hit.collider.name)
                    {
                        node.SendMessage("HoverOut");
                    }
                    node = hit.collider;
                    //Debug.Log(node.name);
                    node.SendMessage("HoverIn");
                    if (Input.GetButtonDown("B"))
                    {
                        node.SendMessage("HoverPress");
                    }
                }
            }
            else
            {
                node.SendMessage("HoverOut");
            }
        }
    }
}
