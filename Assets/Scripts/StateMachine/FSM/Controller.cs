using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class Controller : MonoBehaviour
    {
        public State currentState; // Apuntador al estado actual
        private Animator _animatorController; //Lo añadimos en Controller

        public bool ActiveAI { get; set; }

        public void Start()
        {
            ActiveAI = true; //Para activar la IA
            _animatorController = GetComponent<Animator>();
        }

        public void Update() //Se ejecutan las acciones del estado actual.
        {
            if (!ActiveAI) return; //El parametro permite que los estados tengan una referencia al controlador para poder llamar a sus metodos.

            if (currentState != null)
                currentState.UpdateState(this);
        }

        public void SetAnimation(string animation, bool value)
        {
            _animatorController.SetBool(animation, value);
        }

        public void Transition(State nextState)
        {
            currentState = nextState; //este metodo actualiza el apuntador al estado actual.
        }

        public void SetState(State s)
        {
            currentState = s;
        }
    }


}
