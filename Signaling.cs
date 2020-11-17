using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _signaling;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            _signaling.Play();
            StartCoroutine(IncreaseVolume());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Thief>(out Thief thief))
        {
            StartCoroutine(DecreaseVolume());
            
        }
    }

    private IEnumerator IncreaseVolume()
    {
        for (float i = 0; i < _signaling.maxDistance; i+= 0.1f)
        {
            _signaling.volume = i;
            yield return new WaitForSeconds(0.3f);
        }
    }

    private IEnumerator DecreaseVolume()
    {
        for (float i = 1; i > _signaling.minDistance; i -= 0.1f)
        {
            _signaling.volume = i;
            if(_signaling.volume <= 0)
                _signaling.Stop();
            yield return new WaitForSeconds(0.3f);
        }

    }
}
