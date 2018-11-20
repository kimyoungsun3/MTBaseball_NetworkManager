using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClickHP{
	public class ClickExplosion : MonoBehaviour {
		public float explosionRadius = 5f;
		Plane ground;
		float displayTime;
		Vector3 hitPoint;
		public float explosionForce = 1000;
		public float damageMax = 100f;
		public LayerMask explosionMask;

		void Start () {
			ground = new Plane (Vector3.up, Vector3.zero);
		}


		void Update () {
			if (Input.GetMouseButtonDown (0)) {
				Ray _ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				float _distance;
				if (ground.Raycast (_ray, out _distance)) {
					displayTime = Time.time + 10f;
					hitPoint = _ray.GetPoint (_distance);

					Collider[] _cols = Physics.OverlapSphere (_ray.GetPoint (_distance), explosionRadius, explosionMask);
					Rigidbody _rb;
					PlayerHealth _scpHealth;
					float _damage;
					for (int i = 0, iMax = _cols.Length; i < iMax; i++) {
						Debug.Log (i + " > " + _cols [i].name);
						_rb = _cols [i].GetComponent<Rigidbody> ();
						if (_rb != null) {
							_rb.AddExplosionForce (explosionForce, hitPoint, explosionRadius);
							_scpHealth = _rb.GetComponent<PlayerHealth> ();
							if (_scpHealth != null) {
								_damage = CalculateDamage (hitPoint, _rb.transform.position);
								_scpHealth.TakeDamage (_damage);
							}
						}
					}
				}
			}
		}

		float CalculateDamage(Vector3 _hitPoint, Vector3 _targetPoint){
			Vector3 _dir = _targetPoint - _hitPoint;
			float _damageValue = explosionRadius - _dir.magnitude;
			_damageValue = _damageValue < 0 ? 0 : _damageValue;
			float _damagePercent = _damageValue / explosionRadius;
			Debug.Log (_dir.magnitude + " -> " + (_damagePercent * damageMax));
			return _damagePercent * damageMax;
		}

		void OnDrawGizmos(){
			if (Time.time < displayTime) {
				Gizmos.color = Color.yellow;
				Gizmos.DrawWireSphere (hitPoint, explosionRadius);
			}
		}
	}
}
