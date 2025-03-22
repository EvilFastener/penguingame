using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        // Wypisz wszystkie stany Animatora na pierwszej warstwie (layer 0)
        AnimatorControllerParameter[] parameters = animator.parameters;
        foreach (var param in parameters)
        {
            Debug.Log("Animator parameter: " + param.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "lever")
        {
            // Sprawdü, czy animator gracza jest przypisany i posiada trigger 'appear'
            Animator otherAnimator = other.GetComponent<Animator>();
            if (otherAnimator != null)
            {
                otherAnimator.SetTrigger("appear");
            }
            else
            {
                Debug.LogWarning("Animator na obiekcie 'other' nie zosta≥ znaleziony.");
            }
            // Sprawdü, czy animator jest przypisany
            if (animator != null)
            {
                // Sprawdü, czy animator ma stan 'lever' na warstwie 0
                if (animator.HasState(0, Animator.StringToHash("lever")))
                {
                    animator.Play("lever", 0); // OdtwÛrz stan 'lever' na warstwie 0
                }
                else
                {
                    Debug.LogWarning("Stan 'lever' nie zosta≥ znaleziony w Animatorze na warstwie 0.");
                }
            }

            
        }
    }
}
