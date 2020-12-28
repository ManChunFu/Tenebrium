using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SoundManager : MonoBehaviour
{
    //Uses a simple singleton so it can be used anyware in the scene
    public static SoundManager Sound;

    [SerializeField] AK.Wwise.Bank MasterBank;
    [SerializeField] AK.Wwise.Event AmbienceEvent;
    [SerializeField] AK.Wwise.Event MusicEvent;
    [SerializeField] GameObject AirlockObj;
    [SerializeField] GameObject DicontaminationObj;
    [SerializeField] GameObject ComputerBeeps;
    [SerializeField] GameObject StaticNoise;
    #region SFX
    [System.Serializable]
    public struct SFXLibrary
    {
        //Hard coded so when others write code they can use for example:
        //SoundManager.Sound.SFX.DoorOpen.Post(gameObject);
        //To play sounds
        public AK.Wwise.Event Airlock;
        public AK.Wwise.Event AlarmLoop;
        
        public AK.Wwise.Event ButtonPressSuccessful;
        public AK.Wwise.Event ButtonPressUnsuccessful;

        public AK.Wwise.Event ComputerBeepLoop;
        public AK.Wwise.Event ConfirmBeep;
        public AK.Wwise.Event Cryopod;
        public AK.Wwise.Event CollisionMetal;
        public AK.Wwise.Event CollisionPorsline;
        public AK.Wwise.Event CollisionPlastic;

        public AK.Wwise.Event DogHappy;
        public AK.Wwise.Event DogMovement;
        public AK.Wwise.Event DogHover;
        public AK.Wwise.Event DogDie;
        public AK.Wwise.Event DoorClose;
        public AK.Wwise.Event DoorOpen;
        public AK.Wwise.Event DicontaminationChamber;
        public AK.Wwise.Event DestructiblePorsline;
        public AK.Wwise.Event DestructibleGlass;

        public AK.Wwise.Event Explosion;
        public AK.Wwise.Event ElectricLoop;

        public AK.Wwise.Event FireLoop;
        public AK.Wwise.Event FootstepRight;
        public AK.Wwise.Event FootstepLeft;

        public AK.Wwise.Event Pause;
        public AK.Wwise.Event Pickup;
        public AK.Wwise.Event PuzzleComplete;
        public AK.Wwise.Event PuzzleInsert;
        public AK.Wwise.Event PuzzleOpen;

        public AK.Wwise.Event RadioLoopOn;
        public AK.Wwise.Event RadioLoopOff;
        public AK.Wwise.Event Rumble;

        public AK.Wwise.Event StaticNoiseLoop;

        public AK.Wwise.Event TerminalInteraction;

        public AK.Wwise.Event Unpause;
        public AK.Wwise.Event UIClick;

        public AK.Wwise.Event VendingMachineButton;
        public AK.Wwise.Event VendingMachineDispens;       
    }

    [SerializeField] public SFXLibrary SFX;
    #endregion

    #region VO
    [System.Serializable]
    public struct VO
    {
        public int ID;
        public AK.Wwise.Event Event;
    }

    [SerializeField] VO[] _vo;
    Dictionary<int, AK.Wwise.Event> _voLookUp = new Dictionary<int, AK.Wwise.Event>();
    #endregion

    private int _curID;

    private void Awake()
    {
        //Load Soundbank into memory
        MasterBank.Load();

        if (Sound != null) Destroy(gameObject);
        else Sound = this;

        //Add VO to dictionary
        foreach (var VO in _vo)
            _voLookUp.Add(VO.ID, VO.Event);     
    }

    //Sets state to 1, starts ambient and music events
    //Changes in ambience and music is handled with the Progress function
    void Start()
    {
        AmbienceEvent.Post(gameObject);
        MusicEvent.Post(gameObject);
        StartCoroutine(StartSound());
    }

    IEnumerator StartSound()
    {
        yield return new WaitForSeconds(3);
        ComputerBeeps.SetActive(true);
        StaticNoise.SetActive(true);
    }

    //State, input a number between 1-9
    // 1. Waking up - opening scene
    // 2. RESA - Meeting dog
    // 3. Who Shall I Trust - First dialogue with Liu Yang
    // 4. Second Explosion - Radiation shielding fails
    //
    //Endings:
    // 6. Leaving - Go with Liu Yang
    // 7. Sacrifice - Remove battery from RESA
    // 8. Sabotage - Sabotage shuttle and remove battery from RESA
    // 9. Survive - other endings
    public void Progress(int Progress_one_to_nine)
    {
        if(Progress_one_to_nine <= 9 && Progress_one_to_nine > 0)
        {
            string _progress = "Progress" + Progress_one_to_nine;
            AkSoundEngine.SetState("Progress", _progress);
        }
        else Debug.Log("SoundManager: Progress state change needs to be a number between 1-9");
    }

    #region EffectsForDesigners
    //Timeline sound effects functions
    public void ExlosionSFX(GameObject Object)
    {
        SFX.Explosion.Post(Object);
    }

    public void RumbleSFX(GameObject Object)
    {
        SFX.Rumble.Post(Object);
    }

    public void DicontaminationSFX()
    {
        DicontaminationObj.SetActive(true);
    }

    public void Airlock()
    {
        AirlockObj.SetActive(true);
    }

    public void Cryopod()
    {
        SFX.Cryopod.Post(gameObject);
    }

    public void PuzzleComplete(GameObject Object)
    {
        SFX.PuzzleComplete.Post(Object);
    }

    public void PuzzleInsert(GameObject Object)
    {
        SFX.PuzzleInsert.Post(Object);
    }

    public void PuzzleOpen(GameObject Object)
    {
        SFX.PuzzleOpen.Post(Object);
    }

    public void AlarmLoop(GameObject Object)
    {
        SFX.AlarmLoop.Post(Object);
    }

    public void DogDie(GameObject Object)
    {
        SFX.DogDie.Post(Object);
    }

    public void RadioLoopOn(GameObject Object)
    {
        SFX.RadioLoopOn.Post(Object);
    }

    public void RadioLoopOff(GameObject Object)
    {
        SFX.RadioLoopOff.Post(Object);
    }

    //For menus
    public void UIClick()
    {
        SFX.UIClick.Post(gameObject);
    }
    #endregion

    #region VO
    //Becuase of Unitys event system can't handle multible variables nor overloads it's sectioned into steps
    //First call VO_ID to set which voiceline to choose audio event
    public void VO_ID (int VoiceLineID)
    {
        _curID = VoiceLineID;
    }

    //Then use this if you want a 2D sound
    public void VO_2D()
    {
        if (_voLookUp.ContainsKey(_curID))
        {
            _voLookUp[_curID].Post(gameObject);
        }
        else Debug.Log("Soundmanager: A voice line with that ID does'nt exist");
    }

    //or use this for a 3D sound, attaches to an gameobject 
    public void VO_3D(GameObject Object)
    {
        if (_voLookUp.ContainsKey(_curID))
        {
            _voLookUp[_curID].Post(Object);
        }
        else Debug.Log("Soundmanager: A voice line with that ID does'nt exist");
    }

    //Stops a voiceline
    public void StopVoiceLine(GameObject Object)
    {
        if (_voLookUp.ContainsKey(_curID))
        {
            _voLookUp[_curID].Stop(Object);
        }
        else Debug.Log("Soundmanager: A voice line with that ID does'nt exist");
    }
    #endregion

    #region Otions
    //Sound options
    public void SetMasterVolume(int Volume)
    {
        AkSoundEngine.SetRTPCValue("MasterVolume", Volume);
    }

    public void SetEffectsVolume(int Volume)
    {
        AkSoundEngine.SetRTPCValue("EffectsVolume", Volume);
    }

    public void SetAmbienceVolume(int Volume)
    {
        AkSoundEngine.SetRTPCValue("AmbientVolume", Volume);
    }

    public void SetMusicVolume(int Volume)
    {
        AkSoundEngine.SetRTPCValue("MusicVolume", Volume);
    }

    public void SetVoiceVolume(int Volume)
    {
        AkSoundEngine.SetRTPCValue("VoiceVolume", Volume);
    }
    #endregion
}