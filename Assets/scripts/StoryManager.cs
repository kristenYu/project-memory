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

    public float glitchLengthTimer; 
    public float randomGlitchLength;
    public float startGlitchTimer;
    public float randomStartGlitch; 

    public bool isCoreB1Glitching;


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

        startGlitchTimer = 0;
        randomStartGlitch = Random.Range(0f, 5f);
        isCoreB1Glitching = false;
    }

    void Update()
    {
        glitchLengthTimer += Time.deltaTime;
        startGlitchTimer += Time.deltaTime;
        if(isCoreB1Glitching)
        {
            if(glitchLengthTimer > randomGlitchLength)
            {
                resetCore(coreBlSpriteRenderer, coreBlSprites);
                startGlitchTimer = 0;
                isCoreB1Glitching = false;
            }
        }
       

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
        if(coreBl.activeSelf)
        {
            if(!isCoreB1Glitching)
            {
                if(startGlitchTimer > randomStartGlitch)
                {
                    glitchCore(0, coreBlSpriteRenderer, coreBlSprites);
                    isCoreB1Glitching = true;
                }
            }
        }   
    }

    public void SetDecision(TalkingState talkingState)
    {
        decisionArray[currentDecision] = talkingState;
        frameManager.currentTalkingState = TalkingState.player;
        startGlitchTimer = 0;
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

    public void glitchCore(int decisionPoint, Image coreRenderer, Sprite[] spriteArray)
    {   
        glitchLengthTimer = 0;
        randomGlitchLength = Random.Range(0f, 1f);
        coreRenderer.sprite = spriteArray[(int)decisionArray[decisionPoint]];
    }

    public void resetCore(Image coreRenderer, Sprite[] spriteArray)
    {
        coreRenderer.sprite = spriteArray[0]; //hard coded to be 0 so it is the core without the glitch
    }
}
