using UnityEngine;
using UnityEngine.SceneManagement;
 
public class Control : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Roll-a-ball");
    }
}