<?php

	$con = mysqli_connect('localhost', 'root', '', 'zpi_project_db', 3306);
	
	if(mysqli_connect_errno()) {
		echo '1: Connection failed';
		exit();
	}
	
	echo print_r($_POST, true);
?>