<?php
require "connect.php";
$fruit = "Apple";
$fruit = $conn->real_escape_string($fruit);
$sql = "SELECT * FROM fruit WHERE name = '{$fruit}'";

$result = $conn->query($sql);

if($result ->num_rows > 0){
  while($row = $result->fetch_assoc()){
    echo $row['name'] . " " . $row['variety'] . "<br>";
  }
}
