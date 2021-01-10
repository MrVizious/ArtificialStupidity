using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    public Sprite active, inactive;

    public string customText;
    public Text text;
    public float activeOpacity = 0.6f;


    public Image image;

    private void Start()
    {
        if (customText != null || customText.Length >= 0)
        {
            text.text = customText;
        }
        image = GetComponent<Image>();
        Deactivate();
    }

    public void Activate()
    {
        Color tempColor = image.color;
        tempColor.a = activeOpacity;
        image.color = tempColor;
        image.sprite = active;

        tempColor = text.color;
        tempColor.a = activeOpacity;
        text.color = tempColor;
    }

    public void Deactivate()
    {
        Color tempColor = image.color;
        tempColor.a = 1f;
        image.color = tempColor;
        image.sprite = inactive;

        tempColor = text.color;
        tempColor.a = 1f;
        text.color = tempColor;
    }
}
