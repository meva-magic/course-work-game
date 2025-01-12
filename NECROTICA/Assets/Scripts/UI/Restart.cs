using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    /*public GameObject loadingScreen; // UI экран загрузки
    public float timer = 10f; // Таймер для активации проверки
    private bool isChecking = false; // Флаг, чтобы начать проверку после таймера

    public RoomTemplates roomTemplates; // Ссылка на RoomTemplates

    private void Start()
    {
        if (loadingScreen != null)
        {
            loadingScreen.SetActive(true); // Активируем экран загрузки при старте
        }
    }

    private void Update()
    {
        // Отсчитываем таймер
        if (!isChecking)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                isChecking = true; // Активируем проверку, когда таймер истёк
            }
        }

        // Выполняем проверку только после истечения таймера
        if (isChecking)
        {
            CheckConditionsAndRestart();
        }
    }

    // Метод проверки условий и рестарта уровня
    private void CheckConditionsAndRestart()
    {
        bool hasEnoughRooms = roomTemplates.rooms.Count >= 14;
        bool bossExists = GameObject.Find("Boss(Clone)") != null;
        //bool keykeeperExists = GameObject.Find("keykeeper(Clone)") != null;

        // Если условия не выполняются, перезагружаем сцену
        if (!hasEnoughRooms || !bossExists )
        {
            RestartLevel();
        }
        else if (loadingScreen != null)
        {
            loadingScreen.SetActive(false); // Деактивируем экран загрузки, если всё ок
            isChecking = false; // Останавливаем проверки
        }
    }

    // Метод для перезапуска уровня
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }*/
}
