using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField] private int scoreReward = 100;
    [SerializeField] private GameObject deadEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        { 
            FindObjectOfType<ScoreManager>().score += scoreReward;
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            FindObjectOfType<ScoreManager>().score += scoreReward;
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        Instantiate(deadEffect, transform.position, transform.rotation);
    }
}
