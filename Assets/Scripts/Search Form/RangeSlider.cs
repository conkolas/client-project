using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeSlider : MonoBehaviour {
    public RectTransform Position25;
    public RectTransform Position50;
    public RectTransform Position100;
    public RectTransform Position150;
    public RectTransform Position200;
    public RectTransform Handle;
    public SearchFormManager SearchFormManager;
    private void Start() {
        Handle.position = Position25.position;
    }

    public void OnValueChange(float value) {
        Vector3 position = Position25.position;
        if (value >= 0 && value < 0.2f) {
            position = Position25.position;
            SearchFormManager.SetCurrentRange(SearchRanges.TWENTY_FIVE);
        } else if (value >= 0.2f && value < 0.4f) {
            position = Position50.position;
            SearchFormManager.SetCurrentRange(SearchRanges.FIFTY);
        } else if (value >= 0.4f && value < 0.6f) {
            position = Position100.position;
            SearchFormManager.SetCurrentRange(SearchRanges.HUNDRED);
        } else if (value >= 0.6f && value < 0.8f) {
            position = Position150.position;
            SearchFormManager.SetCurrentRange(SearchRanges.HUNDRED_FIFTY);
        } else if (value >= 0.8f && value <= 1f) {
            position = Position200.position;
            SearchFormManager.SetCurrentRange(SearchRanges.TWO_HUNDREDS);
        }

        Handle.position = position;
    }
}
