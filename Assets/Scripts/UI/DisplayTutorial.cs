using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DisplayTutorial : MonoBehaviour
{
    [SerializeField] private Sprite interact = null;
    [SerializeField] private Sprite pickUp = null;
    [SerializeField] private Sprite petDog = null;
    [SerializeField] private float fadeSpeed = 0.03f;

    private Image imageTutorial = null;
    private void Awake()
    {
        if (interact == null)
            throw new MissingReferenceException("Missing reference of interactTutorial sprite.");

        if (pickUp == null)
            throw new MissingReferenceException("Missing reference of pickUpTutorial sprite.");

        if (petDog == null)
            throw new MissingReferenceException("Missing reference of interactTutorial sprite.");
        
        imageTutorial = GetComponent<Image>();

        if (imageTutorial.enabled)
            imageTutorial.enabled = false;
    }

    public void InteractTutorial()
    {
        StartCoroutine(InteractCoroutine());
    }

    private IEnumerator InteractCoroutine()
    {
        imageTutorial.enabled = true;

        if (imageTutorial.sprite != interact)
            imageTutorial.sprite = interact;

        for (float a = 0; a <= 1; a += 0.03f)
        {
            imageTutorial.color = new Color(255, 255, 255, a);
            yield return null;
        }
    }

    public void PickUpTutorial()
    {
        StartCoroutine(PickUpCoroutine());
    }

    private IEnumerator PickUpCoroutine()
    {
        imageTutorial.enabled = true;

        if (imageTutorial.sprite != pickUp)
            imageTutorial.sprite = pickUp;

        for (float a = 0; a <= 1; a += 0.03f)
        {
            imageTutorial.color = new Color(255, 255, 255, a);
            yield return null;
        }
    }

    public void PetDogTutorial()
    {
        StartCoroutine(PetDogCoroutine());
    }

    private IEnumerator PetDogCoroutine()
    {
        imageTutorial.enabled = true;

        if (imageTutorial.sprite != petDog)
            imageTutorial.sprite = petDog;

        for (float a = 0; a <= 1; a += 0.03f)
        {
            imageTutorial.color = new Color(255, 255, 255, a);
            yield return null;
        }
    }

    public void TutorialFadeOut()
    {
        StartCoroutine(TutorialFadeOutCoroutine());
    }

    private IEnumerator TutorialFadeOutCoroutine()
    {
        for (float a = 1; a >= 0f; a -= 0.03f)
        {
            imageTutorial.color = new Color(255, 255, 255, a);
            yield return null;
        }
        imageTutorial.enabled = false;
    }
}
