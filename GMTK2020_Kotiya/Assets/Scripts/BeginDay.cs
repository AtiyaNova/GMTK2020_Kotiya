using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Runs the logic for the plant growth based off of the player choices
public class BeginDay : MonoBehaviour
{
    [SerializeField]
    private List<EmptySlot> activitySlots;

    [SerializeField]
    private List<Plant> plants;

    [SerializeField]
    private ContextScript context1, context2;

    private const float timeLimit = 4;

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
        StartCoroutine(borderVines.GrowVines());
        StartCoroutine(ShowContext());

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
}
