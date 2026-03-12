using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Collections;
public class BeginFadeToBlack : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] float fadeRate;
    [SerializeField] int targetScene;
    [SerializeField] SpriteRenderer self;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BeginTheFade()
    {
        StartCoroutine(FadeToBlack());
    }

    public IEnumerator FadeToBlack()
    {
        while (self.color != Color.black)
        {
            self.color += new Color(0, 0, 0, 1) * fadeRate * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        SceneManager.LoadScene(0);
        while (self.color != Color.clear)
        {
            self.color -= new Color(0, 0, 0, 1) * fadeRate * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        Destroy(transform.gameObject);
        yield return null;
    }
}
