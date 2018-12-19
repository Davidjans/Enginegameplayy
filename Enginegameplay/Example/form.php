<form action = "form.php">
    <input type = "text" name = "username"><br>
    <input type = "password" name = "password"><br>
    <input type = "submit" value = "Submit">
</form>
<?php
if(isset($_REQUEST["username"])){
  echo($_REQUEST["username"]);

}
