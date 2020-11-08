<?php

	function retrieveUserByLoginAndPassword($con, $login, $password) {
		$userQuery = $con->prepare("SELECT id, login, password FROM game_user WHERE login = ?");
		$userQuery->bind_param('s', $login);
		$userQuery->execute();
		$result = $userQuery->get_result();
		
		if(mysqli_num_rows($result) == 1)
		{
			$user = $result->fetch_assoc();
			$hashedPassword = $user['password'];
			
			if (password_verify($password, $hashedPassword)) {
				return $user;
			}
		}
		return null;
	}		

	function main() {
		require_once "connect.php";
		$con = mysqli_connect($host, $dbUser, $dbPassword, $dbName, $dbPort);
		
		if(mysqli_connect_errno())
		{
			echo "1: Connection failed";
			exit();
		}
		
		$login = $_POST["login"];
		$password = $_POST["password"];
		
		$user = retrieveUserByLoginAndPassword($con, $login, $password);
		
		if(is_null($user)) {
			echo "2: Login or password is invalid";
		} else {
			echo "0\t" . $user["id"] . "\t" . $user["login"];
		}
	}
	
	main();
?>