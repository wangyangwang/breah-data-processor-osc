using UnityEngine;
using System.Collections;

public class OceanModifier : MonoBehaviour {


	float normalOceanScale = 3.0f;
	float normalWaveSpeed = 0.7f;

	float maxWaveSpeed = 3.0f;
	float maxOceanScale = 12.0f;

	float oceanScale;//1-10
	float waveSpeed; //0-3
	float windPower = 1.0f;//0-1


	float normalVol = 0.2f;
	float vol = 1.0f;


	float maxVol = 1.5f;



	float incrementN = 3.0f;


	public Ocean myOcean;

	// Use this for initialization
	void Start () {
		oceanScale = normalOceanScale;
		waveSpeed = normalWaveSpeed;
	}
	
	// Update is called once per frame
	void Update () {


		if(BreathDataProcesser.isInhaling){
			oceanScale += incrementN*Time.deltaTime;
			waveSpeed += incrementN*Time.deltaTime/500;
			vol += incrementN * Time.deltaTime/10;
		}else{
			if(oceanScale > normalOceanScale){
				oceanScale -= incrementN*Time.deltaTime/4;
			}
			if(waveSpeed > normalWaveSpeed){
				waveSpeed -= incrementN*Time.deltaTime/900;
			}
			if(vol > normalVol){
				vol -= incrementN * Time.deltaTime/10;
//				Debug.Log(incrementN * Time.deltaTime/100);
			}
		}

		if(oceanScale>maxOceanScale)oceanScale = maxOceanScale;
		if(waveSpeed>maxWaveSpeed)waveSpeed = maxWaveSpeed;
		if(vol>maxVol)vol = maxVol;

		modifyOcean();
		modifyVol();
	}

	public void modifyVol(){
		AudioListener.volume = vol;
		Debug.Log(AudioListener.volume);
	}


	public void modifyOcean(){
		myOcean.scale = oceanScale;
//		myOcean.speed = waveSpeed;
//		myOcean.humidity = windPower;
	}
}
