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
    public AudioClip moneyGainedSound;
    public AudioClip itemBoughtSound;
    public AudioClip waveCompletedSound;
    public AudioClip damageTakenSound;
    public AudioSource audioSource;
    public AudioClip powerupPickupSound;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnEnable()
    {
        EventManager.OnTowerPlaced += PlayerTowerPlacedSound;
        EventManager.OnMoneyGained += MoneyGained;
        EventManager.OnItemBought += ItemBought;
        EventManager.OnWaveCompleted += WaveCompleted;
        EventManager.OnDamageTaken += DamageTaken;
        EventManager.OnGameStart += GameStarted;
        EventManager.OnTurtleShoots += TurtleShoots;
        EventManager.OnGameOver += GameOver;
    }

    private void OnDisable()
    {
        EventManager.OnTowerPlaced -= PlayerTowerPlacedSound;
        EventManager.OnMoneyGained -= MoneyGained;
        EventManager.OnItemBought-= ItemBought;
        EventManager.OnWaveCompleted -= WaveCompleted;
        EventManager.OnDamageTaken -= DamageTaken;
        EventManager.OnGameStart -= GameStarted;
        EventManager.OnTurtleShoots -= TurtleShoots;
        EventManager.OnGameOver -= GameOver;
    }
    private void PlayerTowerPlacedSound()
    {
        audioSource.clip = towerPlacedSound;
        audioSource.Play();
    }
    private void MoneyGained()
    {
        audioSource.clip = moneyGainedSound;
        audioSource.Play();
    }
    private void GameStarted()
    {
        audioSource.clip = startGameSound;
        audioSource.Play();
    }

    private void TurtleShoots()
    {
        int randIntSound = Random.Range(0, turtleShootsSounds.Length - 1);
        audioSource.clip = turtleShootsSounds[randIntSound];
        audioSource.Play();
    }

    private void ItemBought()
    {
        audioSource.clip = itemBoughtSound;
        audioSource.Play();
    }
    private void WaveCompleted()
    {
        audioSource.clip = itemBoughtSound;
        audioSource.Play();
    }

    private void DamageTaken()
    {
        audioSource.clip = damageTakenSound;
        audioSource.Play();
    }

    private void GameOver()
    {
        audioSource.clip = gameOverSound;
        audioSource.Play();
    }
}
