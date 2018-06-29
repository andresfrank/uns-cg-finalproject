﻿using UnityEngine;
using System.Collections.Generic;

public class GlowObject : MonoBehaviour{
	public Color GlowColor;
	public float LerpFactor = 10;
	public Color CurrentColor{
		get { return _currentColor; }
	}

	private Color _currentColor;
	private Color _targetColor;
	private Material[] materials = null;

	public void StartGlowing(Transform t){
		if(t != null){
			if(materials != null){
				StopGlowing();
			}
			materials = t.GetComponent<Renderer>().materials;
			_targetColor = GlowColor;
			enabled = true;
		}
	}

	public void StopGlowing(){
		for (int i = 0; i < materials.Length; i++){
			materials[i].SetColor("_GlowColor", Color.black);
		}
	}

	void Update(){
		if(materials != null){
			_currentColor = Color.Lerp(_currentColor, _targetColor, Time.deltaTime * LerpFactor);

			for (int i = 0; i < materials.Length; i++){
				materials[i].SetColor("_GlowColor", _currentColor);
			}

			if (_currentColor.Equals(_targetColor)){
				enabled = false;
			}
		}
	}
}
