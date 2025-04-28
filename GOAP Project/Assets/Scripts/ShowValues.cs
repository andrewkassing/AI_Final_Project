using GOAP.Behaviors;
using TMPro;
using UnityEngine;

public class ShowValues : MonoBehaviour
{
    public TextMeshProUGUI thirstText;
    public TextMeshProUGUI sleepText;
    public ThirstBehavior thirstBehavior;
    public SleepBehavior sleepBehavior;

    void Start()
    {
        
    }

    void Update()
    {
        thirstText.SetText("Thirst: " + thirstBehavior.Thirst.ToString("0.##"));
        sleepText.SetText("Sleepiness: " + sleepBehavior.Sleep.ToString("0.##"));
    }
}
