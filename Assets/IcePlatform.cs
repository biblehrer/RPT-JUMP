using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IcePlatform : MonoBehaviour
{
    public GameObject iceBreakEffect; // Сюда добавляем Particle System

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Penguin")) // Если пингвин наступил
        {
            Instantiate(iceBreakEffect, transform.position, Quaternion.identity); // Запускаем эффект частиц
            Destroy(gameObject); // Удаляем льдинку
        }
    }
}