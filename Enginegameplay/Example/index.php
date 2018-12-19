<?php
class Autisme{
  public $autismeNiveau = 9001;

  function GetWeight($autismAmmount){
    $totalWeight = 60 + 1 * $autismAmmount;
    return $totalWeight;
  }
}

class Screech extends Autisme{
  public $minScreechDB = 0;
  public $maxScreechDB = 500;
#  echo("Screech DB = ". rand($minScreechDB,$maxSchreechDB));
}

$fruit = ["Apel", "Kers", "Peer", 5, "Banaan"];
$autisme = new Autisme();
$screech = new Screech();
#echo($autisme->GetWeight($autisme->autismeNiveau));
echo("Screech DB = ". rand($screech->minScreechDB,$screech->maxScreechDB). "<br> ");
for($i = 0; $i < sizeof($fruit); $i++){
  echo($fruit[$i] . "<br>");
}
?>
