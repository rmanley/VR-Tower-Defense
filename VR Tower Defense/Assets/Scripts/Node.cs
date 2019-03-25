using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
        positionOffset = new Vector3(0, transform.lossyScale.y/2, 0);
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    public void Update()
    {
        if (!Shop.shopOpen)
        {
            rend.material.color = Color.white;
        }
    }

    void HoverPress()
    {
        if (!buildManager.CanBuild)
            return;

        if (turret != null)
        {
            Debug.Log("Can't build there! - TODO: Display on Screen");
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    public void HoverIn()
    {
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    public void HoverOut()
    {
        rend.material.color = Color.white;
    }

}
