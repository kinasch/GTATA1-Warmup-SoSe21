using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Scripts;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    [SerializeField] private Transform laserPrefab;
    [SerializeField] private Upgrade upgradePrefab;
    [SerializeField] private PlayerShip playerShip;
    
    private List<Upgrade> activeUpgrades;

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 500) > 498)
        {
            SpawnUpgrade(upgradePrefab);
        }
    }

    private void SpawnUpgrade(Upgrade prefab)
    {
        var upgrade = Instantiate(prefab, this.transform) as Upgrade;
        activeUpgrades.Add(upgrade);
    }

    public void PlayerIntersection(SpriteRenderer player)
    {
        // go through all asteroids, check if they intersect with the player and stop after the first
        //var upgrade=activeUpgrades.FirstOrDefault(x => x.GetComponent<SpriteRenderer>().bounds.Intersects(player.bounds));
            
        // premature exit: the player hasn't hit anything
        /*if (upgrade == null)
        {
            return;
        }

        switch (upgrade.GetEffect())
        {
            case ("BIG"):
                laserPrefab.transform.localScale *= 1.2f;
                break;
            case ("HEAL"):
                playerShip.AddToHitPoints(5);
                break;
        }*/
    }
}
