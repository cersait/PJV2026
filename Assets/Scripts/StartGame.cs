using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Collections;
using UnityEngine.Rendering;

public class StartGame : MonoBehaviour
{
    [SerializeField] Transform title;

    [SerializeField] Transform buttonImage;

    [SerializeField] Transform pastObjects;

    [SerializeField] Volume volume;
    [SerializeField] SpriteRenderer fadeToBlack;
    [SerializeField] AudioSource audio;
    [SerializeField] float speedMult = 0.5f;

    [SerializeField] int targetScene;


    public void StartThe_StartTheGame()
    {
        StartCoroutine("StartTheGame");
    }

    public IEnumerator StartTheGame()
    {
        buttonImage.gameObject.SetActive(false);
        title.gameObject.SetActive(false);
        pastObjects.gameObject.SetActive(true);

        volume.weight = 1;
        audio.Play();

        while(volume.weight - Time.deltaTime > 0)
        {
            volume.weight -= Time.deltaTime * speedMult;
            audio.volume -= Time.deltaTime * speedMult;

            yield return new WaitForEndOfFrame();
        }

        volume.weight = 0;

        while(fadeToBlack.color.a + Time.deltaTime < 1)
        {
            fadeToBlack.color += new Color(0, 0, 0, Time.deltaTime * speedMult);
            yield return new WaitForEndOfFrame();
        }
        fadeToBlack.color = Color.black;

        SceneManager.LoadScene(targetScene);
    }
}
