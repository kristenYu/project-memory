using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public FrameManager frameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressAvoidantButton()
    {
        frameManager.currentTalkingState = TalkingState.avoidant;
    }

    public void PressJoyfulButton()
    {
        frameManager.currentTalkingState = TalkingState.joyful;
    }

    public void PressInsecureButton()
    {
        frameManager.currentTalkingState = TalkingState.insecure;
    }
}

