using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public static bool shopOpen = false;

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
        GetComponent<Image>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.activeSelf);
        transform.GetChild(1).gameObject.SetActive(!transform.GetChild(1).gameObject.activeSelf);

        buildManager.SelectTurretToBuild(standardTurret);
    }

    private void Update()
    {
        if (Input.GetButtonDown("R2") && !PauseMenu.paused)
        {
            shopOpen = !shopOpen;
            GetComponent<Image>().enabled = shopOpen;
            transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.activeSelf);
            transform.GetChild(1).gameObject.SetActive(!transform.GetChild(1).gameObject.activeSelf);
            SelectStandardTurret();
        }

        if (shopOpen && !PauseMenu.paused)
        {
            int select = (int)Input.GetAxis("RJV");
            switch (select)
            {
                case -1: SelectStandardTurret(); break;
                case  1: SelectMissileLauncher(); break;
            }
        }
        
    }

    public void SelectStandardTurret()
    {
        var image = transform.GetChild(1).GetComponent<Image>();
        image.canvasRenderer.SetAlpha(0.5f);
        image = transform.GetChild(0).GetComponent<Image>();
        image.canvasRenderer.SetAlpha(1f);
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        var image = transform.GetChild(0).GetComponent<Image>();
        image.canvasRenderer.SetAlpha(0.5f);
        image = transform.GetChild(1).GetComponent<Image>();
        image.canvasRenderer.SetAlpha(1f);
        buildManager.SelectTurretToBuild(missileLauncher);
    }

}
