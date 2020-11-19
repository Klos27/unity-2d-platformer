<?php

function getDatabaseConnection()
{
    $host = "localhost";
    $dbUser = "root";
    $dbPassword = "";
    $dbName = "knights_vow";
    $dbPort = 3306;

    $con = mysqli_connect($host, $dbUser, $dbPassword, $dbName, $dbPort);

    if (mysqli_connect_errno()) {
        echo "Connection failed";
        exit();
    }

    return $con;
}