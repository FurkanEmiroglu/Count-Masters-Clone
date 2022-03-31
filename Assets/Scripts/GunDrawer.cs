using UnityEngine;

public class GunDrawer : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
        GameEvents.current.OnFightZoneTriggerEnter += gunEnabler;
        GameEvents.current.OnFightZoneTriggerExit += gunDisabler;
    }

    void gunEnabler()
    {
        gameObject.SetActive(true);
    }

    void gunDisabler()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        GameEvents.current.OnFightZoneTriggerEnter -= gunEnabler;
        GameEvents.current.OnFightZoneTriggerExit -= gunDisabler;
    }
}
