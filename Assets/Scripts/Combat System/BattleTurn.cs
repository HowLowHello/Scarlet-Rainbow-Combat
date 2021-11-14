using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TurnType { TurnEmpty, PlayerTurn, EnemyTurn, PartnerTurn }

public class BattleTurn
{
    public TurnType type;
    public BattleUnit subject;
    public string actionName;
    public Dictionary<string, int> battleTurnMeta;

    public BattleTurn(TurnType type, BattleUnit subject, string actionName, Dictionary<string, int> args)
    {
        this.type = type;
        this.subject = subject;
        this.actionName = actionName;
        this.battleTurnMeta = new Dictionary<string, int>(args);
    }

    public BattleTurn()
    {
        this.type = TurnType.TurnEmpty;
    }

    public virtual void ProcessTurn()
    {
        if (type == TurnType.TurnEmpty)
        {
            this.OnEmptyTurn();
            return;
        }
        else if (type == TurnType.PlayerTurn)
        {
            if (!(subject is PlayerUnit))
            {
                Debug.LogError("Player Turn does not have the correct subject!");
                return;
            }
            PlayerUnit player = (PlayerUnit)subject;
            this.OnPlayerTurn(player);
        }
        else if (type == TurnType.EnemyTurn)
        {
            if (!(subject is EnemyUnit))
            {
                Debug.LogError("Enemy Turn does not have the correct subject!");
                return;
            }
            EnemyUnit enemy = (EnemyUnit)subject;
            this.OnEnemyTurn(enemy);
        }
        else if (type == TurnType.PartnerTurn)
        {
            // do partner stuff
        }
    }
    private void OnEmptyTurn()
    {
        throw new NotImplementedException();
    }

    private void OnEnemyTurn(EnemyUnit enemy)
    {
        throw new NotImplementedException();
    }

    private void OnPlayerTurn(PlayerUnit player)
    {
        throw new NotImplementedException();
    }

}
