using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITween : MonoBehaviour
{
  

   public void showSuccessLevelTxt(GameObject txt){
    txt.SetActive(true);
    LeanTween.moveLocal(txt,new Vector3(0,+250,0),1f);
   }

   public void ShowEndLevel(GameObject obj,GameObject st1,GameObject st2 , GameObject st3){
    Debug.Log("ShowScaleTween");
    obj.SetActive(true);
     obj.transform.localScale=new Vector3(0,0,0);
     LeanTween.scale(obj , new Vector3(1,1,1),1.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutElastic).setOnComplete( ()=> {
         LeanTween.scale(st1 , new Vector3(1,1,1),.5f).setDelay(0.2f).setEase(LeanTweenType.easeOutElastic).setOnComplete( ()=> {
           LeanTween.scale(st2 , new Vector3(1,1,1),.5f).setDelay(0.1f).setEase(LeanTweenType.easeOutElastic).setOnComplete( ()=> {
         LeanTween.scale(st3 , new Vector3(1,1,1),.5f).setDelay(0.1f).setEase(LeanTweenType.easeOutElastic);
      } );
      } );
      } );

   }
    
     

   public void ShowMoveObj(GameObject obj){
    LeanTween.moveLocal(obj , new Vector3(85,+90,0),2f).setDelay(0.5f);
   }
   
  
    
}
