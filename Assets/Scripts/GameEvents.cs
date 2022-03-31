using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    // ToDo Ate? etme sesleri de onFightZoneTrigger'a invokelu halde eklenecek.
    public event Action OnFightZoneTriggerEnter;

    public void FightZoneTriggerEnter()
    {
        OnFightZoneTriggerEnter?.Invoke();
    }


    public event Action OnFightZoneTriggerExit;

    public void FightZoneTriggerExit()
    {
        OnFightZoneTriggerExit?.Invoke();
    }
}
