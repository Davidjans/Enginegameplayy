<?php
require "connect.php";
$fruitid = 13;

$sql = "DELETE FROM fruit WHERE id='{$fruitid}'";

$result = $conn->query($sql);
