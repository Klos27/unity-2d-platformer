<?php

function main()
{
    include "databaseConnection.php";
    include "scoreRepository.php";

    $con = getDatabaseConnection();
    $top = $_POST["top"];
    $login = $_POST["login"];
    $worldId = $_POST["worldId"];

    echo findTopScoresByLoginAndWorldId($con, $top, $login, $worldId);
    $con->close();
}

main();