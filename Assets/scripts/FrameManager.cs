using TMPro;
using UnityEngine;

public enum TalkingState
{
    player,
    avoidant,
    joyful,
    insecure,
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
                frameText.text = avoidantText[storyManager.currentDecision];
                break;
            case TalkingState.joyful:
                frameText.text = joyfulText[storyManager.currentDecision];
                break;
            case TalkingState.insecure:
                frameText.text = insecureText[storyManager.currentDecision];
                break;
            case TalkingState.player:
                frameText.text = playerText[storyManager.currentDecision];
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
