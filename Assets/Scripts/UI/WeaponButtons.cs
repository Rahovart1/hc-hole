using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponButtons : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private Collector _collector;
    [SerializeField] private List<TextMeshProUGUI> _texts;
    private void OnEnable()
    {
        SetTexts();
        StartCoroutine(StartAnimation());
    }

    private void SetTexts()
    {
        for (int i = 0; i < _collector.collectibles.Length; i++)
        {
            _texts[i].text = _collector.collectibles[i].ToString();
        }
    }
    private IEnumerator StartAnimation()
    {
        float elapsedTime = 0f;
        transform.localScale = Vector3.zero;


        while(elapsedTime <= _duration)
        {
            //transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, elapsedTime/_duration);
            transform.localScale = _curve.Evaluate(elapsedTime/_duration) * Vector3.one;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = Vector3.one;
    }
}
