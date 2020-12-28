using UnityEngine;

public class BackToGame : MonoBehaviour
{
    [SerializeField] private GameObject settingPanel = null;

    private void Awake()
    {
        if (settingPanel == null)
            throw new MissingReferenceException("Missing reference of SettingPanel gameObject");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            settingPanel.SetActive(false);
    }
}
