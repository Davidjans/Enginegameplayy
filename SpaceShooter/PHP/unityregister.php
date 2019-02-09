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


  $sql = "SELECT id FROM accounts WHERE email = '{$email}' And username = '{$username}' And hash = '{$hash}'";
  $result = $conn->query($sql);
  $row = "";
  $id;
  if ($result->num_rows == 1) {
    $row = $result->fetch_assoc();
    $id = $row['id'];
  }
  // aragon
  $sql = "INSERT INTO ships (shiptype, attackspeedlevel, damagelevel, armorlevel, speedlevel, healthlevel, credits, difficulty, user_id)  VALUES ('1', '1', '2', '2', '1', '1', '0', '1', '{$id}')";
  $result = $conn->query($sql);
  //penetrator
  $sql = "INSERT INTO ships (shiptype, attackspeedlevel, damagelevel, armorlevel, speedlevel, healthlevel, credits, difficulty, user_id)  VALUES ('2', '2', '2', '1', '1', '1', '0', '1', '{$id}')";
  $result = $conn->query($sql);
  // swifty
  $sql = "INSERT INTO ships (shiptype, attackspeedlevel, damagelevel, armorlevel, speedlevel, healthlevel, credits, difficulty, user_id)  VALUES ('3', '2', '1', '1', '2', '1', '0', '1', '{$id}')";
  $result = $conn->query($sql);
  // pancakeor
  $sql = "INSERT INTO ships (shiptype, attackspeedlevel, damagelevel, armorlevel, speedlevel, healthlevel, credits, difficulty, user_id)  VALUES ('4', '1', '1', '2', '1', '2', '0', '1', '{$id}')";
  $result = $conn->query($sql);
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
