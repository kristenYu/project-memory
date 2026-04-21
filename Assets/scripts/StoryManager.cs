using Unity.VisualScripting;
using UnityEngine;

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
    public GameObject coreTl;
    public GameObject coreTr;
    public GameObject coreBr;


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
    }

    public void SetDecision(TalkingState talkingState)
    {
        decisionArray[currentDecision] = talkingState;
        frameManager.currentTalkingState = TalkingState.player;
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

}
