using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Encounter : ScriptableObject
{
    public abstract void OnStart();
    public abstract void OnEnd();

}
