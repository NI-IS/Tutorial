﻿using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour {

	//Waveプレハブを格納する
	public GameObject[] waves;

	//現在のwave
	private int currentWave;

	// Use this for initialization
	IEnumerator Start () {
		//waveが存在しなければコルーチンを終了する
		if (waves.Length == 0) {
			yield break;
		}

		while (true) {
			//Waveを作成する
			GameObject wave = (GameObject)Instantiate (waves [currentWave],transform.position,Quaternion.identity);

			//Waveの子要素のEnemyが全て削除されるまで待機する
			while(wave.transform.childCount != 0){
				yield return new WaitForEndOfFrame();
			}

			//Waveの削除
			Destroy(wave);

			//格納されているWaveを全て実行したらcurrentWaveを0にする（最初から -> ループ）
			if(waves.Length <= ++currentWave){
				currentWave = 0;
			}
		}
	}
}