using System;
using DG.Tweening;
using Kino;
using Unity.Mathematics;
using UnityEngine;
using static GameManager;

public class GlitchManager : MonoBehaviour
{
    public AnalogGlitch analog;
    public DigitalGlitch digital;
    public GameManager gameManager;
    private float glitchMultiplier;

    internal void OpeningGlitch()
    {
        AdjustDigiIntensity(.01f, 1);
    }

    void Start()
    {
        if (!gameManager)
            gameManager = FindAnyObjectByType<GameManager>();
        setGlitchMultiplier();
    }

    void setGlitchMultiplier()
    {
        switch (gameManager.glitchLevel)
        {
            case GlitchLevel.normalGlitch:
                glitchMultiplier = 1;
                break;
            case GlitchLevel.LowGlitch:
                glitchMultiplier = .5f;
                break;
            case GlitchLevel.NoGlitch:
                glitchMultiplier = 0;
                break;
        }
    }

    void Update()
    {
        if (!gameManager)
            gameManager = FindAnyObjectByType<GameManager>();
        setGlitchMultiplier();
        if (glitchMultiplier == 0)
        {
            digital.intensity = 0;
            analog.scanLineJitter = 0;
            analog.verticalJump = 0;
            analog.horizontalShake = 0;
            analog.colorDrift = 0;
        }
    }

    internal void AdjustDigiIntensity(float newIntensity, float time)
    {
        newIntensity = math.clamp(newIntensity, 0, 1) * glitchMultiplier;
        DOTween.To(() => digital.intensity, x => digital.intensity = x, newIntensity, time);
    }

    internal void AdjustAnalogScanLineJitter(float newVal, float time)
    {
        newVal = math.clamp(newVal, 0, 1) * glitchMultiplier;
        DOTween.To(() => analog.scanLineJitter, x => analog.scanLineJitter = x, newVal, time);
    }

    internal void AdjustVerticalJump(float newVal, float time)
    {
        newVal = math.clamp(newVal, 0, 1) * glitchMultiplier;
        DOTween.To(() => analog.verticalJump, x => analog.verticalJump = x, newVal, time);
    }

    internal void AdjustHorizontalShake(float newVal, float time)
    {
        newVal = math.clamp(newVal, 0, 1) * glitchMultiplier;
        DOTween.To(() => analog.horizontalShake, x => analog.horizontalShake = x, newVal, time);
    }

    internal void AdjustColorDrift(float newVal, float time)
    {
        newVal = math.clamp(newVal, 0, 1) * glitchMultiplier;
        DOTween.To(() => analog.colorDrift, x => analog.colorDrift = x, newVal, time);
    }
}
