<?php
require "connect.php";
$fruitid = 13;
$fruitname = "Apple";
$fruitbrand = "fristi";

$fruit = $conn->real_escape_string($fruitname);
$fruit = $conn->real_escape_string($fruitbrand);
$sql = "INSERT INTO fruit (id, name, variety) values ('{$fruitid}','{$fruitname}','{$fruitbrand}')";

$result = $conn->query($sql);
