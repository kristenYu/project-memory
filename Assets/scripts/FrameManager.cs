using TMPro;
using UnityEngine;

public enum TalkingState
{
    player,
    avoidant,
    joyful,
    insecure,
    ALL,
}

public enum Stage
{
    player,
    voices,
    ALL,
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

    public StoryManager storyManager;

    public FramePiece[] frameArray;

    void Start()
    {
        currentTalkingState = TalkingState.player;
    }

    void Update()
    {
        switch (currentTalkingState)
        {
            case TalkingState.avoidant:
                frameText.text = avoidantText[storyManager.voicesIndex];
                break;
            case TalkingState.joyful:
                frameText.text = joyfulText[storyManager.voicesIndex];
                break;
            case TalkingState.insecure:
                frameText.text = insecureText[storyManager.voicesIndex];
                break;
            case TalkingState.player:
                frameText.text = playerText[storyManager.playerIndex];
                break;
        }
    }

    public void changeFrame(TalkingState talkingState)
    {
        foreach (FramePiece framePiece in frameArray)
        {
            framePiece.UpdateFrame(talkingState);
        }
    }
}
