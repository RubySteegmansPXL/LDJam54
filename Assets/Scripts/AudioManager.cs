using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] turtleShootsSounds;
    public AudioClip[] wallHitSounds;
    public AudioClip towerPlacedSound;
    public AudioClip startGameSound;
    public AudioClip gameOverSound;
    public AudioSource audioSource;
    public AudioClip powerupPickupSound;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnEnable()
    {
        EventManager.OnTowerPlaced += PlayerTowerPlacedSound;
        EventManager.OnMoneyGained += PlayerTowerPlacedSound;
        EventManager.OnItemBought += PlayerTowerPlacedSound;
        EventManager.OnWaveCompleted += PlayerTowerPlacedSound;
        EventManager.OnDamageTaken += PlayerTowerPlacedSound;
    }

    private void PlayerTowerPlacedSound()
    {
        audioSource.clip = towerPlacedSound;
        audioSource.Play();
    }
}
