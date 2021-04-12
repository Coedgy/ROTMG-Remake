using UnityEngine;

public class HUDeventManager : MonoBehaviour
{
    public GameObject characterStatsPanel;

    public void OpenCharacterStats()
    {
        characterStatsPanel.SetActive(!characterStatsPanel.activeInHierarchy);
    }
}
