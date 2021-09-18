using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private int scorePenatly = 50;
    private bool isColided = false;
    private void OnCollisionEnter(Collision collision)
    {
        if(isColided == false && collision.gameObject.tag == "Player")
        {
            print(collision.gameObject.name);
            GetComponent<MeshRenderer>().material.color = Color.yellow;
            FindObjectOfType<ScoreManager>().score -= scorePenatly;
            isColided = true;
        }
    }
}
