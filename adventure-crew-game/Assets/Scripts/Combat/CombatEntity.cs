using System;
using UnityEngine;

public class CombatEntity : MonoBehaviour
{
    public CombatEntity target = null;
    protected Stats stats;
    private float cooldown;
    private float timer = 0.0f;
    public enum CurrentAction
    {
        idle,
        moving,
        attacking
    }
    public CurrentAction currentAction = CurrentAction.idle;

    void Start()
    {
        EntityInitializer();
    }
    private void EntityInitializer()
    {
        //tag check
        if (CompareTag("Adventurer") == false && CompareTag("Enemy") == false) Debug.LogWarning("This entity is set to the wrong tag");
        cooldown = 1.0f / stats.Agility;
    }

    public void DecideCombatAction()
    {
        currentAction = CurrentAction.idle;
        if (target == null)
        {
            if(FindTarget()) DecideCombatAction();
            //if can't find any opponent, then the combat is over
            else CombatManager.Instance.CombatOver();
        }
        else // move or attack
        {
            //Debug.Log("Distance: " + (target.transform.position - transform.position).magnitude);

            if ((target.transform.position - transform.position).magnitude > stats.Range) 
            {
                Debug.Log(gameObject.name + "'s action should be moving");
                currentAction = CurrentAction.moving; 
            }

            else currentAction = CurrentAction.attacking;
        }
        
    }

    virtual public bool FindTarget()
    {
        target = CombatManager.Instance.GetOpponent(transform.position, tag);
        return target != null;
        //if we are going to add a healer, we can override this method
        //and pass in the Enemy tag, so the healer find the target among adventurers
    }
    

    private bool MoveCheck()
    {
        if (target == null)
        {
            DecideCombatAction();
            return false;
        }
        if ((target.transform.position - transform.position).magnitude < stats.Range)
        {
            DecideCombatAction();
            return false;
        }
        return true;
    }
    public void Move(int agility)
    {
        //Debug.Log(gameObject.name + " Moving");
        Vector3 moveDir = (target.transform.position - transform.position).normalized;
        transform.position += moveDir * agility * Time.deltaTime;
        transform.LookAt(target.transform.position);
    }

    private bool AttackCheck()
    {
        if (target == null)
        {
            DecideCombatAction();
            return false;
        }
        if ((target.transform.position - transform.position).magnitude > stats.Range)
        {
            DecideCombatAction();
            return false;
        }
        return true;
    }
    public void Attack(int damage)
    {
        if (timer <= 0.0) 
        {
            timer = cooldown;
            target.TakeDamage(damage);

            //visual
            TurnToTarget(target.transform.position);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Got damage " + damage);
        stats.HP -= damage;
        Debug.Log(gameObject.name + "'s HP: " + stats.HP);

        //am I dead?
        if (stats.HP <= 0)
        {
            stats.HP = 0;
            Die();
        }

        OnStatsChanged();
    }
    virtual protected void OnStatsChanged()
    {
        //This function is for modifying adventurer's stats in scriptable object
        //for enemy, this function can left blank
        if(StatsChanged != null) StatsChanged(stats.HP, stats.MaxHP);
    }

    public Action<float, float> StatsChanged;
    //This action is subscribed by: HealthBarController

    private void TurnToTarget(Vector3 lookPos)
    {
        transform.LookAt(lookPos);
    }

    private void Die()
    {
        //Debug.Log("I die!");
        CombatManager.Instance.DestroyAnEntity(this, tag);
        Destroy(gameObject);
    }

    private void Update()
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
