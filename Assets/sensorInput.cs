using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Uniduino;
using UnityEngine.UI;

public class sensorInput : MonoBehaviour {
	
	public Text breathingRawValueText;

	private static sensorInput singleton = null;
	
	public static sensorInput getSingleton(){
		return singleton;
	}
	
	public Arduino arduino;
	
	//pins
	public int breathSensorPin = 0;

	//rawValues
	public float rawBreathingValue = 0.0f;

	
	void Start () {
		singleton = this;
		arduino = Arduino.global;
		arduino.Setup(ConfigurePins);
	}
	
	void ConfigurePins( )
	{
		arduino.pinMode(0, PinMode.ANALOG);
		arduino.reportAnalog(0,1); //report status
	}
	
	// Update is called once per frame
	void Update () {
		rawBreathingValue = arduino.analogRead(breathSensorPin);
		breathingRawValueText.text = rawBreathingValue.ToString();
	}
}
