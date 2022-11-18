using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public enum VFX
{
    hitEffect,
    deadEffect,
    upgradeEffect
}

public class VFXManager : Singleton<VFXManager>
{
    [SerializeField] private ParticleSystem hitEffect;

    public void PlayHitEffect()
    {
        hitEffect.Play();
    }
}
