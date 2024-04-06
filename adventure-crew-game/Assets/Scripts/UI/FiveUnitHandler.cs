using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiveUnitHandler : MonoBehaviour
{
    [SerializeField] private OnboardingManager onboardingManager;

    // Start is called before the first frame update
    void Start()
    {
        onboardingManager = GameObject.Find("Onboarding Manager").GetComponent<OnboardingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
