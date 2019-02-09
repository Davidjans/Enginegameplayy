<?php
require "connect.php";

GetStats( $_POST['attackspeedlevel'], $_POST['damagelevel'],$_POST['armorlevel'], $_POST['speedlevel'],$_POST['healthlevel'], $_POST['credits'],$_POST['difficulty'],$_POST['playerid'],$_POST['shiptype']);

function GetStats($attackspeedlevel,$damagelevel,$armorlevel,$speedlevel,$healthlevel,$credits,$difficulty,$playerid,$shiptype){
  global $conn;

  $sql = "UPDATE ships SET
  attackspeedlevel = '{$attackspeedlevel}',damagelevel = '{$damagelevel}',armorlevel = '{$armorlevel}',speedlevel = '{$speedlevel}',healthlevel = '{$healthlevel}',credits = '{$credits}',difficulty = '{$difficulty}'
  WHERE shiptype = '{$shiptype}' AND user_id = '{$playerid}' ";
  $result = $conn->query($sql);
  echo $conn->connect_error;
}
