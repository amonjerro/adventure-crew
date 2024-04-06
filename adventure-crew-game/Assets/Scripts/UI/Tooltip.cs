using TMPro;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textObject;
    [SerializeField]
    private float yOffset;

    public void Show(Vector3 position)
    {
        RectTransform rt = GetComponent<RectTransform>();
        rt.localPosition = new Vector3(position.x, position.y + yOffset, position.z) ;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SetText(string text)
    {
        textObject.text = text;
    }
}