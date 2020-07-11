using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmptySlot : MonoBehaviour
{

    private Activity activity;
    private Text Name;

    private void Start()
    {
        Name = GetComponentInChildren<Text>();
    }

    public void SetActivity(Activity newActivity)
    {
        activity = newActivity;
        Name.text = newActivity.name;
    }

    public void ClearActivity()
    {
        activity = null;
        Name.text = "Nothing";
    }
}
