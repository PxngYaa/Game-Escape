using System.Collections;
using UnityEngine;
using TMPro;

public class FadeText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText; // TextMeshPro สำหรับข้อความ
    [SerializeField] private float fadeDuration = 2f; // ระยะเวลาในการจาง
    [SerializeField] private float displayDuration = 2f; // ระยะเวลาในการแสดง

    private void Start()
    {
        // เรียกฟังก์ชันเพื่อเริ่มการแสดงข้อความ
        StartCoroutine(DisplayAndFade());
    }

    private IEnumerator DisplayAndFade()
    {
        // ตั้งค่าความโปร่งใสเริ่มต้น
        Color textColor = messageText.color;
        textColor.a = 1f; // ตั้งค่าความโปร่งใสเป็น 1 (ไม่โปร่งใส)
        messageText.color = textColor;

        // แสดงข้อความ
        yield return new WaitForSeconds(displayDuration);

        // ทำให้ข้อความค่อยๆ จางลง
        float startAlpha = textColor.a;
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / fadeDuration;
            textColor.a = Mathf.Lerp(startAlpha, 0, normalizedTime);
            messageText.color = textColor;
            yield return null; // รอในเฟรมถัดไป
        }

        // ซ่อนข้อความเมื่อจางหมด
        textColor.a = 0f;
        messageText.color = textColor;
        messageText.gameObject.SetActive(false); // หรือ destroy ข้อความถ้าจำเป็น
    }
}
