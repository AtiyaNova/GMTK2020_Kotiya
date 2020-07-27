using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//the activity types
public enum ThePlants
{
    Anger,
    Stress,
    Depression
}

enum FaceTransitions
{
    Beginning,
    Middle,
    End
}

//Runs the logic for the plant growth based off of the player choices
public class BeginDay : MonoBehaviour
{
    [SerializeField] private List<ActivitySlot> activities;
    [SerializeField] private List<EmptySlot> activitySlots;
    [SerializeField] private List<Plant> plants;
    [SerializeField] private ContextScript[] context;
    [SerializeField] private SpriteRenderer baseFace;
    [SerializeField] private Sprite[] faces;
    [SerializeField] private Tab tutorialTab;
    [SerializeField] private UIChange[] theChanges;
    [SerializeField] private Text credits;
    [SerializeField] private RawImage vignette;

    private FaceTransitions faceTransitions = FaceTransitions.Beginning;
    private const float timeLimit = 4;
    private int plantsAtEnd = 0;
    private string[] messages;
    private Color origCredits, origVignette;

    public BorderVines borderVines;
    public GameObject proceedBtn;

    //Singleton
    public static BeginDay Instance;

    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    private void Start()
    {
        proceedBtn.SetActive(false);
        messages = new string[context.Length];
        tutorialTab.FlipPage();
        origCredits = credits.color;
        origVignette = vignette.color;
        credits.color = Color.clear;
        vignette.color = Color.clear;
    }

    public void Proceed()
    {
        GameSoundManager.Instance.PlayBookClose();

        for (int i =  0; i < activities.Count;i++)
        {
            activities[i].ResetTransform();
        }

        //resets growth calculation
        for (int i = 0; i < plants.Count; i++) plants[i].ResetGrowth();

        //calculates growth
        for (int i = 0; i < activitySlots.Count; i++)
        {
            for (int j = 0; j < plants.Count; j++)
            {
                plants[j].CalculateGrowthAmount(activitySlots[i]);
            }
        }

        StartCoroutine(ShowContext());
        StartCoroutine(borderVines.GrowVines());

        //then grows the plants
        for (int i = 0; i < plants.Count; i++)
        {
            StartCoroutine(plants[i].GrowPlant());
        }

        //makes it so that you can't set the day 
        PlannerDrag.Instance.SetPlanner(false);

        for (int i = 0; i < activitySlots.Count; i++)
        {
            activitySlots[i].ClearActivity();
            
        }

        proceedBtn.SetActive(false);

    }

    //Shows the text about activities
    private IEnumerator ShowContext()
    {
        float timer = 0;

        for (int i = 0; i < activitySlots.Count; i++)
        {
            messages[i] = activitySlots[i].DisplayMessage();
            context[i].StopContext();
        }

        context[0].PlayContext(messages[0]);

        while (timer < timeLimit)
        {
            timer += Time.deltaTime;
            if (timer >= (timeLimit/2) && context[1].IsClear())
            {
                context[1].PlayContext(messages[1]);
            }
            yield return null;
        }

    }

    public void CheckSlots()
    {
        if (!activitySlots[0].IsClear() && !activitySlots[1].IsClear())
        {
            proceedBtn.SetActive(true);
        }
        else proceedBtn.SetActive(false);
    }

    //this is to calculate how much the vines should grow by
    public float AveragePlantGrowth()
    {
        float average = 0;

        for (int i = 0; i < plants.Count; i++)
        {
            average += plants[i].GetGrowth();
        }

        average /= 3;

        return average;
    }

    //changes the faces
    public void SetMiddle()
    {
        if (faceTransitions == FaceTransitions.Beginning)
        {
            faceTransitions = FaceTransitions.Middle;
            baseFace.sprite = faces[1];
        }
    }

    public void SetEnd()
    {
        plantsAtEnd++;
        if (faceTransitions == FaceTransitions.Middle && plantsAtEnd>=2)
        {
            faceTransitions = FaceTransitions.End;
            baseFace.sprite = faces[2];
        }
        if (plantsAtEnd == 3)
        {
            StartCoroutine(FadeInCredits());
            StartCoroutine(FadeVignette());
        }
    }

    public void ChangeTutorial(ThePlants type)
    {
        for (int i = 0; i < theChanges.Length;i++)
        {
            if (theChanges[i].GetPlantType() == type)
            {
                theChanges[i].ActivateChange();
            }
        }
        tutorialTab.FlipPage();
    }

    private IEnumerator FadeVignette()
    {
        float time = 2;
        Color startCol = vignette.color;
        for (float t = 0.01f; t < time; t += Time.deltaTime)
        {
            vignette.color = Color.Lerp(startCol, origVignette, Mathf.Min(1, t / time));
            yield return null;
        }
    }

    private IEnumerator FadeInCredits()
    {
        float time = 2;
        for (float t = 0.01f; t < time; t += Time.deltaTime)
        {
            credits.color = Color.Lerp(Color.clear, origCredits, Mathf.Min(1, t / time));
            yield return null;
        }
    }
}
