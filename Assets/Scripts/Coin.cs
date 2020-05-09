using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip coinPickUpSFX;
    [SerializeField] int coinPoints = 50;
    bool pickedUpCoin = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!pickedUpCoin)
        {
            AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
            FindObjectOfType<GameSession>().AddToScore(coinPoints);
            Destroy(gameObject);
            pickedUpCoin = true;
        }
    }
}
