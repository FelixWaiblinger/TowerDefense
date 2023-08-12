using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private VoidEventChannel _defendEvent;
    [SerializeField] private IntEventChannel _buildOptionEvent;

    [Header("Counters")]
    [SerializeField] private TMP_Text _dayCount;
    [SerializeField] private TMP_Text _moneyCount;
    [SerializeField] private TMP_Text _researchCount;
    private int _day = 1;

    [Header("Build menu")]
    [SerializeField] private GameObject _buildMenu;


    #region SETUP

    void OnEnable()
    {
        InputReader.buildEvent += ToggleBuildMenu;
        _defendEvent.OnVoidEventRaised += () => _dayCount.text = $"Day\n{++_day}";
    }

    void OnDisable()
    {
        InputReader.buildEvent -= ToggleBuildMenu;
    }

    void Start()
    {
        _dayCount.text = $"Day\n{_day}";
        _moneyCount.text = "100";
        _researchCount.text = "0";
    }

    #endregion

    public void UpdateMoney(int amount)
    {
        _moneyCount.text = amount.ToString();
    }

    public void UpdateResearch(int amount)
    {
        _researchCount.text = amount.ToString();
    }

    #region BUTTONS

    public void EndTurn()
    {
        _defendEvent.RaiseVoidEvent();
    }

    public void ToggleBuildMenu()
    {
        _buildMenu.SetActive(!_buildMenu.activeSelf);
    }

    public void BuildOption(int index)
    {
        _buildOptionEvent.RaiseIntEvent(index);
    }

    #endregion
}
