using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    #region VARIABLE
    
    [Header("Events")]
    [Tooltip("Request the next step in the day/night cycle")]
    [SerializeField] private VoidEventChannel _requestTransitionEvent;
    [Tooltip("Select a build option from the UI")]
    [SerializeField] private IntEventChannel _buildOptionEvent;

    [Header("Counters")]
    [Tooltip("Display current day")]
    [SerializeField] private TMP_Text _dayCount;
    [Tooltip("Display current amount of money")]
    [SerializeField] private TMP_Text _moneyCount;
    [Tooltip("Display current amount of research")]
    [SerializeField] private TMP_Text _researchCount;

    [Header("Build menu")]
    [Tooltip("UI element containing all build options")]
    [SerializeField] private GameObject _buildMenu;

    #endregion

    #region SETUP

    void OnEnable()
    {
        InputReader.buildEvent += ToggleBuildMenu;
    }

    void OnDisable()
    {
        InputReader.buildEvent -= ToggleBuildMenu;
    }

    void Start()
    {
        _dayCount.text = "Day\n1";
        _moneyCount.text = "100";
        _researchCount.text = "0";
    }

    #endregion

    public void UpdateDay(int day)
    {
        _dayCount.text = $"Day\n{day}";
    }

    public void UpdateMoney(int amount)
    {
        _moneyCount.text = amount.ToString();
    }

    public void UpdateResearch(int amount)
    {
        _researchCount.text = amount.ToString();
    }

    #region BUTTON

    public void EndTurn()
    {
        _requestTransitionEvent.RaiseVoidEvent();

        // TODO deactivate button
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
