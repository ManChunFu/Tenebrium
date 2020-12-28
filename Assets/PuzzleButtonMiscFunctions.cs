using UnityEngine.Events;
using UnityEngine;
using SpaceGame.Dog;
public class PuzzleButtonMiscFunctions : MonoBehaviour
{
    [SerializeField] PuzzleButtonMaster master;
   // [SerializeField] CountDownTimer timer;

  //  [SerializeField] DogAgent dog;
    [SerializeField] Transform dogTrigger;
    public UnityEvent callTimeline;
    

    int timesButtonPressed = 0;
    public int buttonsPressedUntilEvent = 3;
    bool firstPress;
    private void Awake()
    {
        master.onButtonPressed += OnButtonPress;
    }

    void OnButtonPress()
    {
        if (!firstPress)
        {
            firstPress = true;
            //timer.StartTimer();
        }
        if (timesButtonPressed >= buttonsPressedUntilEvent)
        {
            StartTimeLine();
        }
        timesButtonPressed++;
    }

    bool alreadyStarted = false;
    public void StartTimeLine()
    {
        Debug.Log("Calling Dog");
        if (!alreadyStarted)
        {
            dogTrigger.gameObject.SetActive(true);
            callTimeline.Invoke();
        }
    }
}
