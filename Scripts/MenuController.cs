using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void LoadFacile()
    {
        SceneManager.LoadScene("Facile"); // Correspond exactement au nom de ta scène
    }

    public void LoadIntermediaire()
    {
        SceneManager.LoadScene("Intermediaire");
    }

    public void LoadDifficile()
    {
        SceneManager.LoadScene("Difficile");
    }

}
 

