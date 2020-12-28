using UnityEngine;

public class Interaction : MonoBehaviour
{
#if UNITY_EDITOR
    [TypeConstrainComponent(typeof(IInteractable))]
#endif
    public Component main;
#if UNITY_EDITOR
    [TypeConstrainComponent(typeof(IInteractable))]
#endif
    public Component secondary;

    [HideInInspector] IInteractable mainI;
    [HideInInspector] IInteractable secondaryI;

    [HideInInspector] public bool hasSecondary { get { if (secondary == null) { return false; } else { return true; } } }

    public bool customSetup = true; 
    private void Awake()
    {
        if (customSetup)
        {
            if (main != null)
            {
                mainI = main.GetComponent<IInteractable>();
            }
            if (secondary != null)
            {
                secondaryI = secondary.GetComponent<IInteractable>();
            }
        }

       
    }
    public void ExternalSetup(Component comp, bool isMain) // setup by a third party
    {
        if (isMain)
        {
            main = comp;
            mainI = main.GetComponent<IInteractable>();
        }
        else
        {
            secondary = comp;
            secondaryI = secondary.GetComponent<IInteractable>();
        }
    }
    public void DoMainFunction(PlayerInteractable player)
    {
        if (main != null)
        {
            mainI.Activate(player);
        }
        
    }

    public void DoSecondaryFunction(PlayerInteractable player)
    {
        if (!hasSecondary)
        {
            secondaryI.Activate(player);
        }
        else
        {
            DoMainFunction(player);
        }
        
    }
}
