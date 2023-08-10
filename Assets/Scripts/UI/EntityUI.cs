using UnityEngine;
using UnityEngine.UI;

public class EntityUI : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private float _speed = 1;

    private float _targetRatio = 1;

    void Start()
    {
        _healthBar.fillAmount = _targetRatio;
    }

    void Update()
    {
        _healthBar.fillAmount = Mathf.MoveTowards(
            _healthBar.fillAmount,
            _targetRatio,
            _speed * Time.deltaTime
        );
    }

    public void UpdateHealth(float ratio)
    {
        _targetRatio = ratio;
    }
}
