using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBulletTime : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0.2f;
    }
    private void OnDisable()
    {
        Time.timeScale = 1.0f;
    }
}
