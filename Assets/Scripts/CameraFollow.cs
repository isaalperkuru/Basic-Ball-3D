using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float followSpeed = 5f;
    private Vector3 offsetVector;
    // Start is called before the first frame update
    void Start()
    {
        offsetVector = CalculateOffset(target);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            MoveTheCamera();
        }
    }

    private void MoveTheCamera()
    {
         Vector3 playerToMove = target.position + offsetVector;
         transform.position = Vector3.Lerp(transform.position, playerToMove, followSpeed * Time.deltaTime);
         transform.LookAt(target.transform.position);
    }

    private Vector3 CalculateOffset(Transform newTarget)
    {
        return transform.position - newTarget.position;
    }
}
