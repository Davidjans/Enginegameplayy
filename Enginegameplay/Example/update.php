<?php
require "connect.php";
$nieuwefruitsoort = "Apple";
$oudefruitsoort = "Pear";


$nieuwefruitsoort = $conn->real_escape_string($nieuwefruitsoort);
$oudefruitsoort = $conn->real_escape_string($oudefruitsoort);
$sql = "UPDATE fruit
SET name = '{$nieuwefruitsoort}'
WHERE name = '{$oudefruitsoort}'";

$result = $conn->query($sql);
