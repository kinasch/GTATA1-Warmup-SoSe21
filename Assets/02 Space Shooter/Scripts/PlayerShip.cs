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
        public MovementObject movementObject;
        public SpriteRenderer shipSprite;

        private static AsteroidGameController _runGameController;
        private float invincibilityTime = 1f;
        private bool isInvincible = false;
        private int hp;

        private void Start()
        {
            hp = startHitPoints;
            if (_runGameController == null) _runGameController = FindObjectOfType<AsteroidGameController>();
        }

        private void LateUpdate()
        {
            if (_runGameController.PlayerIntersection(shipSprite) && !isInvincible)
            {
                hp--;

                healthBar.reduce(hp, startHitPoints);

                StartCoroutine(Invincibility());
            }
        }

        private IEnumerator Invincibility()
        {
            isInvincible = true;

            shipSprite.color = new Color(255, 255, 255, 0.5f);

            yield return new WaitForSeconds(invincibilityTime);

            shipSprite.color = new Color(255, 255, 255, 1f);

            isInvincible = false;
        }

        public int GetHitPoints()
        {
            return hp;
        }
    }
}