using UnityEngine;
using UnityEngine.UI;  // Для работы с UI (Text)

public class Coin : MonoBehaviour
{
    public int score = 0;  // Счёт
    public Text ScoreText;  // Текст для отображения счета
    public GameObject pickupEffect; // Эффект при сборе монеты
    public AudioClip collectSound; // Звук сбора монеты
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        UpdateScoreText();  // Обновляем текст с очками при старте
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Penguin")) // Если касается игрок
        {
            if (pickupEffect != null)
            {
                Instantiate(pickupEffect, transform.position, Quaternion.identity); // Создаём эффект
            }

            if (collectSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(collectSound); // Воспроизводим звук
            }

            Destroy(gameObject); // Удаляем монетку
            score += 10;  // Добавляем очки
            UpdateScoreText();  // Обновляем отображение счёта
        }
    }

    // Метод для обновления текста с текущим счётом
    void UpdateScoreText()
    {
        if (ScoreText != null)
        {
            ScoreText.text = "Score: " + score.ToString();  // Обновляем текст на экране
        }
    }
}
