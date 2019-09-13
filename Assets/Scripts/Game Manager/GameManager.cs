using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public IntegerVariable FocusedPetID;
    public IntegerVariable HoveredPetID;
    public GameEvent OnGameStart;

    private void Start()
    {
        FocusedPetID.SetValue(0);
        HoveredPetID.SetValue(0);
        OnGameStart.Raise();
    }
}
