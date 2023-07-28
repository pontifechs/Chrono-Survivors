using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Experience : MonoBehaviour
{
    [SerializeField] private Slider xpBar;
    [SerializeField] private TextMeshProUGUI levelText;

    public Action<int> OnLevelUp;
    
    private static int[] xpSchedule = { 10, 15, 20, 25, 30, 35, 40 };
    
    private int level = 0;
    private int experience = 0;

    private void Awake()
    {
        updateDisplay();
    }

    public void CollectExperience(int exp)
    {
        experience += exp;

        if (experience >= xpSchedule[level])
        {
            experience -= xpSchedule[level];
            level += 1;
            OnLevelUp?.Invoke(level + 1);
        }
        
        updateDisplay();
    }

    private void updateDisplay()
    {
        xpBar.value = experience / (float)xpSchedule[level];
        levelText.text = (level + 1).ToString();
    }
}