using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public FrameManager frameManager;
    public StoryManager storyManager;
    public GameObject avoidantSelectButton;
    public GameObject joyfulSelectButton;
    public GameObject insecureSelectButton;

    public Button avoidantPress;
    public Button insecurePress;
    public Button joyfulPress;
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

    public void DeactivateEmotions()
    {
        avoidantPress.interactable = false;
        insecurePress.interactable = false;
        joyfulPress.interactable = false;
    }

    public void ActivateEmotions()
    {
        avoidantPress.interactable = true;
        insecurePress.interactable = true;
        joyfulPress.interactable = true;
    }

    public void PressAvoidantButton()
    {
        frameManager.currentTalkingState = TalkingState.avoidant;
        avoidantSelectButton.SetActive(true);
        joyfulSelectButton.SetActive(false);
        insecureSelectButton.SetActive(false);
        frameManager.ChangeFrame(frameManager.currentTalkingState);
        audioSource.PlayOneShot(avoidantSoundClip);
    }

    public void DeselectButton()
    {
        if (EventSystem.current.currentSelectedGameObject.name != "Button")
        {
            frameManager.currentTalkingState = TalkingState.player;
            avoidantSelectButton.SetActive(false);
            joyfulSelectButton.SetActive(false);
            insecureSelectButton.SetActive(false);
            frameManager.ChangeFrame(frameManager.currentTalkingState);
        }
    }

    public void PressJoyfulButton()
    {
        frameManager.currentTalkingState = TalkingState.joyful;
        avoidantSelectButton.SetActive(false);
        joyfulSelectButton.SetActive(true);
        insecureSelectButton.SetActive(false);
        frameManager.ChangeFrame(frameManager.currentTalkingState);
        audioSource.PlayOneShot(joyfulSoundClip);
    }

    public void PressInsecureButton()
    {
        frameManager.currentTalkingState = TalkingState.insecure;
        avoidantSelectButton.SetActive(false);
        joyfulSelectButton.SetActive(false);
        insecureSelectButton.SetActive(true);
        frameManager.ChangeFrame(frameManager.currentTalkingState);
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
