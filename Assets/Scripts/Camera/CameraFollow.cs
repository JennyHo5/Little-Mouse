using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Follow Speed")]
    [SerializeField] private float followSpeed = 0.25f;
    [Header("Target")]
    [SerializeField]private Transform target;

    private Vector3 velocity = Vector3.zero;
    private void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -10.0f);
        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, followSpeed * Time.deltaTime);
    }
}
