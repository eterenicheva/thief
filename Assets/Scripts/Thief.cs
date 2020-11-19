using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private float _speed;


    private void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        if (direction != 0)
        {
            Flip(direction);
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }
    }

    private void Flip(float direction)
    {
        if (direction > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (direction < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
