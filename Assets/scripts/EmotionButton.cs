using UnityEngine;

public class EmotionButton : MonoBehaviour
{
    public GameObject selectButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        selectButton.SetActive(false);
    }

    public void EmotionPressed()
    {
        selectButton.SetActive(true);
    }
}
