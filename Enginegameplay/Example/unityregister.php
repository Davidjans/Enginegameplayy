<?php
require "connect.php";



checkRegister($_POST['username'],$_POST['email'],$_POST['password'],$_POST['passwordconfirm']);




function CheckRegister($username, $email, $password, $passwordconfirm)
{
  global $conn;

  $incorrect = "username";
  $success = false;

  if($password === $passwordconfirm)
  {
    $hash = password_hash($password, PASSWORD_DEFAULT);
  }
  else
  {
    $incorrect = "passwordnotsame";
    $loginResponse = new RegisterResponse($success, $incorrect);
    echo json_encode($registerResponse);
    die();
  }

  $sql = "SELECT * FROM accounts WHERE username = '{$username}'";
  $result = $conn->query($sql);
  if($result->num_rows > 0){
    $incorrect = "username";
    $registerResponse = new RegisterResponse($success ,$incorrect);
    echo json_encode($registerResponse);
    die();
  }

  $sql = "SELECT email FROM accounts WHERE email = '{$email}'";
  $result = $conn->query($sql);
  if($result ->num_rows > 0){
    $incorrect = "email";
    $registerResponse = new RegisterResponse($success ,$incorrect);
    echo json_encode($registerResponse);
    die();
  }
  $success = true;
  $sql = "INSERT INTO accounts (username, email, hash)
  VALUES ('{$username}', '{$email}', '{$hash}')";

  $result = $conn->query($sql);

  $registerResponse = new RegisterResponse($success ,$incorrect);
  echo json_encode($registerResponse);
}

class RegisterResponse{
  public $success;
  // .
  public $incorrect;
  function __construct($success, $incorrect){
    $this->success = $success;
    $this ->incorrect = $incorrect;
  }
}
