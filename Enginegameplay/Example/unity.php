<?php

class Response{
  public $m_Motd = "I made your waifu wet. \nAmmount of pussy slain: ";
  public $m_Scores = [];
}

class Score{
  public $name;
  public $score;

  function __construct($name,$score){
    $this->name = $name;
    $this->score = $score;
  }
}
$names = ["Hans", "Boris", "Frank", "Dumbledore", "Gandalf"];



$response = new Response();

for ($i=0; $i < sizeof($names); $i++) {
  array_push($response->m_Scores, new Score($names[$i], rand()));
}

echo json_encode($response);
