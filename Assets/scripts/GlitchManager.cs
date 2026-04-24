using System;
using DG.Tweening;
using Kino;
using Unity.Mathematics;
using UnityEngine;

public class GlitchManager : MonoBehaviour
{
    public AnalogGlitch analog;
    public DigitalGlitch digital;

    internal void OpeningGlitch()
    {
        AdjustDigiIntensity(.01f, 1);
    }

    internal void AdjustDigiIntensity(float newIntensity, float time)
    {
        newIntensity = math.clamp(newIntensity, 0, 1);
        DOTween.To(() => digital.intensity, x => digital.intensity = x, newIntensity, time);
    }

    internal void AdjustAnalogScanLineJitter(float newVal, float time)
    {
        newVal = math.clamp(newVal, 0, 1);
        DOTween.To(() => analog.scanLineJitter, x => analog.scanLineJitter = x, newVal, time);
    }

    internal void AdjustVerticalJump(float newVal, float time)
    {
        newVal = math.clamp(newVal, 0, 1);
        DOTween.To(() => analog.verticalJump, x => analog.verticalJump = x, newVal, time);
    }

    internal void AdjustHorizontalShake(float newVal, float time)
    {
        newVal = math.clamp(newVal, 0, 1);
        DOTween.To(() => analog.horizontalShake, x => analog.horizontalShake = x, newVal, time);
    }

    internal void AdjustColorDrift(float newVal, float time)
    {
        newVal = math.clamp(newVal, 0, 1);
        DOTween.To(() => analog.colorDrift, x => analog.colorDrift = x, newVal, time);
    }
}
