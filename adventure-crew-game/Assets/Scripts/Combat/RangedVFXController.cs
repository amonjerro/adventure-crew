using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RangedVFXController : MonoBehaviour
{
    private IEnumerator coroutine;
    private float intervals = 20.0f;
    private void Start()
    {
        GetComponent<CombatEntity>().OnAttack += ShootVFX;

    }
    private void OnDisable()
    {
        GetComponent<CombatEntity>().OnAttack -= ShootVFX;
    }
    private void ShootVFX(Vector3 startPos, Vector3 targetPos)
    {
        GameObject vfx = VFXPool.SharedInstance.GetPooledObject();
        if(vfx == null)
        {
            Debug.LogWarning("Not enough pooled objects or you didn't assign the asset");
            return;
        }
        vfx.transform.position = transform.position;
        vfx.transform.rotation = transform.rotation;
        float lifeTime = vfx.GetComponent<ParticleSystem>().main.duration;

        coroutine = WaitAndKillVFX(vfx, startPos, targetPos, lifeTime);
        StartCoroutine(coroutine);
    }
    private IEnumerator WaitAndKillVFX(GameObject vfx, Vector3 startPos, Vector3 targetPos, float lifeTime)
    {
        for (int i = 0; i < intervals; i++)
        {
            vfx.transform.position = Vector3.Lerp(startPos, targetPos, (float)i/intervals);
            yield return new WaitForSeconds(lifeTime/intervals);
        }
        
        vfx.SetActive(false);
    }
}
