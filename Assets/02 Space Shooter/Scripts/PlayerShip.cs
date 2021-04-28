using System;
using System.Collections;
using UnityEngine;

namespace Scripts
{
    /// <summary>
    /// Container component to keep references to common components on a ship
    /// </summary>
    internal class PlayerShip : MonoBehaviour
    {
        private static AsteroidGameController _runGameController;
        public MovementObject movementObject;
        public SpriteRenderer shipSprite;
        [SerializeField] private int hitpoints=50;
        private float invincibilityTime = 1.2f;
        private bool isInvincible = false;

        private void Start()
        {
            if (_runGameController == null) _runGameController = FindObjectOfType<AsteroidGameController>();
        }
        
        private void LateUpdate()
        {
            if (_runGameController.PlayerIntersection(shipSprite) && !isInvincible)
            {
                hitpoints--;
                Debug.Log("HP: "+hitpoints);

                StartCoroutine(Invincibility());
            }
        }

        private IEnumerator Invincibility()
        {
            Debug.Log("Player turned invincible!");
            isInvincible = true;
            
            shipSprite.color = new Color(255,255,255,0.5f);

            yield return new WaitForSeconds(invincibilityTime);
            
            shipSprite.color = new Color(255,255,255,1f);

            isInvincible = false;
            Debug.Log("Player is no longer invincible!");
        }
    }
}