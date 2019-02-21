using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public static bool shopOpen = false;

    public TurretBlueprint standardTurret;
    public TurretBlueprint anotherTurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
        GetComponent<Image>().enabled = !GetComponent<Image>().enabled;
        transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.activeSelf);
        transform.GetChild(1).gameObject.SetActive(!transform.GetChild(1).gameObject.activeSelf);

        buildManager.SelectTurretToBuild(standardTurret);
    }

    private void Update()
    {
        if (Input.GetButtonDown("L1"))
        {
            shopOpen = !shopOpen;
            GetComponent<Image>().enabled = !GetComponent<Image>().enabled;
            transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.activeSelf);
            transform.GetChild(1).gameObject.SetActive(!transform.GetChild(1).gameObject.activeSelf);
        }

        if (shopOpen)
        {
            int select = (int)Input.GetAxis("RJV");
            switch (select)
            {
                case -1: SelectStandardTurret(); break;
                case  1: SelectAnotherTurret(); break;
            }
        }
        
    }

    public void SelectStandardTurret()
    {
        Debug.Log("standard turet selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectAnotherTurret()
    {
        Debug.Log("Another turret selected");
        buildManager.SelectTurretToBuild(anotherTurret);
    }

}
