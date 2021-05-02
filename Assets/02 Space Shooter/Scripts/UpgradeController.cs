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

    /// <summary>
    /// Reset the laserPrefab to the original Scale and create a new List containing all active Upgrades.
    /// </summary>
    private void Start()
    {
        laserPrefab.transform.localScale = new Vector3(1, 1, 1);
        activeUpgrades = new List<Upgrade>();
    }

    // Spawn an Upgrade every frame with a chance of 0.02%.
    void Update()
    {
        if (Random.value * 10000 > 9998f)
        {
            SpawnUpgrade(upgradePrefab);
        }
    }

    /// <summary>
    /// Instantiates an Upgrade using the given prefab somewhere on the scene.
    /// Add this Upgrade to the active upgrades, so it is available to the player.
    /// </summary>
    /// <param name="prefab"></param>
    private void SpawnUpgrade(Upgrade prefab)
    {
        var upgrade = Instantiate(prefab, this.transform) as Upgrade;
        upgrade.transform.position = new Vector3(Random.Range(-7, 7), Random.Range(-4, 4), 0);
        activeUpgrades.Add(upgrade);
    }

    /// <summary>
    /// This method is very similar to the method LaserInteraction in AsteroidGameController.
    ///
    /// Checks if the boundaries of the player sprite intersect with the boundaries of any Upgrade Sprite.
    /// If they do, apply the intersecting Upgrade.
    /// </summary>
    /// <param name="player"></param>
    public void PlayerIntersection(SpriteRenderer player)
    {
        // go through all asteroids, check if they intersect with the player and stop after the first
        var upgrade =
            activeUpgrades.FirstOrDefault(x => x.GetComponent<SpriteRenderer>().bounds.Intersects(player.bounds));

        // premature exit: the player hasn't hit anything
        if (upgrade == null)
        {
            return;
        }

        switch (upgrade.GetEffect())
        {
            // Bigger Laser Upgrade enlarges the laser prefab scale.
            case ("BIG"):
                laserPrefab.transform.localScale *= 1.2f;
                break;
            // Heal Upgrade increases the player's current hit points, with the maximum being the starting hit points.
            case ("HEAL"):
                playerShip.AddToHitPoints(5);
                break;
        }

        // Remove the upgrade from the active upgrade list and the scene.
        activeUpgrades.Remove(upgrade);
        Destroy(upgrade.gameObject);
    }
}