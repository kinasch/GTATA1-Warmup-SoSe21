using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

public class UpgradeController : MonoBehaviour
{
    [SerializeField] private Transform laserPrefab;
    [SerializeField] private Upgrade upgradePrefab;
    [SerializeField] private PlayerShip playerShip;
    
    private List<Upgrade> activeUpgrades;

    private void Start()
    {
        laserPrefab.transform.localScale = new Vector3(1, 1, 1);
        activeUpgrades = new List<Upgrade>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.value*10000 > 9998f)
        {
            SpawnUpgrade(upgradePrefab);
        }
    }

    private void SpawnUpgrade(Upgrade prefab)
    {
        var upgrade = Instantiate(prefab, this.transform) as Upgrade;
        upgrade.transform.position = new Vector3(Random.Range(-7,7),Random.Range(-4,4),0);
        activeUpgrades.Add(upgrade);
    }

    public void PlayerIntersection(SpriteRenderer player)
    {
        // go through all asteroids, check if they intersect with the player and stop after the first
        var upgrade=activeUpgrades.FirstOrDefault(x => x.GetComponent<SpriteRenderer>().bounds.Intersects(player.bounds));
            
        // premature exit: the player hasn't hit anything
        if (upgrade == null)
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
        }

        activeUpgrades.Remove(upgrade);
        Destroy(upgrade.gameObject);
    }
}
