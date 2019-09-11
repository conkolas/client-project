﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Pluggable AI/Decisions/Chase Player")]
public class ChaseDecision : PluggableDecision
{
    public override bool Decide(StateController controller) {
        bool targetInRangeAndFocused = Chase(controller);
        return targetInRangeAndFocused;
    }

    private bool Chase(StateController controller) {
        return controller.FocusPetID == controller.Pet.ID;
    }
}
