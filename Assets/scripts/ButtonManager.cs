using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public FrameManager frameManager;
    public StoryManager storyManager;
    public GameObject avoidantSelectButton; 
    public GameObject joyfulSelectButton;
    public GameObject insecureSelectButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        avoidantSelectButton.SetActive(false);
        joyfulSelectButton.SetActive(false);
        insecureSelectButton.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }

    public void PressAvoidantButton()
    {
        frameManager.currentTalkingState = TalkingState.avoidant;
        avoidantSelectButton.SetActive(true);
        joyfulSelectButton.SetActive(false);
        insecureSelectButton.SetActive(false);
    }

    public void PressJoyfulButton()
    {
        frameManager.currentTalkingState = TalkingState.joyful;
        avoidantSelectButton.SetActive(false);
        joyfulSelectButton.SetActive(true);
        insecureSelectButton.SetActive(false);
    }

    public void PressInsecureButton()
    {
        frameManager.currentTalkingState = TalkingState.insecure;
        avoidantSelectButton.SetActive(false);
        joyfulSelectButton.SetActive(false);
        insecureSelectButton.SetActive(true);
    }

    public void SelectAvoidantButton()
    {
        storyManager.SetDecision(TalkingState.avoidant);
    }

    public void SelectJoyfulButton()
    {
        storyManager.SetDecision(TalkingState.joyful);
    }

    public void SelectInsecureButton()
    {
        storyManager.SetDecision(TalkingState.insecure);
    }

}

