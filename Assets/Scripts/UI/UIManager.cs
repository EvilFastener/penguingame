using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;

    [Header("Options")]
    [SerializeField] private GameObject optionsScreen;

    private bool isGamePaused = false;  // Przechowuje status pauzy

    private void Awake()
    {
        pauseScreen.SetActive(false);
        optionsScreen.SetActive(false);  // Domy�lnie ukrywamy ekran opcji
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionsScreen.activeInHierarchy)
            {
                CloseOptions();  // Zamknij opcje i wznow gr�
            }
            else if (pauseScreen.activeInHierarchy)
            {
                TogglePauseScreen(false);  // Wznow gr�
            }
            else
            {
                TogglePauseScreen(true);   // Pauzuj gr�
            }
        }
    }

    #region Pause
    public void TogglePauseScreen(bool status)
    {
        pauseScreen.SetActive(status);
        if (status)
        {
            Time.timeScale = 0;
            isGamePaused = true;
        }
        else
        {
            Time.timeScale = 1;
            isGamePaused = false;
        }
    }
    #endregion

    #region Options
    public void ToggleOptionsScreen(bool status)
    {
        optionsScreen.SetActive(status);
    }

    public void OpenOptions()
    {
        TogglePauseScreen(false);  // Pauza musi by� wy��czona, aby przej�� do opcji
        ToggleOptionsScreen(true);
    }

    public void CloseOptions()
    {
        ToggleOptionsScreen(false);
        if (isGamePaused)
        {
            TogglePauseScreen(true);  // Wznow gr�, je�li by�a pauzowana
        }
    }
    #endregion
}
