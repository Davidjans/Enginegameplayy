<?php
require "connect.php";
$token = "";



$token = CheckLogin($conn, "davidjans", "123456");

function CheckLogin($conn, $loginName, $password){

  if (filter_var($loginName, FILTER_VALIDATE_EMAIL))
  {
    $sql = "SELECT * FROM accounts WHERE email = '". $conn->real_escape_string($loginName)."'" ;
  }
  else
  {
    $sql = "SELECT * FROM accounts WHERE username = '". $conn->real_escape_string($loginName)."'" ;
  }
  $result = $conn->query($sql);
  $row = "";
  if ($result->num_rows == 1) {
    $row = $result->fetch_assoc();
  } else {
    die("Username/Email not found");
  }

  if(password_verify($password, $row["hash"])){
    echo("logged in<br>");
    return GenerateToken(128, $conn, $row['id']);
  }
  else{
    echo("Password Incorrect");
  }
}


function GenerateToken($length, $conn, $id){
  $characters = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
  $string = "";
  for ($i=0; $i < $length; $i++) {
    $string .= $characters[rand(0,strlen($characters) - 1)];
  }
  $sql = "UPDATE accounts
  SET token = '{$string}'
  WHERE id = {$id}";
  $conn->query($sql);
}
