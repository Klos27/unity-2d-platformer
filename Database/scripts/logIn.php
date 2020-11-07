<?php

	require_once "connect.php";
		$con = mysqli_connect($host, $dbUser, $dbPassword, $dbName, $dbPort);
	
	if(mysqli_connect_errno()) {
		echo '1: Connection failed';
		exit();
	}
	
	echo print_r($_POST, true);
?>