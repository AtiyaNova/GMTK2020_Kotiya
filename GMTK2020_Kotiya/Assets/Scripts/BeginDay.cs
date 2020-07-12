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
    [SerializeField]
    private List<ActivitySlot> activities;

    [SerializeField]
    private List<EmptySlot> activitySlots;

    [SerializeField]
    private List<Plant> plants;

    [SerializeField]
    private ContextScript context1, context2;

    [SerializeField]
    private SpriteRenderer baseFace;
    [SerializeField]
    private Sprite[] faces;

    private FaceTransitions faceTransitions = FaceTransitions.Beginning;
    private const float timeLimit = 4, initialHeight = 0.5f;

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
    }

    public void Proceed()
    {
        StartCoroutine(ShowContext());

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
                plants[i].CalculateGrowthAmount(activitySlots[i].GetActivity());
            }
        }

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

        string msg1 = activitySlots[0].DisplayMessage(),
            msg2 = activitySlots[1].DisplayMessage(); 

        context1.PlayContext(msg1);

        while (timer < timeLimit)
        {
            timer += Time.deltaTime;
            if (timer >= (timeLimit/2) && context2.IsClear())
            {
                context2.PlayContext(msg2);
            }
            yield return null;
        }

        context1.StopContext();
        context2.StopContext();
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
        print("works1?");
        if (faceTransitions == FaceTransitions.Beginning)
        {
            print("helloooo");
            faceTransitions = FaceTransitions.Middle;
            baseFace.sprite = faces[1];
        }
    }

    public void SetEnd()
    {
        print("works2?");
        if (faceTransitions == FaceTransitions.Middle)
        {
            print("eyyy");
            faceTransitions = FaceTransitions.End;
            baseFace.sprite = faces[2];
        }
    }
}
