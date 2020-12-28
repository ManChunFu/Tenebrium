using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonTriggerGeneral : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent OnButtonActivate = null;

    [SerializeField] public buttonState state;
    [SerializeField] Material canPressMat;
    [SerializeField] Material isPressedMat;
    [SerializeField] Material inactiveMat;
    public enum buttonState { canPress, isPressed, inactive }
    bool active = true;
    Renderer renderer;
    
    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        ColorSwitch();

        Interaction interact = transform.GetComponent<Interaction>();
        if (interact != null && !interact.customSetup)
        {
            interact.ExternalSetup(this, true);
        }
    }

    public void Activate(PlayerInteractable player)
    {
        player.pressButtonFunction.StartPress(this);
        Debug.Log("Button Pressed");
    }

    public void PressingButton()
    {
        if (state == buttonState.canPress)
        {
            Debug.Log("Button Pressed");
            OnButtonActivate?.Invoke();
            // On Success Sounds
            SoundManager.Sound.SFX.ButtonPressSuccessful.Post(gameObject);
            ColorSwitch();
        }
        else
        {
            // On Fail Sounds
            SoundManager.Sound.SFX.ButtonPressUnsuccessful.Post(gameObject);
        }
    }
   
    public void EnableDisable()
    {
        active = !active;
    }

    void ColorSwitch()
    {
        
        switch (state)
        {
            case buttonState.canPress:
                renderer.material = canPressMat;
                break;
            case buttonState.isPressed:
                renderer.material = isPressedMat;
                break;
            case buttonState.inactive:
                renderer.material = inactiveMat;
                break;
            default:
                break;
        }
    }

    public void SetToActive()
    {
        state = buttonState.canPress;
        ColorSwitch();
    }
    public void SetToInactive()
    {
        state = buttonState.inactive;
        ColorSwitch();
    }
    public void SetToIsPressed()
    {
        state = buttonState.isPressed;
        ColorSwitch();
    }
    public void SetActiveInactive()
    {
        if (state == buttonState.isPressed)
        {
            state = buttonState.canPress;
        }
        else if (state == buttonState.canPress)
        {
            state = buttonState.isPressed;
        }
        ColorSwitch();

    }

}
