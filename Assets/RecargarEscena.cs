using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RecargarEscena : MonoBehaviour {
	
    private string LevelToLoad;
	
	public void recargarLaEscena() {
		//Load the level from LevelToLoad
        Scene scene = SceneManager.GetActiveScene();

        LevelToLoad = scene.name;

		SceneManager.LoadScene(LevelToLoad);
	}
}
