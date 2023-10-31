using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolderController : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Vector3 _velocity;

    private void OnEnable()
    {
        EventManager.Instance.onFirstStageEnd.AddListener(DestroyObjects);
    }
    private void OnDisable()
    {
        EventManager.Instance.onFirstStageEnd.RemoveListener(DestroyObjects);
    }

    public void DestroyObjects() => StartCoroutine(DestroyAll());

    private IEnumerator DestroyAll()
    {
        float _elapsedTime = 0f;

        while (_elapsedTime <= _duration)
        {
            _elapsedTime += Time.deltaTime;
            transform.position += _velocity * Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
