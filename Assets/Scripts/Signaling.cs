using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _signaling;
    [SerializeField] private float _stepDistance;
    [SerializeField] private float _timeForWait;
    private Coroutine _increaseVolume;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            _increaseVolume = StartCoroutine(IncreaseVolume());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine(_increaseVolume);
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            StartCoroutine(DecreaseVolume());
        }
    }

    private IEnumerator IncreaseVolume()
    {
        _signaling.Play();
        for (float i = _signaling.volume; i < _signaling.maxDistance; i += _stepDistance)
        {
            _signaling.volume = i;
            yield return new WaitForSeconds(_timeForWait);
        }
    }

    private IEnumerator DecreaseVolume()
    {
        for (float i = _signaling.volume; i > _signaling.minDistance; i -= _stepDistance)
        {
            _signaling.volume = i;
            yield return new WaitForSeconds(_timeForWait);
        }
        if(_signaling.volume <= 0)
        _signaling.Stop();
    }
}
