using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float stopDistance = 3f;
    [SerializeField] private GameObject deadEffect;

    private Transform target;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
            target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);

            distance = Vector3.Distance(transform.position, target.position);

            if (distance > stopDistance)
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            TimeManager2 timeManager = FindObjectOfType<TimeManager2>();
            timeManager.gameOver = true;
        }
    }
    private void OnDisable()
    {
        Instantiate(deadEffect, transform.position, transform.rotation);
    }
}
