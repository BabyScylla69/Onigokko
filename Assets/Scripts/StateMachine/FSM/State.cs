using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Carnation/State")]
    public class State : ScriptableObject
    {
        public Action[] actions; //En un state se ejecutan varias acciones

        public Transition[] transitions; //Desde un estado se puede pasar a otros estados a traves de las transiciones

        public void UpdateState(Controller controller) //Se ejecuta desde el controller.
        {
            DoActions(controller); // Ejecutamos todas las acciones
            CheckTransitions(controller); // Comprobamos las transiciones
        }

        private void DoActions(Controller controller) //Ejecuta las acciones
        {
            for (int i = 0; i < actions.Length; i++)
            {
                actions[i].Act(controller); //lamada al metodo abstracto
            }
        }

        private void CheckTransitions(Controller controller) //Se comprueban las transiciones y se llama al metodo abstracto Decide, que devuelve un true si la condicion de la transicion se cumple.
        {
            for (int i = 0; i < transitions.Length; i++)
            {
                bool decision = transitions[i].decision.Decide(controller);

                if (decision)
                {
                    controller.Transition(transitions[i].trueState);
                    return;
                }
            }
        }
    }
}
