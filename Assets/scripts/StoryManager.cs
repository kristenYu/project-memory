using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class StoryManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonClip;
    public FrameManager frameManager;
    public ButtonManager buttonManager;
    public GlitchManager glitchManager;
    public TalkingState[] decisionArray;
    public TalkingState currentTalkingState;
    public int currentDecision;

    public GameObject theAvoidant;
    public GameObject theJoyful;
    public GameObject theInsecure;
    public GameObject spaceContinue;

    public GameObject coreBl;
    public SpriteRenderer coreBlSpriteRenderer;

    public GameObject coreTl;
    public SpriteRenderer coreTlSpriteRenderer;
    public GameObject coreTr;

    public SpriteRenderer coreTrSpriteRenderer;
    public GameObject coreBr;
    public SpriteRenderer coreBrSpriteRenderer;

    public Sprite[] coreBlSprites;
    public Sprite[] coreTlSprites;
    public Sprite[] coreTrSprites;
    public Sprite[] coreBrSprites;

    //core bottom left (coreBl)
    float coreBlGlitchLengthTimer;
    float coreBlRandomGlitchLength;
    float coreBlStartGlitchTimer;
    float coreBlRandomStartGlitch;
    bool isCoreB1Glitching;

    //core bottom right (core Br)
    float coreBrGlitchLengthTimer;
    float coreBrRandomGlitchLength;
    float coreBrStartGlitchTimer;
    float coreBrRandomStartGlitch;
    bool isCoreBrGlitching;

    //core top left (core Tl)
    float coreTlGlitchLengthTimer;
    float coreTlRandomGlitchLength;
    float coreTlStartGlitchTimer;
    float coreTlRandomStartGlitch;
    bool isCoreTlGlitching;

    //core top right (core Tr)
    float coreTrGlitchLengthTimer;
    float coreTrRandomGlitchLength;
    float coreTrStartGlitchTimer;
    float coreTrRandomStartGlitch;
    bool isCoreTrGlitching;

    public bool isIntro;

    public Stage[] scriptStage;
    public int playerIndex = 0;
    public int voicesIndex = 0;
    public int stageIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerIndex = 0;
        voicesIndex = 0;
        stageIndex = 0;
        glitchManager.OpeningGlitch();
        currentDecision = 0;
        isIntro = true;
        theAvoidant.SetActive(false);
        theJoyful.SetActive(false);
        theInsecure.SetActive(false);

        coreBl.SetActive(false);
        coreBr.SetActive(false);
        coreTl.SetActive(false);
        coreTr.SetActive(false);

        //setup timers for glitching
        coreBlStartGlitchTimer = 0;
        coreBlRandomStartGlitch = Random.Range(1f, 5f);
        isCoreB1Glitching = false;
        coreBrStartGlitchTimer = 0;
        coreBrRandomStartGlitch = Random.Range(1f, 5f);
        isCoreBrGlitching = false;
        coreTlStartGlitchTimer = 0;
        coreTlRandomStartGlitch = Random.Range(1f, 5f);
        isCoreTlGlitching = false;
        coreTrStartGlitchTimer = 0;
        coreTrRandomStartGlitch = Random.Range(1f, 5f);
        isCoreTrGlitching = false;
    }

    void Update()
    {
        switch (scriptStage[stageIndex])
        {
            case Stage.player:
                spaceContinue.SetActive(true);
                buttonManager.DeactivateEmotions();
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    audioSource.PlayOneShot(buttonClip);
                    stageIndex += 1;
                    playerIndex += 1;
                    if (isIntro && scriptStage[stageIndex] != Stage.player)
                    {
                        {
                            theAvoidant.SetActive(true);
                            theJoyful.SetActive(true);
                            theInsecure.SetActive(true);

                            spaceContinue.SetActive(false);
                            isIntro = false;
                        }
                    }
                }
                break;
            case Stage.voices:
                buttonManager.ActivateEmotions();
                spaceContinue.SetActive(false);
                break;
            case Stage.ALL:
                buttonManager.ActivateEmotions();
                spaceContinue.SetActive(true);
                frameManager.ChangeFrame(TalkingState.ALL);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    audioSource.PlayOneShot(buttonClip);
                    stageIndex += 1;
                }
                break;
        }

        //core timers
        coreBlGlitchLengthTimer += Time.deltaTime;
        coreBlStartGlitchTimer += Time.deltaTime;
        coreBrGlitchLengthTimer += Time.deltaTime;
        coreBrStartGlitchTimer += Time.deltaTime;
        coreTlGlitchLengthTimer += Time.deltaTime;
        coreTlStartGlitchTimer += Time.deltaTime;
        coreTrGlitchLengthTimer += Time.deltaTime;
        coreTrStartGlitchTimer += Time.deltaTime;

        if (isCoreB1Glitching)
        {
            if (coreBlGlitchLengthTimer > coreBlRandomGlitchLength)
            {
                ResetCore(coreBlSpriteRenderer, coreBlSprites);
                coreBlStartGlitchTimer = 0;
                isCoreB1Glitching = false;
            }
        }
        if (isCoreBrGlitching)
        {
            if (coreBrGlitchLengthTimer > coreBrRandomGlitchLength)
            {
                ResetCore(coreBrSpriteRenderer, coreBrSprites);
                coreBrStartGlitchTimer = 0;
                isCoreBrGlitching = false;
            }
        }
        if (isCoreTlGlitching)
        {
            if (coreTlGlitchLengthTimer > coreTlRandomGlitchLength)
            {
                ResetCore(coreTlSpriteRenderer, coreTlSprites);
                coreTlStartGlitchTimer = 0;
                isCoreTlGlitching = false;
            }
        }
        if (isCoreTrGlitching)
        {
            if (coreTrGlitchLengthTimer > coreTrRandomGlitchLength)
            {
                ResetCore(coreTrSpriteRenderer, coreTrSprites);
                coreTrStartGlitchTimer = 0;
                isCoreTrGlitching = false;
            }
        }

        if (coreBl.activeSelf)
        {
            if (!isCoreB1Glitching)
            {
                if (coreBlStartGlitchTimer > coreBlRandomStartGlitch)
                {
                    GlitchCore(0, coreBlSpriteRenderer, coreBlSprites);
                    isCoreB1Glitching = true;
                }
            }
        }

        if (coreBr.activeSelf)
        {
            if (!isCoreBrGlitching)
            {
                if (coreBrStartGlitchTimer > coreBrRandomStartGlitch)
                {
                    GlitchCore(1, coreBrSpriteRenderer, coreBrSprites);
                    isCoreBrGlitching = true;
                }
            }
        }

        if (coreTl.activeSelf)
        {
            if (!isCoreTlGlitching)
            {
                if (coreTlStartGlitchTimer > coreTlRandomStartGlitch)
                {
                    GlitchCore(2, coreTlSpriteRenderer, coreTlSprites);
                    isCoreTlGlitching = true;
                }
            }
        }
        if (coreTr.activeSelf)
        {
            if (!isCoreTrGlitching)
            {
                if (coreTrStartGlitchTimer > coreTrRandomStartGlitch)
                {
                    GlitchCore(3, coreTrSpriteRenderer, coreTrSprites);
                    isCoreTrGlitching = true;
                }
            }
        }
    }

    public void SetDecision(TalkingState talkingState)
    {
        decisionArray.Append(talkingState);
        frameManager.currentTalkingState = TalkingState.player;
        frameManager.ChangeFrame(TalkingState.player);
        coreBlStartGlitchTimer = 0;
        currentDecision += 1;
        stageIndex += 1;
        playerIndex += 1;
        voicesIndex += 1;
        switch (currentDecision)
        {
            case 1:
                coreBl.SetActive(true);
                break;
            case 2:
                coreBr.SetActive(true);
                break;
            case 3:
                coreTl.SetActive(true);
                break;
            case 4:
                coreTr.SetActive(true);
                break;
        }
    }

    public void GlitchCore(int decisionPoint, SpriteRenderer coreRenderer, Sprite[] spriteArray)
    {
        Debug.Log(coreRenderer);
        Debug.Log((int)decisionArray[decisionPoint]);
        coreRenderer.sprite = spriteArray[(int)decisionArray[decisionPoint]];
    }

    public void ResetCore(SpriteRenderer coreRenderer, Sprite[] spriteArray)
    {
        coreRenderer.sprite = spriteArray[0]; //hard coded to be 0 so it is the core without the glitch
    }
}
