
using UnityEngine.SceneManagement;
using UnityEngine;

public class changeScene : MonoBehaviour {

   
	public void changeToScene(int scene)
    {
        SceneManager.LoadScene(scene);

    }
}
