using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlider : MonoBehaviour
{
    public List<BattleTurn> battleTurns = new List<BattleTurn>();
    private bool canContinue = true;

    public void PauseTicking()
    {
        this.canContinue = false;
    }

    public void ContinueTicking()
    {
        this.canContinue = true;
    }

    void Update()
    {
        if (canContinue)
        {
            this.TickAnotherTurn();
        }
    }

    private void TickAnotherTurn()
    {
        throw new NotImplementedException();
    }
}
