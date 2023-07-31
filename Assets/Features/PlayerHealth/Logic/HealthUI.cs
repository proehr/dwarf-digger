using System;
using System.Collections;
using System.Collections.Generic;
using Common.Logic.Variables;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {
    [SerializeField] private IntVariable maxHealth;
    [SerializeField] private IntVariable currentHealth;
    [SerializeField] private Image healthDisplayPrefab;
    [SerializeField] private Sprite fullHealthSprite;
    [SerializeField] private Sprite emptyHealthSprite;

    private List<Image> displayedIcons;

    private void Awake() {
        currentHealth.GetChangedEvent().RegisterListener(OnHealthChange);
        displayedIcons = new List<Image>();
        for (int i = 0; i < maxHealth.Get(); i++) {
            displayedIcons.Add(Instantiate(healthDisplayPrefab, transform));
        }
        OnHealthChange();
    }

    private void OnHealthChange() {
        for (int i = 0; i < currentHealth.Get(); i++) {
            displayedIcons[i].sprite = fullHealthSprite;
        }

        for (int i = currentHealth.Get(); i < maxHealth.Get(); i++) {
            displayedIcons[i].sprite = emptyHealthSprite;
        }
    }
}
