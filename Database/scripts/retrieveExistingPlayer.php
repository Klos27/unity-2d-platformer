<?php

function main()
{
    include "databaseConnection.php";
    include "playerRepository.php";

    $con = getDatabaseConnection();
    $login = $_POST["login"];
    $password = $_POST["password"];
    $player = findPlayerByLoginAndPassword($con, $login, $password);

    if (is_null($player)) {
        echo "Login or password is invalid";
    } else {
        echo "0\t" . $player["id"] . "\t" . $player["login"];
    }

    $con->close();
}

main();