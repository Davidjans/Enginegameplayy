<?php
require "connect.php";
$token = "";
$loggedin = False;
$incorrect = False;
$playerid;

$token = CheckLogin( $_POST['loginName'], $_POST['password']);

if($token == null){
  $token = "test";
}

function CheckLogin( $loginName, $password){
  global $conn;
  global $loggedin;
  global $incorrect;
  global $playerid;
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
    if(password_verify($password, $row["hash"])){
      $loggedin = True;
      $playerid = $row["id"];
      return GenerateToken(128, $row['id']);
    }
    else{
      $incorrect = False;
    }
  } else {
    $incorrect = True;
  }
}

$loginResponse = new LoginResponse($loggedin,$token,$incorrect,$playerid);

echo json_encode($loginResponse);

function GenerateToken($length, $id){
  global $conn;
  $characters = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
  $string = "";
  for ($i=0; $i < $length; $i++) {
    $string .= $characters[rand(0,strlen($characters) - 1)];
  }
  $sql = "UPDATE accounts SET token='{$string}' WHERE id = $id" ;
  $result = $conn->query($sql);
  return $string;
}

class LoginResponse{
  public $success;
  public $token;
  public $incorrect;
  public $playerid;
  function __construct($success, $token, $incorrect, $playerid){
    $this->success = $success;
    $this->token = $token;
    $this ->incorrect = $incorrect;
    $this ->playerid = $playerid;
  }

}
