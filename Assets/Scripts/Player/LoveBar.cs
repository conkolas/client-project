using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoveBar : MonoBehaviour {
    public int TotalProgress = 5;
    public GameEvent OnGameEnd;
    private int _currentProgress;
    private Slider _slider;

    void Start() {
        _slider = GetComponentInChildren<Slider>();
        _slider.minValue = 0;
        _slider.maxValue = TotalProgress;
        _slider.value = 0;
    }

    public void Add() {
        _currentProgress++;
        if (_currentProgress == TotalProgress) {
            OnGameEnd?.Raise();
        }
        _slider.value = _currentProgress;
    }

    public void Restart() {
        _currentProgress = 0;
        _slider.value = 0;
    }
}
