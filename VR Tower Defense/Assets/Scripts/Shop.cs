using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    public TurretBlueprint standardTurret;
    public TurretBlueprint anotherTurret;

    BuildManager buildManager;
    
    void Start()
    {
        buildManager = BuildManager.instance;
        GetComponent<Image>().enabled = !GetComponent<Image>().enabled;
        transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.activeSelf);
        transform.GetChild(1).gameObject.SetActive(!transform.GetChild(1).gameObject.activeSelf);
    }

    private void Update()
    {
        if (Input.GetButtonDown("X"))
        {
            Debug.Log("X pressed");
            GetComponent<Image>().enabled = !GetComponent<Image>().enabled;
            transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.activeSelf);
            transform.GetChild(1).gameObject.SetActive(!transform.GetChild(1).gameObject.activeSelf);
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
