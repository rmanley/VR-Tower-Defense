using UnityEngine;

public class BuildManager : MonoBehaviour {

    #region Singleton
    public static BuildManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret Built! Money left: " + PlayerStats.Money);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;

    }
}
