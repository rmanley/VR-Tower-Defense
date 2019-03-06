using UnityEngine;

public class BuildManager : MonoBehaviour
{

    #region Singleton
    public static BuildManager instance;
    private PlayerStats playerStats;

    void Awake()
    {
        instance = this;
        playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
    }
    #endregion

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return playerStats.money >= turretToBuild.cost; } }

    public void BuildTurretOn(Node node)
    {
        if(playerStats.money < turretToBuild.cost)
        {
            MessageManager.instance.MoneyMessage();
            return;
        }

        playerStats.money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;

    }
}
