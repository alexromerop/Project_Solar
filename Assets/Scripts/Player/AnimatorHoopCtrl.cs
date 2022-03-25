using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorHoopCtrl : MonoBehaviour
{
    public Animator anim;
    public RuntimeAnimatorController anim2;
    public ThirdPersonMovement Movimiento;

    public MochilaController Mochila;

    public CogerObjeto cogerObjeto;
    public GameObject dustIzq;
    public box_scr boxScript;

    
    
    int VelocityHash;

    
    void Start(){
       VelocityHash = Animator.StringToHash("speed");
    }
    // Start is called before the first frame update
    IEnumerator IdleChanger()
    {
        anim = GetComponent<Animator>();
        while (true){
            yield return new WaitForSeconds(3);
            anim.SetInteger("IdleIndex", Random.Range(0,5));
            anim.SetTrigger("Idle");
        }
    }
    IEnumerator dust (float time){
        dustIzq.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        dustIzq.SetActive(false);
    }
    void DustJump(){
        StartCoroutine(dust(0.2f));
    }
   

    // Update is called once per frame
    void Update()
    {

        if (boxScript != null)
        {


            if (boxScript.boxAnim == true)
            {
                anim.SetBool("BoxPicked", true);
                if (Input.GetKey(KeyCode.W))
                {
                    anim.SetBool("PushFront", true);
                }
                else
                {
                    anim.SetBool("PushFront", false);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    anim.SetBool("PushBack", true);
                }
                else
                {
                    anim.SetBool("PushBack", false);
                }

            }
            else
            {
                anim.SetBool("BoxPicked", false);
            }

        }
        anim.SetFloat(VelocityHash, Movimiento.speed);

        if (Movimiento)
        {
            if (Movimiento.danger == true)
            {
                anim.runtimeAnimatorController = anim2;
            }

            if (Movimiento.isMoving == true)
            {
                anim.SetBool("isRunning", true);

            }
            if (Movimiento.isMoving == false)
            {
                anim.SetBool("isRunning", false);

            }
            if (Movimiento.isGrounded == true)
            {
                anim.SetBool("isGrounded", true);
            }
            if (Movimiento.isGrounded == false)
            {
                anim.SetBool("isGrounded", false);
            }
            if (Movimiento.velocity.y > 0)
            {
                anim.SetBool("isJumping", true);
            }
            if (Movimiento.velocity.y < 0)
            {
                anim.SetBool("isJumping", false);
            }
            if (Movimiento.isFalling == true)
            {
                anim.SetBool("isFalling", true);
            }
            if (Movimiento.isFalling == false)
            {
                anim.SetBool("isFalling", false);
            }
            if (Movimiento.canDoubleJump == false)
            {
                anim.SetBool("canDoubleJump", false);
            }
            if (Movimiento.canDoubleJump == true)
            {
                anim.SetBool("canDoubleJump", true);
            }
            if (Mochila.energia <= 0)
            {
                anim.SetInteger("Energia", 0);
            }
            if (Mochila.energia > 0)
            {
                anim.SetInteger("Energia", 1);
            }
            if (cogerObjeto.picked == true)
            {
                anim.SetTrigger("Picked");
            }
            if (cogerObjeto.picked == true)
            {
                anim.SetBool("PickedBool", true);
            }
            if (cogerObjeto.picked == false)
            {
                anim.SetBool("PickedBool", false);
            }
            if (Mochila.electrificado == true)
            {
                anim.SetBool("Rayo", true);
            }
            if (Mochila.electrificado == false)
            {
                anim.SetBool("Rayo", false);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                anim.SetTrigger("Buf");
            }
            if (Movimiento.vida > 50f)
            {
                anim.SetBool("Vida50", false);
            }
            if (Movimiento.vida < 50f)
            {
                anim.SetBool("Vida50", true);
            }
            if (Mochila.destroyed == true)
            {
                anim.SetBool("parDes", true);
            }
            if (Mochila.destroyed == false)
            {
                anim.SetBool("parDes", false);
            }
        }
    }
}
