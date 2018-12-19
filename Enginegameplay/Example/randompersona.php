<?php
$personasRequired = 5;
$frontNames = ["Hans", "Boris", "Frank", "Dumbledore", "Gandalf", "Adoorin", "Ikki", "Fabio", "Amber", "David"];
$lastNames = ["Krokku", "Deramir", "Derakor", "Laflamme", "Lemari", "IronBeard", "Dwikki", "BlackClaw", "Resmanor", "Lerakon"];

if(isset($_POST['PersonaAmmount'])){
  $personasRequired = $_POST['PersonaAmmount'];
}

class Response{
  public $persons = [];
}

class Person{
  public $firstName;
  public $lastName;

  function __construct($firstName,$lastName){
    $this->firstName = $firstName;
    $this->lastName = $lastName;
  }
}

$response = new Response();

for ($i=0; $i < $personasRequired; $i++) {
  array_push($response->persons, new Person($frontNames[rand(0,sizeof($frontNames) -1)], $lastNames[rand(0, sizeof($lastNames)- 1)]));
}

echo json_encode($response);
