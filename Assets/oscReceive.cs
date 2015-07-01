using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;



public class oscReceive : MonoBehaviour {

	public Text oscStatusText;

	private string UDPHost = "127.0.0.1";
	private int listenerPort = 2000;
	private int broadcastPort = 12345;
	private Osc oscHandler;


	private string eventName = "";
	private string eventData = "";
	public int inputData = 0;

	public string message;


	// Use this for initialization
	void Start () {
		Application.runInBackground = true;
		UDPPacketIO udp = GetComponent<UDPPacketIO>();
		udp.init(UDPHost,broadcastPort,listenerPort);
		oscHandler = GetComponent<Osc>();
		oscHandler.init(udp);
//		oscHandler.SetAddressHandler("/breathdata",getInput);
		oscHandler.SetAddressHandler("/breathdata", getInput);
		oscStatusText.text = "Sending Data to "+UDPHost+" : "+broadcastPort;
	}


	void Update(){
//		OscMessage myOscMessage  new OscMessage
		OscMessage oscM;

		if(BreathDataProcesser.isInhaling){
			oscM = Osc.StringToOscMessage("/sensordata/breath "+ 1);
		}else{
			oscM = Osc.StringToOscMessage("/sensordata/breath "+ 0);
		}
//		oscUsb is an Osc object, connected to a UsbPacket object 
		oscHandler.Send(oscM);
//		oscHandler.SendMessage("ji");
	}

//	public void sendOutMessage(OscMessage oscMessage){
//		OscMessage oscM = Osc.StringToOscMessage("0.2");
//		//		oscUsb is an Osc object, connected to a UsbPacket object 
//		oscHandler.Send(oscM);
//	}

	public void getInput(OscMessage oscMessage) {
		Osc.OscMessageToString(oscMessage);
		inputData =  Convert.ToInt32(oscMessage.Values[0]); // Int32.Parse(oscMessage.Values[0]);
//		Debug.Log(inputData);
	}

	public int getData(){
		return inputData;
	}

}
