<?php

	function checkLogin($con, $login) {
		$loginMinLength = 1;
		$loginMaxLength = 50;
		$loginLength = strlen($login);
		
		if($loginLength < $loginMinLength or $loginLength > $loginMaxLength) {
			echo "2: Login length must be between " . $loginMinLength . " and " . $loginMaxLength;
			exit();
		}
		
		$loginCheckQuery = $con->prepare("SELECT login FROM game_user WHERE login = ?");
		$loginCheckQuery->bind_param('s', $login);
		$loginCheckQuery->execute();
		
		$loginCheck = $loginCheckQuery->get_result();
		
		if (mysqli_num_rows($loginCheck) > 0)
		{
			echo "3: Login already exists";
			exit();
		}
	}

	function checkPassword($password, $repeatedPassword) {
		$passwordMinLength = 6;
		
		if (strcmp($password, $repeatedPassword) !== 0) {
			echo "4: Passwords are not equal";
			exit();
		}
		if (strlen($password) < $passwordMinLength) {
			echo "5: Password must have at least " . $passwordMinLength . " characters";
			exit();
		}
	}

	function checkEmail($con, $email) {
		if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
			echo "6: Email is invalid";
			exit();
		}
		
		$emailCheckQuery = $con->prepare("SELECT email FROM game_user WHERE email = ?");
		$emailCheckQuery->bind_param('s', $email);
		$emailCheckQuery->execute();
		
		$emailCheck = $emailCheckQuery->get_result();
		
		if (mysqli_num_rows($emailCheck) > 0)
		{
			echo "7: Email already exists";
			exit();
		}
	}

	function insertUser($con, $login, $password, $email) {
		$hashedPassword = password_hash($password, PASSWORD_DEFAULT);
		$insertUserQuery = $con->prepare("INSERT INTO game_user (login, password, email) VALUES (?, ?, ?)");
		$insertUserQuery->bind_param('sss', $login, $hashedPassword, $email);
		
		try {
			$insertUserQuery->execute();			
		} catch (Exception $e) {
			echo "8: Creating new user failed. Message: " . $e->getMessage() . "\n";
			exit();
		}
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
		$repeatedPassword = $_POST["repeatedPassword"];
		$email = $_POST["email"];
		
		checkLogin($con, $login);
		checkPassword($password, $repeatedPassword);
		checkEmail($con, $email);
		insertUser($con, $login, $password, $email);

		echo "0";
	}

	main();
?>