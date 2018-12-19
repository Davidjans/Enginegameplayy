<?php
require "connect.php";

$username = "davidjans";
$email = "davidjejans@hotmail.nl";
$password = "123456";

$hash = password_hash($password, PASSWORD_DEFAULT);

$sql = "INSERT INTO accounts (username, email, hash)
VALUES ('{$username}', '{$email}', '{$hash}')";

if($conn->query($sql) === true){
  echo "account aangemaakt";
}
else{
  echo "mislukt";
}
