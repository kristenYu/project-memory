using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    public FrameManager frameManager;
    public TalkingState[] decisionArray; 
    public TalkingState currentTalkingState;
    public int currentDecision;

    public GameObject theAvoidant; 
    public GameObject theJoyful; 
    public GameObject theInsecure;

    public GameObject spaceContinue;

    public GameObject coreBl;
    public Image coreBlSpriteRenderer;

    public GameObject coreTl;
    public Image coreTlSpriteRenderer;
    public GameObject coreTr;

    public Image coreTrSpriteRenderer;
    public GameObject coreBr;
    public Image coreBrSpriteRenderer;

    public Sprite[] coreBlSprites;
    public Sprite[] coreTlSprites;
    public Sprite[] coreTrSprites;
    public Sprite[] coreBrSprites;

    //core bottom left (coreBl)
    public float coreBlGlitchLengthTimer; 
    public float coreBlRandomGlitchLength;
    public float coreBlStartGlitchTimer;
    public float coreBlRandomStartGlitch; 
    public bool isCoreB1Glitching;

    //core bottom right (core Br)
    public float coreBrGlitchLengthTimer; 
    public float coreBrRandomGlitchLength;
    public float coreBrStartGlitchTimer;
    public float coreBrRandomStartGlitch; 
    public bool isCoreBrGlitching;

    //core top left (core Tl)
    public float coreTlGlitchLengthTimer; 
    public float coreTlRandomGlitchLength;
    public float coreTlStartGlitchTimer;
    public float coreTlRandomStartGlitch; 
    public bool isCoreTlGlitching;

    //core top right (core Tr)
    public float coreTrGlitchLengthTimer; 
    public float coreTrRandomGlitchLength;
    public float coreTrStartGlitchTimer;
    public float coreTrRandomStartGlitch; 
    public bool isCoreTrGlitching;


    public bool isIntro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        decisionArray = new TalkingState[5];
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
        if(isIntro)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                theAvoidant.SetActive(true);
                theJoyful.SetActive(true);
                theInsecure.SetActive(true);

                spaceContinue.SetActive(false);
                isIntro = false;
            }
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

        if(isCoreB1Glitching)
        {
            if(coreBlGlitchLengthTimer > coreBlRandomGlitchLength)
            {
                resetCore(coreBlSpriteRenderer, coreBlSprites);
                coreBlStartGlitchTimer = 0;
                isCoreB1Glitching = false;
            }
        }
        if(isCoreBrGlitching)
        {
            if(coreBrGlitchLengthTimer > coreBrRandomGlitchLength)
            {
                resetCore(coreBrSpriteRenderer, coreBrSprites);
                coreBrStartGlitchTimer = 0;
                isCoreBrGlitching = false;
            }
        }
        if(isCoreTlGlitching)
        {
            if(coreTlGlitchLengthTimer > coreTlRandomGlitchLength)
            {
                resetCore(coreTlSpriteRenderer, coreTlSprites);
                coreTlStartGlitchTimer = 0;
                isCoreTlGlitching = false;
            }
        }
        if(isCoreTrGlitching)
        {
            if(coreTrGlitchLengthTimer > coreTrRandomGlitchLength)
            {
                resetCore(coreTrSpriteRenderer, coreTrSprites);
                coreTrStartGlitchTimer = 0;
                isCoreTrGlitching = false;
            }
        }
        


      
        if(coreBl.activeSelf)
        {
            if(!isCoreB1Glitching)
            {
                if(coreBlStartGlitchTimer > coreBlRandomStartGlitch)
                {
                    glitchCore(coreBlGlitchLengthTimer, coreBlRandomGlitchLength, 0, coreBlSpriteRenderer, coreBlSprites);
                    isCoreB1Glitching = true;
                }
            }
        }

        if(coreBr.activeSelf)
        {
            if(!isCoreBrGlitching)
            {
                if(coreBrStartGlitchTimer > coreBrRandomStartGlitch)
                {
                    glitchCore(coreBrGlitchLengthTimer, coreBrRandomGlitchLength, 1, coreBrSpriteRenderer, coreBrSprites);
                    isCoreBrGlitching = true;
                }
            }
        }   

        if(coreTl.activeSelf)
        {
            if(!isCoreTlGlitching)
            {
                if(coreTlStartGlitchTimer > coreTlRandomStartGlitch)
                {
                    glitchCore(coreTlGlitchLengthTimer, coreTlRandomGlitchLength, 2, coreTlSpriteRenderer, coreTlSprites);
                    isCoreTlGlitching = true;
                }
            }
        }
        if(coreTr.activeSelf)
        {
            if(!isCoreTrGlitching)
            {
                if(coreTrStartGlitchTimer > coreTrRandomStartGlitch)
                {
                    glitchCore(coreTrGlitchLengthTimer, coreTrRandomGlitchLength, 3, coreTrSpriteRenderer, coreTrSprites);
                    isCoreTrGlitching = true;
                }
            }
        }
    }

    public void SetDecision(TalkingState talkingState)
    {
        decisionArray[currentDecision] = talkingState;
        frameManager.currentTalkingState = TalkingState.player;
        frameManager.changeFrame(TalkingState.player);
        coreBlStartGlitchTimer = 0;
        if(currentDecision < decisionArray.Length)
        {
            currentDecision += 1;
            switch(currentDecision)
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
    }

    public void glitchCore(float coreGlitchTimer, float coreGlitchLength, int decisionPoint, Image coreRenderer, Sprite[] spriteArray)
    {   
        coreGlitchTimer = 0;
        coreGlitchLength = Random.Range(0.5f, 2f);
        coreRenderer.sprite = spriteArray[(int)decisionArray[decisionPoint]];
    }

    public void resetCore(Image coreRenderer, Sprite[] spriteArray)
    {
        coreRenderer.sprite = spriteArray[0]; //hard coded to be 0 so it is the core without the glitch
    }
}
