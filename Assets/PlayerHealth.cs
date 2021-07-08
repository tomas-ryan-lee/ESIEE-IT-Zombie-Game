using UnityEngine;
using System.Collections;
 
public class PlayerHealth : MonoBehaviour
{
  public int currentHealth;
 
  public float healthBarLength;
 
  // Use this for initialization
  void Start()
  {
      currentHealth = 100;
  }
 
  public void TakeDamage(int damage)
  {
    currentHealth -= damage;
  }
}