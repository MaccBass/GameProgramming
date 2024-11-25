using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public GameObject speechBubble;
    public GameObject angryAnimation;
    // public Animator angryAnimator;
    public int payment = 10000;
    public int satisfaction = 3;

    void Start() {
        // angryEffect.Stop();
        StartCoroutine(CustomerRoutine());
    }

    private IEnumerator CustomerRoutine() {
        yield return new WaitForSeconds(3f);
        Order();

        yield return new WaitForSeconds(5f);
        AngryEffect();

        yield return new WaitForSeconds(5f);
        Leave();
    }

    private void Order() {
        Debug.Log("order");

        Temp_OrderManager.Instance.AddOrder("ramen", 2, 6f);
        speechBubble.SetActive(true);
        StartCoroutine(HideSpeechBubble());
    }
    private IEnumerator HideSpeechBubble() {
        yield return new WaitForSeconds(3f);
        speechBubble.SetActive(false); // 말풍선을 비활성화
    }

    private void AngryEffect() {
        Debug.Log("angry");
        angryAnimation.SetActive(true);
        // angryAnimator.SetTrigger("PlayAngry");

        StartCoroutine(DisableAngryAnimation());
    }
    private IEnumerator DisableAngryAnimation() {
        yield return new WaitForSeconds(3f);
        angryAnimation.SetActive(false);
    }
    private void Leave() {
        Destroy(gameObject);
        // 손님이 아닌 테이블 위치로 수정해야 함
        Temp_UIManager.Instance.ShowPaymentSatisfaction(transform.position, payment, satisfaction);
        Debug.Log("Leave");
    }
}
