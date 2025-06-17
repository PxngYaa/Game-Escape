using System.Collections; // เพิ่ม namespace นี้
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCreditScroll : MonoBehaviour
{
    public float scrollSpeed = 50f; // ความเร็วในการเลื่อน
    public float endCreditHeight = 50f; // ความสูงที่ต้องการให้เลื่อนก่อนกลับไปที่เมนู

    void Update()
    {
        // เลื่อนข้อความขึ้น
        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);

        // ตรวจสอบตำแหน่ง Y ของข้อความ
        if (transform.position.y >= endCreditHeight)
        {
            // เรียก Coroutine เพื่อโหลดฉากเมนูหลังจากสิ้นสุดการเลื่อน
            StartCoroutine(LoadMainMenu());
        }
    }

    private IEnumerator LoadMainMenu()
    {
        // หน่วงเวลาเล็กน้อยเพื่อให้ผู้เล่นเห็นข้อความก่อนที่จะกลับไปที่เมนู
        yield return new WaitForSeconds(2f); // ปรับค่าตามที่ต้องการ

        // โหลดฉากเมนู (เปลี่ยนชื่อ 'MainMenu' เป็นชื่อฉากที่คุณต้องการ)
        SceneManager.LoadScene("Main Menu");
    }
}
