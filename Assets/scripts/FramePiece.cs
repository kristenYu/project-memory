using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FramePiece : MonoBehaviour
{
    public Sprite playerFrame;
    public Sprite avoidantFrame;
    public Sprite joyfulFrame;
    public Sprite insecureFrame;

    public Image thisSpriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisSpriteRenderer.sprite = playerFrame;
    }

    public void UpdateFrame(TalkingState talkingState)
    {
        switch (talkingState)
        {
            case TalkingState.player:
                thisSpriteRenderer.sprite = playerFrame;
                break;
            case TalkingState.avoidant:
                thisSpriteRenderer.sprite = avoidantFrame;
                break;
            case TalkingState.joyful:
                thisSpriteRenderer.sprite = joyfulFrame;
                break;
            case TalkingState.insecure:
                thisSpriteRenderer.sprite = insecureFrame;
                break;
            case TalkingState.ALL:
                thisSpriteRenderer.sprite = RandomSprite();
                break;
        }
    }

    public Sprite RandomSprite()
    {
        int x = Random.Range(0, 3);
        return x switch
        {
            0 => insecureFrame,
            1 => avoidantFrame,
            2 => joyfulFrame,
            _ => playerFrame,
        };
    }
}
