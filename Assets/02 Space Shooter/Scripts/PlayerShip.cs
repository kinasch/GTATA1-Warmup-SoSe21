using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts
{
    /// <summary>
    /// FORMER: Container component to keep references to common components on a ship
    ///
    /// This class now controls the HitPoints of the Player
    /// </summary>
    public class PlayerShip : MonoBehaviour
    {
        [SerializeField] private int startHitPoints = 50;
        [SerializeField] private HealthBar healthBar;
        [SerializeField] private UpgradeController upgradeController;
        public MovementObject movementObject;
        public SpriteRenderer shipSprite;

        private static AsteroidGameController _runGameController;

        // Time the ship can not get any damage in seconds.
        private float invincibilityTime = 1f;

        // Determines if the ship can take damage.
        private bool isInvincible = false;

        // Stores the ship's hit points, the amount of times it can be it before the game ends.
        private int hp;

        private void Start()
        {
            hp = startHitPoints;
            if (_runGameController == null) _runGameController = FindObjectOfType<AsteroidGameController>();
        }

        private void LateUpdate()
        {
            // Checks after every Update if the player ship hit any asteroid.
            if (_runGameController.PlayerIntersection(shipSprite) && !isInvincible)
            {
                // The ship's hit points are reduced, the health bar is updated and the ship is invincible for a set amount of time.
                hp--;
                healthBar.reduce(hp, startHitPoints);
                StartCoroutine(Invincibility());
            }

            upgradeController.PlayerIntersection(shipSprite);
        }

        /// <summary>
        /// Disables the ability to take damage from any asteroid for a set amount of time.
        /// </summary>
        private IEnumerator Invincibility()
        {
            isInvincible = true;

            shipSprite.color = new Color(255, 255, 255, 0.5f);

            yield return new WaitForSeconds(invincibilityTime);

            shipSprite.color = new Color(255, 255, 255, 1f);

            isInvincible = false;
        }


        /// <returns>ship hit points</returns>
        public int GetHitPoints()
        {
            return hp;
        }

        /// <summary>
        /// This function increases the current hit points, with a maximum value of the hit points at the beginning of the game.
        /// </summary>
        /// <param name="additionalHP"></param>
        public void AddToHitPoints(int additionalHP)
        {
            hp += additionalHP;
            hp = hp > startHitPoints ? startHitPoints : hp;
            healthBar.reduce(hp, startHitPoints);
        }
    }
}