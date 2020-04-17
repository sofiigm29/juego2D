using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class dataArduino : MonoBehaviour
{

	SerialPort puerto = new SerialPort("COM4", 9600);

    // Start is called before the first frame update
    void Start()
    {
        puerto.Open();
        puerto.ReadTimeout = 1;
    }
    


    // Update is called once per frame
    void Update()
    {
        if (puerto.IsOpen)
        {
        	try
        	{
        		print(puerto.ReadByte());
        	}
        	catch (System.Exception)
        	{

        	}
        }
    }
}
