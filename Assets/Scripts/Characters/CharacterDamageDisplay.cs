using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterDamageDisplay : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private MeshRenderer[] _renderers;
    [SerializeField] private Color _damageColor;

    [SerializeField] [Range(0f, 0.3f)] private float _scaleDuration;
    [SerializeField] [Range(0.5f, 1f)] private float _scaleAmount;
    [SerializeField] [Range(0f, 1)] private float _displayDurationInSeconds;

    #region MonoBehaviour

    private void OnEnable()
    {
        _character.OnDamageTaken += DisplayDamage;
    }

    private void OnDisable()
    {
        _character.OnDamageTaken -= DisplayDamage;
    }

    #endregion

    public void DisplayDamage()
    {
        DisplayScale();
        StartCoroutine(DisplayColor());
    }

    private void DisplayScale()
    {
        DOTween.Sequence()
            .Append(transform.DOScale(.8f, _scaleDuration))
            .Append(transform.DOScale(1f, _scaleDuration));
    }

    private IEnumerator DisplayColor()
    {
        var originalColors = new List<Color>();

        for (var i = 0; i < _renderers.Length; i++)
            originalColors.Add(_renderers[i].material.color);

        foreach (var renderer in _renderers)
            renderer.material.color = _damageColor;

        yield return new WaitForSeconds(_displayDurationInSeconds);

        for (var i = 0; i < _renderers.Length; i++)
            _renderers[i].material.color = originalColors[i];
    }
}
