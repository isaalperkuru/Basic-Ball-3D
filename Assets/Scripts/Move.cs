using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject deadEffect;
    Rigidbody rigidbody;
    private Vector3 movement;
    private TimeManager2 timeManager;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        timeManager = FindObjectOfType<TimeManager2>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeManager.gameOver == false && timeManager.isFinished == false)
        {
            MoveThePlayer();
        }

        if (timeManager.gameOver || timeManager.isFinished)
        {
            rigidbody.isKinematic = true;
        }
    }

    private void MoveThePlayer()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        movement = new Vector3(x, 0f, z);
        rigidbody.AddForce(movement);
        //transform.position += movement;
    }
    private void OnDisable()
    {
        Instantiate(deadEffect, transform.position, transform.rotation);
    }
}
