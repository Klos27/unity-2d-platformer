<?php

	function retrievePlayerByLoginAndPassword($con, $login, $password) {
		$playerQuery = $con->prepare("SELECT id, login, password FROM player WHERE login = ?");
		$playerQuery->bind_param('s', $login);
		$playerQuery->execute();
		
		$result = $playerQuery->get_result();
		$playerQuery->close();
		
		if(mysqli_num_rows($result) == 1)
		{
			$player = $result->fetch_assoc();
			$hashedPassword = $player['password'];
			
			if (password_verify($password, $hashedPassword)) {
				return $player;
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
		
		$player = retrievePlayerByLoginAndPassword($con, $login, $password);
		
		if(is_null($player)) {
			echo "2: Login or password is invalid";
		} else {
			echo "0\t" . $player["id"] . "\t" . $player["login"];
		}
		
		$con->close();
	}
	
	main();
?>