using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if (other.gameObject.tag == "Player")
        {
            TimeManager2 timeManager = FindObjectOfType<TimeManager2>();
            timeManager.gameOver = true;
        }
    }
}
