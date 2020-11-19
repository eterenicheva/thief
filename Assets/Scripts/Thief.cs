using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private float _speed;


    private void Update()
    {
        float key = Input.GetAxis("Horizontal");
        if (key != 0)
        {
            Flip(key);
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }
    }

    private void Flip(float key)
    {
        if (key > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (key < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
