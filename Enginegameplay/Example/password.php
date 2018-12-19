<?php
$password = "123456";

$hash = password_hash($password, PASSWORD_BCRYPT);

echo $hash;
echo "<br>";
if(password_verify("13456", $hash)){
  echo "aye";
}
else{
  echo "lol";
}
