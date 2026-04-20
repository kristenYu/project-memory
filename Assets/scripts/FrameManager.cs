using UnityEngine;
using TMPro;

public enum TalkingState
{
    player,
    avoidant, 
    joyful, 
    insecure

}

public class FrameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public TextMeshProUGUI frameText;
    public string[] playerText;
    public string[] avoidantText;
    public string[] joyfulText; 
    public string[] insecureText;

    public TalkingState currentTalkingState;
    public int index;

    void Start()
    {
        index = 0;
        currentTalkingState = TalkingState.player;
    }

    void Update()
    {
        switch(currentTalkingState)
        {
            case TalkingState.avoidant:
                frameText.text = avoidantText[index];
                break;
            case TalkingState.joyful:
                frameText.text = joyfulText[index];
                break;
            case TalkingState.insecure:
                frameText.text = insecureText[index];
                break;
            case TalkingState.player:
                frameText.text = playerText[index];
                break;
        }
    }






}
