using UnityEngine;
using UnityEngine.UI;

public class EntityUI : MonoBehaviour
{
    #region VARIABLE

    [Header("Status")]
    [Tooltip("Current amount of health on this instance")]
    [SerializeField] private Image _healthBar;
    [Tooltip("Change healthbar smoothly")]
    [SerializeField] private float _smoothness = 1;

    private float _targetRatio = 1;
    private Camera _camera;

    #endregion

    void Start()
    {
        _healthBar.fillAmount = _targetRatio;
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        // always face camera
        transform.rotation = _camera.transform.rotation;

        _healthBar.gameObject.SetActive(_healthBar.fillAmount != 1); // inefficient

        if (_healthBar.fillAmount == _targetRatio) return;

        // update healthbar towards current health percentage
        _healthBar.fillAmount = Mathf.MoveTowards(
            _healthBar.fillAmount,
            _targetRatio,
            _smoothness * Time.deltaTime
        );
    }

    public void UpdateHealth(float ratio)
    {
        _targetRatio = ratio;
    }
}
