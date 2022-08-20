using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySkill : MonoBehaviour
{
    // Start is called before the first frame update
  /// <summary>
  /// Sent when another object enters a trigger collider attached to this
  /// object (2D physics only).
  /// </summary>
  /// <param name="other">The other Collider2D involved in this collision.</param>
  private void OnTriggerEnter2D(Collider2D other)
  {
        Debug.Log("Ω∫≈≥ ¡¢√À");
        if (transform.tag == "Knife" && transform.parent.tag == "Player" && other.transform.name == "Bullet" && other.transform.tag == "SkillB")
        {
            Debug.Log("∫∏Ω∫ Ω∫≈≥ ¡¢√À");
            other.transform.GetComponent<Skill2>().DestroyBossSkill(gameObject);
            transform.GetComponent<HitFeel>().TimeStop(1f);
        }
        
    }
    
}
