using System;
using System.Collections.Generic;
using UnityEngine;
using Res.Scripts.Game;

namespace Res.Scripts.Player
{
	public class CharacterMotor : MonoBehaviour
	{
		public Animator animator;
		
		public Rigidbody rb;
		public float currentSpeed;
		public float normalSpeed;
		public float crossSpeed;
		public float sprintSpeed;

		//Inputs
		private float _x;
		private float _z;

        void Start()
        {
			currentSpeed = normalSpeed;
        }

        void Update(){

			MyInputs();
		}

		private void MyInputs(){

			_x = Input.GetAxisRaw("Horizontal") * currentSpeed;
			_z = Input.GetAxisRaw("Vertical") * currentSpeed;

			CrossMovement();
		}

        private void FixedUpdate()
        {
			NormalMovement();
        }

        private void NormalMovement()
		{
			rb.velocity = new Vector3(-_z, 0, _x);

			animator.SetFloat("Horizontal", -_z);
			animator.SetFloat("Vertical", _x);
		}

		private void CrossMovement(){
			 
			if (_x == currentSpeed && _z == -currentSpeed) currentSpeed = crossSpeed;
			else if (_x == currentSpeed && _z == currentSpeed) currentSpeed = crossSpeed;
			else if (_x == -currentSpeed && _z == -currentSpeed) currentSpeed = crossSpeed;
			else if (_x == -currentSpeed && _z == currentSpeed) currentSpeed = crossSpeed;
			else
				currentSpeed = normalSpeed;
		}

        private void OnTriggerEnter(Collider other)
        {
            if (other.name.Equals("GameEnd"))
            {
				Destroy(gameObject);

				GameFinish.Instance.MainMethod();
            }
        }
    }
}