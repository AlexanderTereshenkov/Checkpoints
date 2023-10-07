using System.Collections;
using TMPro;
using UnityEngine;

public class GameStateUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiText;

    public void ShowCnagedLap()
    {
        uiText.text = "+1  –”√";
        StartCoroutine(TimeCroutine());
    }

    public void ShowFinalScreen()
    {
        uiText.text = "‘»Õ¿À";
    }

    private IEnumerator TimeCroutine()
    {
        yield return new WaitForSeconds(2f);
        uiText.text = "";
        yield break;
    }

}
