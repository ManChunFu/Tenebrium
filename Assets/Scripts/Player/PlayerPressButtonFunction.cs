using UnityEngine;

public class PlayerPressButtonFunction : MonoBehaviour
{
    ButtonTriggerGeneral button = null;
    public Animator anim;
    public void StartPress(ButtonTriggerGeneral newButton)
    {
        button = newButton;
        anim.SetTrigger("startPoke");
        Debug.Log("Start Press");
    }
    public void PressButton()
    {
        button.PressingButton();
        Debug.Log("End Press");
        button = null;
        
    }
}
