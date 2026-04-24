using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public FrameManager frameManager;
    public StoryManager storyManager;
    public GameObject avoidantSelectButton;
    public GameObject joyfulSelectButton;
    public GameObject insecureSelectButton;

    public AudioSource audioSource;
    public AudioClip avoidantSoundClip;
    public AudioClip joyfulSoundClip;
    public AudioClip insecureSoundClip;
    public AudioClip buttonClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HideAllSelectButtons();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { }
    }

    public void PressAvoidantButton()
    {
        frameManager.currentTalkingState = TalkingState.avoidant;
        avoidantSelectButton.SetActive(true);
        joyfulSelectButton.SetActive(false);
        insecureSelectButton.SetActive(false);
        frameManager.changeFrame(frameManager.currentTalkingState);
        audioSource.PlayOneShot(avoidantSoundClip);
    }

    public void PressJoyfulButton()
    {
        frameManager.currentTalkingState = TalkingState.joyful;
        avoidantSelectButton.SetActive(false);
        joyfulSelectButton.SetActive(true);
        insecureSelectButton.SetActive(false);
        frameManager.changeFrame(frameManager.currentTalkingState);
        audioSource.PlayOneShot(joyfulSoundClip);
    }

    public void PressInsecureButton()
    {
        frameManager.currentTalkingState = TalkingState.insecure;
        avoidantSelectButton.SetActive(false);
        joyfulSelectButton.SetActive(false);
        insecureSelectButton.SetActive(true);
        frameManager.changeFrame(frameManager.currentTalkingState);
        audioSource.PlayOneShot(insecureSoundClip);
    }

    public void SelectAvoidantButton()
    {
        storyManager.SetDecision(TalkingState.avoidant);
        audioSource.PlayOneShot(buttonClip);
        HideAllSelectButtons();
    }

    public void SelectJoyfulButton()
    {
        storyManager.SetDecision(TalkingState.joyful);
        audioSource.PlayOneShot(buttonClip);
        HideAllSelectButtons();
    }

    public void SelectInsecureButton()
    {
        storyManager.SetDecision(TalkingState.insecure);
        audioSource.PlayOneShot(buttonClip);
        HideAllSelectButtons();
    }

    public void HideAllSelectButtons()
    {
        avoidantSelectButton.SetActive(false);
        joyfulSelectButton.SetActive(false);
        insecureSelectButton.SetActive(false);
    }
}
