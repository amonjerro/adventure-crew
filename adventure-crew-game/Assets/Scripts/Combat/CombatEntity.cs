using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEntity : MonoBehaviour
{
    public CombatEntity target = null;
    public Stats stats;

    public enum CurrentAction
    {
        idle,
        moving,
        attacking
    }
    public CurrentAction currentAction;

    void Start()
    {
        //tag check
        if (CompareTag("Adventurer") == false && CompareTag("Enemy") == false) Debug.LogWarning("This entity is set to the wrong tag");
        currentAction = CurrentAction.idle;
    }

    public void DecideCombatState()
    {
        currentAction = CurrentAction.idle;
        if (target == null)
        {
            FindTarget();
            //if can't find any opponent, then the combat is over
            if (target == null) CombatManager.Instance.CombatOver();
            else DecideCombatState();
        }
        else // move or attack
        {
            Debug.Log("Distance: " + (target.transform.position - transform.position).magnitude);

            if ((target.transform.position - transform.position).magnitude > stats.Range) currentAction = CurrentAction.moving;

            else currentAction = CurrentAction.attacking;
        }
        
    }

    public void FindTarget()
    {
        if (CompareTag("Adventurer"))
        {
            target = GetClosestOpponent(CombatManager.Instance.enemies);
        }
        else if (CompareTag("Enemy"))
        {
            target = GetClosestOpponent(CombatManager.Instance.adventurers);
        }
    }
    private CombatEntity GetClosestOpponent(List<CombatEntity> opponents)
    {
        if (opponents.Count == 0) return null; //check there still are opponents in the scene

        float distance = float.MaxValue;
        foreach (CombatEntity opponent in opponents)
        {
            if ((opponent.transform.position - transform.position).magnitude < distance)
            {
                target = opponent;
            }
        }
        return target;
    }

    private bool MoveCheck()
    {
        if (target == null)
        {
            DecideCombatState();
            return false;
        }
        if ((target.transform.position - transform.position).magnitude < stats.Range)
        {
            DecideCombatState();
            return false;
        }
        return true;
    }
    public void Move(int agility)
    {
        Debug.Log(gameObject.name + " Moving");
        Vector3 moveDir = (target.transform.position - transform.position).normalized;
        transform.position += moveDir * agility * Time.deltaTime;
        transform.LookAt(target.transform.position);

    }

    private bool AttackCheck()
    {
        if (target == null)
        {
            DecideCombatState();
            return false;
        }
        if ((target.transform.position - transform.position).magnitude > stats.Range)
        {
            DecideCombatState();
            return false;
        }
        return true;
    }
    public void Attack(int damage)
    {

    }

    private void FixedUpdate()
    {
        switch (currentAction)
        {
            case CurrentAction.idle:
                break;
            case CurrentAction.moving:
                if(MoveCheck()) Move(stats.Agility);
                break;
            case CurrentAction.attacking:
                if(AttackCheck()) Attack(stats.Damage);
                break;
            default: break;
        }
    }
}
