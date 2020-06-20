using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IncreaseOnMouseover : MonoBehaviour
{
    [SerializeField] private float minHeight;

    [SerializeField] private float maxHeight;

    [SerializeField] private float delay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartIncrease()
    {
        StopAllCoroutines();
        StartCoroutine(Resize(maxHeight));
    }

    IEnumerator Resize(float target)
    {
        RectTransform tran = (RectTransform) transform;
        float currentY = tran.sizeDelta.y;

        yield return null;
        for (float t = 0; t < delay; t += Time.deltaTime)
        {
            float height = Mathf.SmoothStep(currentY, target, t / delay);
            tran.sizeDelta = new Vector2(tran.sizeDelta.x, height);
            yield return null;
        }
        tran.sizeDelta = new Vector2(tran.sizeDelta.x, target);
    }

    public void StartDecrease()
    {
        StopAllCoroutines();
        StartCoroutine(Resize(minHeight));
    }
}
