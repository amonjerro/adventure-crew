using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BouncyText : MonoBehaviour
{
    public TextMeshProUGUI text;
    List<TextMeshProUGUI> childTexts;
    float originalSize;
    public float velocity;
    [Range(0.01f, 0.1f)]
    public float expandInterval;
    public float amplitude;
    public float interval;
    private IEnumerator coroutine;
    private bool _isSetup = false;
    // Start is called before the first frame update
    void Setup()
    {
        originalSize = text.fontSize;
        childTexts = new List<TextMeshProUGUI>();

        //Add all children if there are any
        for (int i = 0; i < transform.childCount; i++)
        {
            TextMeshProUGUI tmpComp = transform.GetChild(i).GetComponent<TextMeshProUGUI>();
            if (tmpComp != null)
            {
                childTexts.Add(tmpComp);
            }
        }
        _isSetup = true;
    }
    private void OnEnable()
    {
        if (!_isSetup)
        {
            Setup();
        }
        coroutine = BounceText();
        StartCoroutine(coroutine);
    }

    private void OnDisable()
    {
        StopCoroutine(coroutine);
    }

    IEnumerator BounceText()
    {
        while (true)
        {
            for (float i = 0; i < Mathf.PI; i += velocity)
            {
                text.fontSize = originalSize + amplitude * Mathf.Sin(i);
                foreach(TextMeshProUGUI child in childTexts)
                {
                    child.fontSize = text.fontSize;
                }
                yield return new WaitForSeconds(expandInterval);
            }

            yield return new WaitForSeconds(interval);
        }
    }

    
}
