using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinView : MonoBehaviour
{
    [SerializeField] private GameObject adquiredCoin;

    private Animator anim;
    private GameObject coinSound;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("Coin_Idle");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Colision");
            coinSound = Instantiate(adquiredCoin);
            anim.Play("Coin_Adquired");
            Destroy(coinSound, 2);
        }

    }



}
