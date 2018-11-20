using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	public float speed = 2f;
	public float HEALTH_MAX = 100f;
	public Slider healthSlider;
	Vector3 move;
	float health;
	bool bDeath = false;

	void OnEnable () {
		health = HEALTH_MAX;
		SetUIHealth ();
	}
	
	void Update () {
		move.Set(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		transform.Translate (move * speed * Time.deltaTime);		
	}

	void SetUIHealth(){
		healthSlider.value = health;
	}

	public void TakeDamage(float _damage){
		health -= _damage;
		SetUIHealth ();
		if (health <= 0f && !bDeath) {
			bDeath = true;
			gameObject.SetActive (false);
		}
	}
}
