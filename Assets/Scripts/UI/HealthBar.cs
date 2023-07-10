using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Character _target;
    [SerializeField] private Slider _slider;

    #region MonoBehaviour

    private void OnEnable()
    {
        _target.OnHealthChanged += UpdateHealth;
    }

    private void OnDisable()
    {
        _target.OnHealthChanged -= UpdateHealth;
    }

    private void Start()
    {
        var initialHealth = _target.Stats.HealthAmount;
        UpdateHealth(initialHealth);
    }

    #endregion    

    private void UpdateHealth(float amount)
    {
        _slider.value = amount;
    }
}
