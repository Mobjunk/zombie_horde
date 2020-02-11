using System;
 
 public class Highscore : JsonHandler<HighscoreEntry>
 {
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
     }
 }