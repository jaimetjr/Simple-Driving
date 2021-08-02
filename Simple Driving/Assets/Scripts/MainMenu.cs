using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _highScoreText;
    [SerializeField] private TMP_Text _energyText;
    [SerializeField] private int _maxEnergy;
    [SerializeField] private int _energyRechargeDuration;
    private int energy;
    private const string EnergyKey = "Energy";
    private const string EnergyReadyKey = "EnergyReady";


    public void Start()
    {
        _highScoreText.text = "High Score: " + PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0);
        energy = PlayerPrefs.GetInt(EnergyKey, _maxEnergy);

        if (energy == 0)
        {
            string energyReady = PlayerPrefs.GetString(EnergyReadyKey, string.Empty);

            if (string.IsNullOrEmpty(energyReady))
                return;

            DateTime energyReadDt = DateTime.Parse(energyReady);

            if (DateTime.Now > energyReadDt)
            {
                energy = _maxEnergy;
                PlayerPrefs.SetInt(EnergyKey, energy);
            }
        }

        _energyText.text = $"Play ({energy})";
    }

    public void Play()
    {
        if (energy < 1)
            return;

        energy--;
        PlayerPrefs.SetInt(EnergyKey, energy);

        if (energy == 0)
        {
            DateTime energyReady = DateTime.Now.AddMinutes(_energyRechargeDuration);
            PlayerPrefs.SetString(EnergyReadyKey, energyReady.ToString());
        }
        

        SceneManager.LoadScene(1);
    }
}
