<?php
require "connect.php";

$attackSpeedLevel;
$damageLevel;
$armorLevel;
$speedLevel;
$healthLevel;
$credits;
$difficulty;

GetStats( $_POST['playerid'], $_POST['shiptype']);

function GetStats($playerId,$shipType){
  global $conn;
  global $attackSpeedLevel;
  global $damageLevel;
  global $armorLevel;
  global $speedLevel;
  global $healthLevel;
  global $credits;
  global $difficulty;

  $sql = "SELECT * FROM ships WHERE user_id = '". $conn->real_escape_string($playerId)."' AND shiptype = '". $conn->real_escape_string($shipType)."' " ;
  $result = $conn->query($sql);
  $row = "";
  if ($result->num_rows == 1) {
    $row = $result->fetch_assoc();
    $attackSpeedLevel = $row["attackspeedlevel"];
    $damageLevel = $row["damagelevel"];
    $armorLevel = $row["armorlevel"];
    $speedLevel = $row["speedlevel"];
    $healthLevel = $row["healthlevel"];
    $credits = $row["credits"];
    $difficulty = $row["difficulty"];
  }
}

$PlayerStats = new PlayerStats($attackSpeedLevel,$damageLevel,$armorLevel,$speedLevel,$healthLevel,$credits,$difficulty);

echo json_encode($PlayerStats);


class PlayerStats{
  public $attackSpeedLevel;
	public $damageLevel;
	public $armorLevel;
	public $speedLevel;
	public $healthLevel;
	public $credits;
	public $difficulty;
  function __construct($attackSpeedLevel, $damageLevel, $armorLevel, $speedLevel, $healthLevel, $credits, $difficulty){
    $this->attackSpeedLevel = $attackSpeedLevel;
    $this->damageLevel = $damageLevel;
    $this ->armorLevel = $armorLevel;
    $this->speedLevel = $speedLevel;
    $this->healthLevel = $healthLevel;
    $this ->credits = $credits;
    $this ->difficulty = $difficulty;
  }

}
