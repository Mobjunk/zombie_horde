using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Highscore : JsonHandler<HighscoreEntry>
 {
     [Header("Main menu variables")]
     [SerializeField] private GameObject highscorePrefab;
     [SerializeField] private GameObject highscoreParent;
     private Color defaultColor = new Color(0.6117647f, 0.4117647f, 0.1294118f);
     private Color secondColor = new Color(0.5372549f, 0.3647059f, 0.1254902f);
     
     protected override string GetFileName()
     {
         return "highscores.json";
     }
 
     protected override string GetPath()
     {
         return "";
     }

     public override void Start()
     {
         base.Start();
         
         //Handles sorting the list by days surviving (top -> bottom)
         entries.Sort((a, b) => a.daysSurvived.CompareTo(b.daysSurvived));
         entries.Reverse();
         
         //Checks if the script is being loaded in the main menu
         if (SceneManager.GetActiveScene().name.Equals("MainMenu"))
             UpdateUI();
     }

     public void SortByDays()
     {
         entries.Sort((a, b) => a.daysSurvived.CompareTo(b.daysSurvived));
         entries.Reverse();

         UpdateUI();
     }

     public void SortByZombiesKilled()
     {
         entries.Sort((a, b) => a.zombiesKilled.CompareTo(b.zombiesKilled));
         entries.Reverse();

         UpdateUI();
     }

     public void SortByDamageDealt()
     {
         entries.Sort((a, b) => a.damageDealt.CompareTo(b.damageDealt));
         entries.Reverse();

         UpdateUI();
     }

     public void SortByDamageTaken()
     {
         entries.Sort((a, b) => a.damageTaken.CompareTo(b.damageTaken));
         entries.Reverse();

         UpdateUI();
     }

     public void UpdateUI()
     {
         foreach (Transform child in highscoreParent.transform)
             Destroy(child.gameObject);
         
         for (var slot = 0; slot < entries.Count; slot++)
         {
             var entry = entries[slot];
                 
             var entryObject = Instantiate(highscorePrefab, highscoreParent.transform, true);
             entryObject.transform.localScale = new Vector3(1,1,1);
             entryObject.transform.name = $"Highscore: {entry.playerName}";

             entryObject.GetComponent<Image>().color = slot % 2 == 0 ? defaultColor : secondColor;

             var entryTransform = entryObject.transform;
                 
             //All variables from the first row
             var rowOne = entryTransform.GetChild(0);
             var playerName = rowOne.transform.GetChild(0);
             var daysSurvived = rowOne.transform.GetChild(1);
             var zombiesKilled = rowOne.transform.GetChild(2);

             playerName.GetComponent<Text>().text = $"Player: {entry.playerName}";
             daysSurvived.GetComponent<Text>().text = $"Days survived: {entry.daysSurvived}";
             zombiesKilled.GetComponent<Text>().text = $"Zombies killed: {entry.zombiesKilled}";
                 
             //all variables from the second row
             var rowTwo = entryTransform.GetChild(1);
             var damageDealt = rowTwo.GetChild(0);
             var damageTaken = rowTwo.GetChild(1);
             var playerStatus = rowTwo.GetChild(2);

             damageDealt.GetComponent<Text>().text = $"Damage dealt: {entry.damageDealt}";
             damageTaken.GetComponent<Text>().text = $"Damage taken: {entry.damageTaken}";
             playerStatus.GetComponent<Text>().text = $"Player status: {entry.playerStatus}";
         }
     }
 }