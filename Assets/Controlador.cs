﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour
{
    public void CambiarEscena(string nombre){
    	print("C" + nombre);
    	SceneManager.LoadScene(nombre);
    }
}
