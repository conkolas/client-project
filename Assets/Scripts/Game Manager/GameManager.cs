using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameEvent OnGameStart;

    private void Start()
    {
        OnGameStart.Raise();
    }
}
